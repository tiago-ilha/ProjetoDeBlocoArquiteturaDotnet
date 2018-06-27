using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos;

namespace PB.Solicitacoes.DomainServices.Modelos.SolicitacoesDeClientes.Servicos
{
	public class ServicoCadastrarSolicitacaoClienteImp : Notificar, ServicoCadastrarSolicitacaoCliente
	{
		private readonly SolicitacaoDeClienteRepositorio _repositorio;

		public ServicoCadastrarSolicitacaoClienteImp(SolicitacaoDeClienteRepositorio repositorio)
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
