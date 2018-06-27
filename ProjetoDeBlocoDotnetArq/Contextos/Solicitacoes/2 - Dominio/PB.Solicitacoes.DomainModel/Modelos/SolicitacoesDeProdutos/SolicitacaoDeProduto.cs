using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos
{
	public class SolicitacaoDeProduto : Solicitacao
	{
		public SolicitacaoDeProduto(Produto produto)
			: base()
		{
			this.Produto = produto;
		}

		public Produto Produto { get; private set; }
	}
}
