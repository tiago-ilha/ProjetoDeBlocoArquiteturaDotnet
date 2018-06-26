using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos;
using System;

namespace PB.Solicitacoes.DomainServices.Modelos.Solicitacoes.Servicos
{
	public class ServicoSolicitarClienteImp : Notificar,  ServicoSolicitarCliente
	{
		private readonly SolicitacaoDeClienteRepositorio _repositorio;

		public ServicoSolicitarClienteImp(SolicitacaoDeClienteRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public void Executar(SolicitacaoDeCliente solicitacao)
		{
			if(!solicitacao.EstaValido)
			{
				MesclarNotificacoes(solicitacao);
				return;
			}

			_repositorio.Salvar(solicitacao);
		}
	}
}
