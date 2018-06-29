using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades
{
	public class ContaPoupanca : Produto
	{
		public DateTime? DataDeAniversario { get; private set; }
	}
}
