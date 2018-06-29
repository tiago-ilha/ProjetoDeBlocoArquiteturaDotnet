using Alfa.Core.Base;
using Alfa.Core.Filtros;
using Alfa.Core.Repositorios;
using PB.Solicitacoes.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace PB.Solicitacoes.Infra.Repositorios
{
	public abstract class Repositorio<TAgregador> : IRepositorio<TAgregador> where TAgregador : Agregador
	{
		protected ContextoDeSolicitacao _contexto;

		public Repositorio(ContextoDeSolicitacao contexto)
		{
			_contexto = contexto;
		}

		//public virtual IEnumerable<TAgregador> Listar(FiltroDeBuscaAbstrato<TAgregador> filtro)
		//{
		//	return _contexto.Set<TAgregador>().AsNoTracking().Where(filtro.AplicarFiltros());
		//}

		public virtual TAgregador FiltrarPor(FiltroDeBuscaAbstrato<TAgregador> filtro)
		{
			return _contexto.Set<TAgregador>().SingleOrDefault(filtro.AplicarFiltros());
		}

		public virtual TAgregador ObterPorId(Guid id)
		{
			return _contexto.Set<TAgregador>().Find(id);
		}

		public virtual void Salvar(TAgregador agregador)
		{
				_contexto.Set<TAgregador>().Add(agregador);
		}

		public void Editar(TAgregador agregador)
		{
			var entry = _contexto.Entry(agregador);

			if (VerificarEstadoDoObjeto(entry, EntityState.Deleted))
				_contexto.Set<TAgregador>().Attach(agregador);

			_contexto.MudarEstadoDoObjeto(agregador, EntityState.Modified);
		}

		public virtual void Remover(TAgregador agregador)
		{
			var entry = _contexto.Entry(agregador);

			if (VerificarEstadoDoObjeto(entry, EntityState.Deleted))
				_contexto.Set<TAgregador>().Attach(agregador);

			_contexto.MudarEstadoDoObjeto(agregador, EntityState.Deleted);
		}

		private bool VerificarEstadoDoObjeto(DbEntityEntry<TAgregador> entry, EntityState entityState)
		{
			return entry.State == entityState;
		}
	}
}
