using PB.Solicitacoes.DomainModel.Enums;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
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

		public DbSet<Solicitacao> Solicitacao { get; set; }

		#region Solicitação do cliente

		//public DbSet<SolicitacaoDeCliente> SolicitacaoDeCliente { get; set; }		

		//public DbSet<Cliente> Cliente { get; set; }
		//public DbSet<PessoaFisica> PessoaFisica { get; set; }
		//public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

		#endregion

		#region Solicitação do produto

		public DbSet<SolicitacaoDeProduto> SolicitacaoDeProduto { get; set; }

		#endregion

		//public DbSet<ProdutoDaSolicitacao> ProdutoDaSolicitacao { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Types().Configure(x => x.ToTable(GetTableName(x.ClrType)));
			modelBuilder.Properties<Guid>().Where(x => x.Name.StartsWith("Id")).Configure(x => x.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
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

		private string GetTableName(Type type)
		{
			return type.Name;
		}
	}
}
