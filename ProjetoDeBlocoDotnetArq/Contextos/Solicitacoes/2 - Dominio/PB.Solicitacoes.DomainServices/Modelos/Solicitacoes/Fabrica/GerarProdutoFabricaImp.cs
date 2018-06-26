using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainServices.Modelos.Solicitacoes.Fabrica
{
	public class GerarProdutoFabricaImp : GerarProdutoFabrica
	{
		public Produto GerarProduto(string tipoProduto)
		{
			switch (tipoProduto)
			{
				case "ContaCorrente":
					return new ContaCorrente();
				case "ContaPoupanca":
					return new ContaPoupanca();
			}
		}
	}
}
