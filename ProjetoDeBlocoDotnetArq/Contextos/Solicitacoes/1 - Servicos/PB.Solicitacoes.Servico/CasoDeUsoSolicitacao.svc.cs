using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using PB.Solicitacoes.DomainServices.Modelos.Solicitacoes.Fabricas;
using PB.Solicitacoes.DomainServices.Modelos.Solicitacoes.Servicos;
using PB.Solicitacoes.Infra.Configuracoes;
using PB.Solicitacoes.Infra.Repositorios;
using PB.Solicitacoes.Servico.ViewModels;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace PB.Solicitacoes.Servico
{
	public class CasoDeUsoSolicitacao : ICasoDeUsoSolicitacao
	{
		private GerarClienteFactoryImp _fabrica;
		private ServicoSolicitarClienteImp _servicoSolicitacao;
		private SolicitacaoDeClienteRepositorioImp _repositorio;
		private ContextoDeSolicitacao _contexto;

		public CasoDeUsoSolicitacao()
		{
			_fabrica = new GerarClienteFactoryImp();
			_contexto = new ContextoDeSolicitacao();
			_repositorio = new SolicitacaoDeClienteRepositorioImp(_contexto);
			_servicoSolicitacao = new ServicoSolicitarClienteImp(_repositorio);
		}

		public void ResgistrarSolicitacao(SolicitacaoDeClientePessoaViewModel modelo)
		{
			//var resultado = new ResultadoOperacao<SolicitacaoDeClientePessoaViewModel>();
			//resultado.EntidadeDeRetorno = modelo;

			Cliente cliente = _fabrica.Gerar(modelo.TipoCliente, modelo.Nome, modelo.Documento, modelo.RG);

			if (cliente == null)
			{
				//resultado.Notificacao.AdicionarNotificacao(string.Format("Não foi possível criar a solicitãção para o Cliente {0}", modelo.Nome));

				//return resultado;
			}

			var solicitacao = new SolicitacaoDeCliente(cliente);

			_servicoSolicitacao.Executar(solicitacao);

			if (!_servicoSolicitacao.EstaValido)
			{
				//resultado.Notificacao.MesclarNotificacoes(_servicoSolicitacao);
			}

			//return resultado;
		}
	}
}
