using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class ContaCorrenteMap : EntityTypeConfiguration<ContaCorrente>, IMapeamento
	{
	}
}
