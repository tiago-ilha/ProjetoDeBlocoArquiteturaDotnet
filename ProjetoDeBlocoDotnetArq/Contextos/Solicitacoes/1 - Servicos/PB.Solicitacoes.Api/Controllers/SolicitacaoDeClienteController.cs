using Alfa.Core.Servicos;
using Alfa.Core.Validacoes;
using PB.Solicitacoes.Api.Models;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using PB.Solicitacoes.DomainServices.Modelos.SolicitacoesDeClientes.Servicos;
using PB.Solicitacoes.Infra.Configuracoes;
using PB.Solicitacoes.Infra.Repositorios;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PB.Solicitacoes.Api.Controllers
{
	[RoutePrefix("api/solicitacao")]
	public class SolicitacaoDeClienteController : ApiController
	{
		private ContextoDeSolicitacao _contexto;
		private SolicitacaoDeClienteRepositorio _repositorio;

		private ServicoCadastrarSolicitacaoCliente _servicoSolicitacao;
		private ServicoDeferirSolicitacaoCliente _servicoDeferir;

		public SolicitacaoDeClienteController()
		{
			_contexto = new ContextoDeSolicitacao();
			//_repositorio = new SolicitacaoDeClienteRepositorioImp(_contexto);
			_servicoSolicitacao = new ServicoCadastrarSolicitacaoClienteImp(_repositorio);

			_servicoDeferir = new ServicoDeferirSolicitacaoClienteImp(_repositorio);
		}

		// GET: api/Solicitacoes
		[HttpGet]
		[Route("Listar")]
		public HttpResponseMessage Listar(FiltroDeListagemDeSolicitacoes filtro)
		{
			var response = new HttpResponseMessage();

			var solicitacoes = _repositorio.Listar(filtro);

			if (solicitacoes == null || solicitacoes.Count() > 0)
			{
				response = Request.CreateResponse(HttpStatusCode.BadRequest, new { estaValido = true, titulo = "Nenhuma solicitação foi encontrada" });
			}
			else
			{
				response = Request.CreateResponse(HttpStatusCode.OK, new { entidadeDeRetorno = solicitacoes });
			}

			return response;
		}

		[HttpPost]
		[Route("pessoa-fisica")]
		public HttpResponseMessage Solicitacar([FromBody]SolicitacaoDeClientePessoaFisicaFisicaViewModel modelo)
		{
			var response  = new HttpResponseMessage();

			var nome = new Nome(modelo.Nome);
			var documento = new Documento(modelo.Documento);
			var rg = new RG(modelo.RG);
			Cliente cliente = new PessoaFisica(nome, documento, rg);

			return RegistrarSolicitacao(ref response, cliente);
		}

		[HttpPost]
		[Route("pessoa-juridica")]
		public HttpResponseMessage Solicitacar([FromBody]SolicitacaoDeClientePessoaJuridicaViewModel modelo)
		{
			var response = new HttpResponseMessage();

			var nome = new Nome(modelo.Nome);
			var documento = new Documento(modelo.Documento);
			Cliente cliente = new PessoaJuridica(nome, documento);

			return RegistrarSolicitacao(ref response, cliente);
		}

		[HttpGet]
		[Route("analisar")]
		public HttpResponseMessage Analisar(Guid idSolicitacao)
		{
			var response = new HttpResponseMessage();

			var solicitacao = _repositorio.ObterPorId(idSolicitacao);

			if (solicitacao == null)
			{
				response = Request.CreateResponse(HttpStatusCode.BadRequest, new { estaValido = true, titulo = "Nenhuma solicitação foi encontrada" });
			}
			else
			{
				response = Request.CreateResponse(HttpStatusCode.OK, new { entidadeDeRetorno = solicitacao });
			}

			return response;
		}

		[HttpPost]
		[Route("deferir")]
		public HttpResponseMessage Deferir(Guid idSolicitacao)
		{
			var response = new HttpResponseMessage();

			_servicoDeferir.Executar(idSolicitacao);

			return DefinirResposta(ref response, _servicoDeferir);
		}

		#region Métodos compartilhados

		private HttpResponseMessage RegistrarSolicitacao(ref HttpResponseMessage response, Cliente cliente)
		{
			var solicitacao = new SolicitacaoDeCliente(cliente);

			_servicoSolicitacao.Executar(solicitacao);

			return DefinirResposta(ref response, _servicoSolicitacao);
		}

		private HttpResponseMessage DefinirResposta(ref HttpResponseMessage response, Servico servico)
		{
			var casoDeUso = (Notificar)servico;

			if (!casoDeUso.EstaValido)
			{
				response = Request.CreateResponse(HttpStatusCode.BadRequest, new { estaValido = false, titulo = "Operação canceleada.", mensagens = casoDeUso.Notificacoes });
			}
			else
			{
				response = Request.CreateResponse(HttpStatusCode.Created, new { estaValido = true, titulo = "Operação sucesso." });
			}

			return response;
		}

		#endregion
	}
}
