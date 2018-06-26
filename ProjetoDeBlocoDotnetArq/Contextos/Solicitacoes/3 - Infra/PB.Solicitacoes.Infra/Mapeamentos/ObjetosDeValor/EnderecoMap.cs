using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using System.Data.Entity.ModelConfiguration;

namespace PB.Solicitacoes.Infra.Mapeamentos.ObjetosDeValor
{
	public class EnderecoMap : ComplexTypeConfiguration<Endereco>, IMapeamento
	{
		public EnderecoMap()
		{
			Property(x => x.Cep)
			.HasColumnName("Cep")
			.HasColumnType("varchar")
			.HasMaxLength(8)
			.IsRequired();

			Property(x => x.Logradouro)
			.HasColumnName("Logradouro")
			.HasColumnType("varchar")
			.HasMaxLength(30)
			.IsRequired();

			Property(x => x.Numero)
			.HasColumnName("Numero")
			.HasColumnType("int")
			.IsRequired();

			Property(x => x.Complemento)
			.HasColumnName("Complemento")
			.HasColumnType("int");

			Property(x => x.Bairro)
			.HasColumnName("Bairro")
			.HasColumnType("varchar")
			.HasMaxLength(30)
			.IsRequired();

			Property(x => x.Cidade)
			.HasColumnName("Cidade")
			.HasColumnType("varchar")
			.HasMaxLength(30)
			.IsRequired();

			Property(x => x.Estado)
			.HasColumnName("Estado")
			.HasColumnType("char")
			.IsFixedLength()
			.HasMaxLength(2)
			.IsUnicode(false);

			//.HasColumnType("varchar")
			//.HasMaxLength(2)
			//.IsRequired();

			//.IsFixedLength().HasMaxLength(1).HasColumnType("Char").IsUnicode(false);
		}
	}
}
