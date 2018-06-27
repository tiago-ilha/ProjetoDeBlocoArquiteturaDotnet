using Alfa.Core.Filtros;
using System;
using System.Collections.Generic;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios
{
	public interface SolicitacaoDeClienteRepositorio
	{
		IEnumerable<SolicitacaoDeCliente> Listar(FiltroDeBuscaAbstrato<SolicitacaoDeCliente> filtro);
		SolicitacaoDeCliente FiltrarPor(FiltroDeBuscaAbstrato<SolicitacaoDeCliente> filtro);
		SolicitacaoDeCliente ObterPorId(Guid id);
		void Salvar(SolicitacaoDeCliente entidade);
		void Editar(SolicitacaoDeCliente entidade);
		void Remover(SolicitacaoDeCliente entidade);
	}
}
