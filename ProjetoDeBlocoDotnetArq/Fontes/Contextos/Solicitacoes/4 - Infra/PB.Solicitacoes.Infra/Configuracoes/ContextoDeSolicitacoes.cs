using Microsoft.EntityFrameworkCore;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class ContextoDeSolicitacoes : DbContext
    {
        public ContextoDeSolicitacoes(DbContextOptions<ContextoDeSolicitacoes> opcoes) :
            base(opcoes) { }

        public DbSet<SolicitacaoDoCliente> Solicitacao { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
    }
}