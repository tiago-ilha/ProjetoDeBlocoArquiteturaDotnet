using Alfa.Core.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PB.Solicitacoes.Infra.Repositorios
{
	public class SolicitacaoDeClienteRepositorioImp : SolicitacaoDeClienteRepositorio
	{
		private ContextoDeSolicitacao _contexto;

		public SolicitacaoDeClienteRepositorioImp(ContextoDeSolicitacao contexto)
		{
			_contexto = contexto;
		}

		public IEnumerable<SolicitacaoDeCliente> Listar(FiltroDeBusca filtro)
		{
			throw new NotImplementedException();
		}

		public SolicitacaoDeCliente FiltrarPor(FiltroDeBusca filtro)
		{
			throw new NotImplementedException();
		}

		public SolicitacaoDeCliente FiltroPor(Guid id)
		{
			return _contexto.Solicitacao.Find(id);
		}

		public void Salvar(SolicitacaoDeCliente entidade)
		{
			_contexto.Solicitacao.Add(entidade);
			_contexto.SaveChanges();
		}

		public void Editar(SolicitacaoDeCliente entidade)
		{
			_contexto.Entry(entidade).State = EntityState.Modified;
		}

		public void Remover(SolicitacaoDeCliente entidade)
		{
			_contexto.Solicitacao.Remove(entidade);
		}
	}
}
