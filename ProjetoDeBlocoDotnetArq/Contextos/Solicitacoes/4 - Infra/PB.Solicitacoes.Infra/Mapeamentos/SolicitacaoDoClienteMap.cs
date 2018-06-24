using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Enums;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class SolicitacaoDoClienteMap : IEntityTypeConfiguration<SolicitacaoDoCliente>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoDoCliente> builder)
        {
             builder.ToTable("SolicitacaoDoCliente");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDeSolicitacao)
                .HasColumnName("DataDeSolicitacao")
                .HasColumnType("datetime");

            builder.Property(x => x.DataDeAnalise)
                .HasColumnName("DataDeAnalise")
                .HasColumnType("datetime");

            builder.Property(x => x.DataDeDefericao)
                .HasColumnName("DataDeDefericao")
                .HasColumnType("datetime");

            builder.Property(x => x.Situacao)
                .HasColumnName("Situacao")
                .HasMaxLength(50)
                .HasConversion(
                    propriedade => propriedade.ToString(),
                    propriedade => (TipoSituacaoSolicitacaoEnum)Enum.Parse(typeof(TipoSituacaoSolicitacaoEnum), propriedade))
                    .IsUnicode(false);
        }
    }
}