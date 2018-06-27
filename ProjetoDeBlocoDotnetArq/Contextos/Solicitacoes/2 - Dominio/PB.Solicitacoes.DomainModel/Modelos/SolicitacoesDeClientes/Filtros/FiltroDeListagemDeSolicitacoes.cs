using Alfa.Core.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Filtros
{
	public class FiltroDeListagemDeSolicitacoes : FiltroDeBuscaAbstrato<SolicitacaoDeCliente>
	{
		public override Expression<Func<SolicitacaoDeCliente, bool>> AplicarFiltros()
		{
			throw new NotImplementedException();
		}
	}
}
