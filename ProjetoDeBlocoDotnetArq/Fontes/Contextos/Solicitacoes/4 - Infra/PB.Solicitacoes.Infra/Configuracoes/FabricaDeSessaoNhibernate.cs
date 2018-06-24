using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class FabricaDeSessaoNhibernate
    {
        private static ISessionFactory fabrica;

        public static ISession AbrirNovaSessao()
        {
            return fabrica.OpenSession();
        }

        public static void Init(string stringDeConexao)
        {
            fabrica = ConstruirFabricaDeSessao(stringDeConexao);
            // EventosDeDominio.Iniciar();
        }

        private static ISessionFactory ConstruirFabricaDeSessao(string stringDeConexao)
        {
            FluentConfiguration configuracaoFluente = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(stringDeConexao))
                .Mappings(ConfiguraConvencoes());
            // .ExposeConfiguration(NewMethod());

            ConfigurarMapeamentos(configuracaoFluente);

            return configuracaoFluente.BuildSessionFactory();
        }

        private static void ConfigurarMapeamentos(FluentConfiguration configuracaoFluente)
        {
            configuracaoFluente.Mappings(_ =>
            {
                ListarTodosOsBinarios().ForEach(assembly =>
                {
                    _.FluentMappings.AddFromAssembly(Assembly.Load(assembly.GetName()));
                });
            });
        }

        private static Action<MappingConfiguration> ConfiguraConvencoes()
        {
            return m => m.FluentMappings
                                .Conventions.Add(
                                    ForeignKey.EndsWith("ID"),
                                    ConventionBuilder.Property
                                        .When(criterio => criterio.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                                .Conventions.Add<TableNameConvention>();
        }

        private static Action<Configuration> NewMethod()
        {
            return x =>
            {
                x.EventListeners.PostCommitUpdateEventListeners =
                new IPostUpdateEventListener[] { new EventListener() };

                x.EventListeners.PostCommitInsertEventListeners =
                    new IPostInsertEventListener[] { new EventListener() };

                x.EventListeners.PostCommitDeleteEventListeners =
                    new IPostDeleteEventListener[] { new EventListener() };

                x.EventListeners.PostCollectionUpdateEventListeners =
                    new IPostCollectionUpdateEventListener[] { new EventListener() };
            };
        }

        private static List<Assembly> ListarTodosOsBinarios()
        {
            var todosOsBinarios = new List<Assembly>();
            string caminhoDaAplicacao = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.GetFiles(caminhoDaAplicacao, "*Infra.dll").ToList().ForEach(file =>
            {
                todosOsBinarios.Add(Assembly.LoadFile(file));
            });

            return todosOsBinarios;
        }
    }
}