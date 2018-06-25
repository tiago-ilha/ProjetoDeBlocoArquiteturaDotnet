using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using PB.Solicitacoes.DomainModel;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class FabricaDeSessaoNhibernate
    {
        private static ISessionFactory _fabrica;
        private static string _connectionString;

        public FabricaDeSessaoNhibernate(string connectionString) => _connectionString = connectionString;

        public static ISessionFactory FabricaDeSesso
        {
            get { return _fabrica ?? (_fabrica = Iniciar()); }
        }

        private static ISessionFactory Iniciar()
        {
            _fabrica = ConstruirFabricaDeSessao(_connectionString);
            EventosDeDominio.Iniciar();

            return _fabrica;
        }

        private static ISessionFactory ConstruirFabricaDeSessao(string connectionString)
        {
            FluentConfiguration configuracaoFluente = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                                .Conventions.Add(ForeignKey.EndsWith("ID"),
                                    ConventionBuilder.Property
                                        .When(criterio => criterio.Expect(x => x.Nullable, Is.Not.Set), x => x.Not.Nullable()))
                                .Conventions.Add<TableNameConvention>())
                .ExposeConfiguration(
                    x =>
                    {
                        x.EventListeners.PostCommitUpdateEventListeners =
                        new IPostUpdateEventListener[] { new EventListener() };

                        x.EventListeners.PostCommitInsertEventListeners =
                            new IPostInsertEventListener[] { new EventListener() };

                        x.EventListeners.PostCommitDeleteEventListeners =
                            new IPostDeleteEventListener[] { new EventListener() };

                        x.EventListeners.PostCollectionUpdateEventListeners =
                            new IPostCollectionUpdateEventListener[] { new EventListener() };
                    }
                );

            configuracaoFluente.Mappings(_ =>
            {
                ListarTodosOsBinarios().ForEach(assembly =>
                {
                    _.FluentMappings.AddFromAssembly(Assembly.Load(assembly.GetName()));
                });
            });

            return configuracaoFluente.BuildSessionFactory();
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