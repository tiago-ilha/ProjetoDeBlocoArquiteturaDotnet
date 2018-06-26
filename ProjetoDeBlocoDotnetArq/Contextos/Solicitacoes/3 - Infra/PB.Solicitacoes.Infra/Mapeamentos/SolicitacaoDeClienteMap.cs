using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class SolicitacaoDeClienteMap : EntityTypeConfiguration<SolicitacaoDeCliente>, IMapeamento
	{
		public SolicitacaoDeClienteMap()
		{
			ToTable("SolicitacaoDeCliente");

			HasKey(x => x.Id);
			Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(x => x.DataDeSolicitacao);
			Property(x => x.DataDeAnalise);
			Property(x => x.DataDeDefericao);

			Property(x => x.Situacao.Descricao).HasColumnName("Situacao").HasMaxLength(20);

			HasRequired(x => x.Cliente).WithRequiredPrincipal(x => x.Solicitacao);
			HasRequired(x => x.Produto).WithRequiredPrincipal(x => x.Solicitacao);
		}
	}
}
