using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>, IMapeamento
	{
		public PessoaFisicaMap()
		{
			Property(x => x.RG.NumeroDocumento)
				.HasColumnName("RG")
				.HasMaxLength(20)
				.IsRequired();
		}
	}
}
