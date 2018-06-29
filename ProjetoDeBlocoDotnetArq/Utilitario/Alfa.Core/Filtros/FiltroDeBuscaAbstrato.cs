using System;
using System.Linq.Expressions;

namespace Alfa.Core.Filtros
{
	public abstract class FiltroDeBuscaAbstrato<TAgragador> : FiltroDeBusca
		where TAgragador : class
		//where TComando : class
	{
		public abstract Expression<Func<TAgragador, bool>> AplicarFiltros();
		//public abstract Expression<Func<TAgragador>> AplicarProjecao();
	}
}
