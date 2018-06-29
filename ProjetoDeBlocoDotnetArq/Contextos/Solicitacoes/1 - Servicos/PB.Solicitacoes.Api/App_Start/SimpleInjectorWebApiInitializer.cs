[assembly: WebActivator.PostApplicationStartMethod(typeof(PB.Solicitacoes.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace PB.Solicitacoes.Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
	using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios;
	using System.Linq;
	using PB.Solicitacoes.Infra.Repositorios;
	using PB.Solicitacoes.DomainServices.Modelos.Solicitacoes;
	using Alfa.Core.Repositorios;
	using Alfa.Core.Servicos;
	using PB.Solicitacoes.Infra.Configuracoes;
	using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Servicos;
	using Alfa.Core.Transacao;
	using PB.Solicitacoes.Infra.Transacao;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
			container.Register<ContextoDeSolicitacao>(Lifestyle.Scoped);
			container.Register<UnidadeDeTrabalho, UnidadeDeTrabalhoImp>(Lifestyle.Scoped);

			container.Register<SolicitacaoRepositorio, SolicitacaoRepositorioImp>(Lifestyle.Scoped);

			container.Register<ServicoCadastrarSolicitacao, ServicoCadastrarSolicitacaoImp>(Lifestyle.Scoped);
			container.Register<ServicoDeferirSolicitacao, ServicoDeferirSolicitacaoImp>(Lifestyle.Scoped);

			


			//var servicoAssembly = typeof(ServicoCadastrarSolicitacaoImp).Assembly;

			//var servicoRegistrations =
			//	from type in servicoAssembly.GetExportedTypes()
			//	where type.Namespace == "PB.Solicitacoes.DomainServices.Modelos.Solicitacoes"
			//	where type.GetInterfaces().Any()
			//	select new { Service = type.GetInterfaces().Single(), Implementation = type };

			//foreach (var reg in servicoRegistrations)
			//	container.Register(reg.Service, reg.Implementation, Lifestyle.Scoped);
        }
    }
}