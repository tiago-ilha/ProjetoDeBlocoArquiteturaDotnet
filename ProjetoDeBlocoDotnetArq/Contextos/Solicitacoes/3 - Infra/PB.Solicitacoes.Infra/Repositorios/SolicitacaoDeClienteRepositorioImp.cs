using Alfa.Core.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PB.Solicitacoes.Infra.Repositorios
{
	public class SolicitacaoDeClienteRepositorioImp //: SolicitacaoDeClienteRepositorio
	{
		private ContextoDeSolicitacao _contexto;

		public SolicitacaoDeClienteRepositorioImp(ContextoDeSolicitacao contexto)
		{
			_contexto = contexto;
		}

		//public IEnumerable<SolicitacaoDeCliente> Listar(FiltroDeBuscaAbstrato<SolicitacaoDeCliente> filtro)
		//{
		//	return _contexto.SolicitacaoDeCliente.Include(x => x.Cliente).AsNoTracking().Where(filtro.AplicarFiltros());
		//}

		//public SolicitacaoDeCliente FiltrarPor(FiltroDeBuscaAbstrato<SolicitacaoDeCliente> filtro)
		//{
		//	return _contexto.SolicitacaoDeCliente.Include(x => x.Cliente).AsNoTracking().SingleOrDefault(filtro.AplicarFiltros());
		//}

		//public SolicitacaoDeCliente ObterPorId(Guid id)
		//{
		//	return _contexto.SolicitacaoDeCliente.Find(id);
		//}

		//public void Salvar(SolicitacaoDeCliente entidade)
		//{
		//	_contexto.SolicitacaoDeCliente.Add(entidade);
		//	_contexto.SaveChanges();
		//}

		//public void Editar(SolicitacaoDeCliente entidade)
		//{
		//	_contexto.Entry(entidade).State = EntityState.Modified;
		//	_contexto.SaveChanges();
		//}

		//public void Remover(SolicitacaoDeCliente entidade)
		//{
		//	_contexto.SolicitacaoDeCliente.Remove(entidade);
		//	_contexto.SaveChanges();
		//}
	}
}
