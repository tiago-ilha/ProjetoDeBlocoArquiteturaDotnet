using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebBanco.Models
{
    public class SolicitacoesContext : DbContext
    {
        public SolicitacoesContext (DbContextOptions<SolicitacoesContext> options)
            : base(options)
        {
        }

        public DbSet<WebBanco.Models.Solicitacao> Solicitacao { get; set; }
    }
}
