using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class ProdutoMap : EntityTypeConfiguration<Produto>, IMapeamento
	{
		public ProdutoMap()
		{
			ToTable("Produto");

			HasKey(x => x.SoliclitacaoClienteId);
		}
	}
}
