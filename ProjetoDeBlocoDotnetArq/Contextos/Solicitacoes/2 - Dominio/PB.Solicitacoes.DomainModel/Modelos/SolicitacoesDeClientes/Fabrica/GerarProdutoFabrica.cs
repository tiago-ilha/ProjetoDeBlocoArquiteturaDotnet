using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Fabrica
{
	public interface GerarProdutoFabrica
	{
		Produto GerarProduto(string tipoProduto);
	}
}
