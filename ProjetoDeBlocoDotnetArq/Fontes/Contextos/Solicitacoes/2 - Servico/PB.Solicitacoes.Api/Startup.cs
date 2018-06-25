using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Microsoft.AspNetCore.Http;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using PB.Solicitacoes.Infra.Configuracoes;
using NHibernate;
using PB.Solicitacoes.DomainService.Modelos.Servicos;
using System.Linq;
using PB.Solicitacoes.Infra.Repositorios;
using PB.Solicitacoes.DomainModel;
using PB.Solicitacoes.Infra.UnidadeDeTrabalho;

namespace PB.Solicitacoes.Api
{
    public class Startup
    {
        private Container _container;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<ContextoDeSolicitacoes>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("ProjetoDeBloco.Solicitacoes")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            ConfigurarDI(services);
        }

        private void ConfigurarDI(IServiceCollection services)
        {
            _container = new Container();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IniciarContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void IniciarContainer(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);

            _container.Register<ITransacao, Transacao>();

            RegistrarServicos();
            RegistrarRepositorios();

            var sessionProvider = new SessionProvider(Configuration.GetConnectionString("ProjetoDeBloco.Solicitacoes"));

            _container.Register(() => sessionProvider.SessionFactory, Lifestyle.Singleton);
            _container.Register<NHibernate.ISession>(() => _container.GetInstance<ISessionFactory>().OpenSession(), Lifestyle.Singleton);

            //var fabrica = FabricaDeSessaoNhibernate.ConfigurarFabricaDeSessao(Configuration.GetConnectionString("ProjetoDeBloco.Solicitacoes"));

            //_container.Register(() => fabrica, Lifestyle.Singleton);
            //_container.Register<NHibernate.ISession>(() => _container.GetInstance<ISessionFactory>().OpenSession(), Lifestyle.Scoped);

            _container.Verify();

            _container.AutoCrossWireAspNetComponents(app);
        }

        private void RegistrarRepositorios()
        {
            var repositoriosAssembly = typeof(SolicitacaoDeClienteRepositorioImp).Assembly;

            var registrarRepositorios =
                from type in repositoriosAssembly.GetExportedTypes()
                where type.Namespace == "PB.Solicitacoes.Infra.Repositorios"
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrarRepositorios)
            {
                _container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }

        private void RegistrarServicos()
        {
            var servicosDeDominioAssembly = typeof(ServicoCadastrarSolicitacaoImp).Assembly;
            
            var registrarServicos =
                from type in servicosDeDominioAssembly.GetExportedTypes()
                where type.Namespace == "PB.Solicitacoes.DomainService.Modelos.Servicos"
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrarServicos)
            {
                _container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }
    }
}
