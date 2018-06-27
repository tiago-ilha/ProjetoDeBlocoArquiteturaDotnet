using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class ContaPoupancaMap : EntityTypeConfiguration<ContaPoupanca>, IMapeamento
	{
		public ContaPoupancaMap()
		{
		}
	}
}
