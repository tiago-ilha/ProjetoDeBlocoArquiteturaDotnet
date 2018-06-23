using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.Solicitacoes.DomainModel.Modelos;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class SolicitacaoDeClienteMap : IEntityTypeConfiguration<SolicitacaoDeCliente>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoDeCliente> builder)
        {
            
        }
    }
}
