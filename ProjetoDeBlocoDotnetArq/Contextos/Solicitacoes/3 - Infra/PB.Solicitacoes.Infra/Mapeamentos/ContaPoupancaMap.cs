using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
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
