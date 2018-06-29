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

			HasRequired(x => x.Cliente).WithRequiredPrincipal(x => x.Solicitacao).WillCascadeOnDelete(true);
			HasRequired(x => x.Produto);
		}
	}
}
