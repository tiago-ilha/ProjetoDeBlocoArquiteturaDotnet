using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class PessoaJuridicaMap : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("PessoaJuridica");
            
            builder.HasKey(x => x.Id);

            builder.OwnsOne(propriedade => propriedade.Nome, mapeamento => {
                mapeamento.Property(x => x.NomeCompleto)
                .HasColumnName("NomeCompleto")
                .HasColumnType("varchar(80)")
                .IsRequired();
            });

            builder.OwnsOne(propriedade => propriedade.Documento, mapeamento => 
            {
                mapeamento.Property(x => x.NumeroDocumento)
                .HasColumnName("CPF")
                .HasColumnType("varchar(50)")
                .IsRequired();
            });

            builder.OwnsOne(propriedade => propriedade.Endereco, mapeamento => 
            {
                mapeamento.Property(x => x.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(8)")
                .IsRequired();

                mapeamento.Property(x => x.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(50)")
                .IsRequired();

                mapeamento.Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(50)")
                .IsRequired();

                mapeamento.Property(x => x.Complemento)
                .HasColumnName("Complemento")
                .HasColumnType("varchar(10)");

                mapeamento.Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(50)")
                .IsRequired();

                mapeamento.Property(x => x.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(50)")
                .IsRequired();

                mapeamento.Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(2)")
                .IsRequired();
            });
        }
    }
}