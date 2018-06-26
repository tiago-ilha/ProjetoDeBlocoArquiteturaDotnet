using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class ClienteMap : EntityTypeConfiguration<Cliente>, IMapeamento
	{
		public ClienteMap()
		{
			ToTable("Cliente");

			HasKey(x => x.SoliclitacaoClienteId);

			Property(x => x.Nome.NomeCompleto).HasColumnName("NomeCompleto")
				.HasColumnType("varchar")
				.HasMaxLength(50)
				.IsRequired();

			Property(x => x.Documento.NumeroDocumento)
				.HasColumnName("NumeroDocumento")
				.HasColumnType("varchar")
				.HasMaxLength(14)
				.IsRequired();
		}
	}
}
