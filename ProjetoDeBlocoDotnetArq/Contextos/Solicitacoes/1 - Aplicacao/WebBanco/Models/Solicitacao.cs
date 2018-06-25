using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanco.Models
{
    public class Solicitacao
    {
        public int ID { get; set; }

        public Cliente cliente { get; set; }

        public Produto produto { get; set; }
    }
}
