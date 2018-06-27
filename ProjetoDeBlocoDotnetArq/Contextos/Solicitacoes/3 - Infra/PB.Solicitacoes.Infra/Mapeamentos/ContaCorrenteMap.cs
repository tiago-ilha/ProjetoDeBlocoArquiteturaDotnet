using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class ContaCorrenteMap : EntityTypeConfiguration<ContaCorrente>, IMapeamento
	{
		public ContaCorrenteMap()
		{
		}
	}
}
