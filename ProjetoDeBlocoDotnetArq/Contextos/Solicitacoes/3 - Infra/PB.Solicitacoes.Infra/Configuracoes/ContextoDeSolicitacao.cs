using PB.Solicitacoes.DomainModel.Enums;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<PessoaFisica> PessoaFisica { get; set; }
		public DbSet<PessoaJuridica> PessoaJuridica { get; set; }

		public DbSet<Produto> Produto { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Types().Configure(x => x.ToTable(GetTableName(x.ClrType)));
			modelBuilder.Properties<Guid>().Where(x => x.Name.StartsWith("Id")).Configure(x => x.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));

			modelBuilder.ComplexType<TipoSituacaoSolicitacaoEnum>().Ignore(x => x.Valor);
			modelBuilder.Types<Solicitacao>().Configure(x => x.Property(m => m.Situacao.Descricao).HasColumnName("Situacao").HasMaxLength(30));

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

		public virtual void MudarEstadoDoObjeto(object model, EntityState state)
		{
			//Aqui trocamos o estado do objeto, 
			//facilita quando temos alterações e exclusões
			((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(model, state);
		}

		private string GetTableName(Type type)
		{
			return type.Name;
		}
	}
}
