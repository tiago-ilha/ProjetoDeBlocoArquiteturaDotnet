using System;
using System.Linq;
using System.Reflection;
using PB.Solicitacoes.DomainModel.Modelos;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class SolicitacoesContexto 
    {
        // public SolicitacoesContexto(DbContextOptions<SolicitacoesContexto> opcoes) : 
        //     base(opcoes)
        // {
        // }

        // public DbSet<SolicitacaoDeCliente> Solicitacaos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Fazendo o mapeamento com o banco de dados
        //    //Pega todas as classes que estão implementando a interface IEntityTypeConfiguration
        //    //Assim o Entity Framework é capaz de carregar os mapeamentos
        //    var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
        //                          where x.IsClass && typeof(IEntityTypeConfiguration<>).IsAssignableFrom(x)
        //                          select x).ToList();

        //    // Varrendo todos os tipos que são mapeamento 
        //    // Com ajuda do Reflection criamos as instancias 
        //    // e adicionamos no Entity Framework
        //    foreach (var mapping in typesToMapping)
        //    {
        //        dynamic mappingClass = Activator.CreateInstance(mapping);
        //        modelBuilder.ApplyConfiguration(mappingClass);
        //    }
        //}
    }
}
