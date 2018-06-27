using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class SolicitacaoDoProdutoMap : EntityTypeConfiguration<SolicitacaoDeProduto>, IMapeamento
	{
		public SolicitacaoDoProdutoMap()
		{
			HasRequired(x => x.Produto).WithRequiredPrincipal(x => x.Solicitacao);
		}
	}
}
