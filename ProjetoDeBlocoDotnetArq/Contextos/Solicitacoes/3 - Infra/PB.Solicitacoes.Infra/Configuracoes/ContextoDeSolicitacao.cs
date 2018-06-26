using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Enums;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace PB.Solicitacoes.Infra.Configuracoes
{
	public class ContextoDeSolicitacao : DbContext
	{
		public ContextoDeSolicitacao()
			: base(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString)
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<SolicitacaoDeCliente> Solicitacao { get; set; }
		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<PessoaFisica> PessoaFisica { get; set; }
		public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

		public DbSet<Produto> Produto { get; set; }

		public DbSet<ContaPoupanca> ContaPoupanca { get; set; }

		//public DbSet<ProdutoDaSolicitacao> ProdutoDaSolicitacao { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.ComplexType<TipoSituacaoSolicitacaoEnum>().Ignore(x => x.Valor);

			//Fazendo o mapeamento com o banco de dados
			//Pega todas as classes que estão implementando a interface IMapping
			//Assim o Entity Framework é capaz de carregar os mapeamentos
			var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
								  where x.IsClass && typeof(IMapeamento).IsAssignableFrom(x)
								  select x).ToList();

			// Varrendo todos os tipos que são mapeamento 
			// Com ajuda do Reflection criamos as instancias 
			// e adicionamos no Entity Framework
			foreach (var mapping in typesToMapping)
			{
				dynamic mappingClass = Activator.CreateInstance(mapping);
				modelBuilder.Configurations.Add(mappingClass);
			}
		}

		
	}
}
