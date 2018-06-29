using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class SolicitacaoMap : EntityTypeConfiguration<Solicitacao>, IMapeamento
	{
		public SolicitacaoMap()
		{
			Property(x => x.DataDeCadastro);
			Property(x => x.DataDeSolicitacao);
			Property(x => x.DataDeDefericao);

			HasMany(x => x.Clientes).WithRequired(x => x.Solicitacao).HasForeignKey(x => x.IdSolicitacao).WillCascadeOnDelete(true);
			HasMany(x => x.Produtos).WithRequired(x => x.Solicitacao).HasForeignKey(x => x.IdSolicitacao).WillCascadeOnDelete(true);
		}
	}
}
