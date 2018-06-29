using Alfa.Core.Base;
using Alfa.Core.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alfa.Core.Repositorios
{
	public interface IRepositorio<TAgregador> where TAgregador : Agregador
	{
		//IQueryable<object> Listar(FiltroDeBuscaAbstrato<TAgregador> filtro);
		TAgregador FiltrarPor(FiltroDeBuscaAbstrato<TAgregador> filtro);
		TAgregador ObterPorId(Guid id);
		void Salvar(TAgregador agregador);
		void Editar(TAgregador agregador);
		void Remover(TAgregador agregador);
	}
}
