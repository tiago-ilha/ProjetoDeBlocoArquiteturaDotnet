using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class ContextoDeSolicitacoes : DbContext
    {
        // public ContextoDeSolicitacoes(DbContextOptions<ContextoDeSolicitacoes> opcoes) :
        //     base(opcoes) { }

        public DbSet<SolicitacaoDoCliente> Solicitacao { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1503;Database=ProjetoDeBloco.Solicitacoes;User ID=SA;Password=q1w2e3r4!@#");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                where x.IsClass && typeof(IEntityTypeConfiguration<>).IsAssignableFrom(x)
                                select x).ToList();
        
            // Varrendo todos os tipos que são mapeamento 
            // Com ajuda do Reflection criamos as instancias 
            // e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }
        }
    }
}