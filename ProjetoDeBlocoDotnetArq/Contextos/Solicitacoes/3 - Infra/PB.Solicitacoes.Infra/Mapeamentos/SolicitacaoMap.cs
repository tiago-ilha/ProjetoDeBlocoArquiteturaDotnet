using PB.Solicitacoes.DomainModel.Modelos;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class SolicitacaoMap : EntityTypeConfiguration<Solicitacao>, IMapeamento
	{
		public SolicitacaoMap()
		{

		}
	}
}
