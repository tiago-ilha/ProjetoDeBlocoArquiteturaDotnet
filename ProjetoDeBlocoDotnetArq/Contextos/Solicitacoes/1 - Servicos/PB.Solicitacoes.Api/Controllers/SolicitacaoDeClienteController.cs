using Alfa.Core.Base;
using Alfa.Core.Servicos;
using Alfa.Core.Validacoes;
using PB.Solicitacoes.Api.Models;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Servicos;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using PB.Solicitacoes.Infra.Configuracoes;
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
		private SolicitacaoRepositorio _repositorio;

		private ServicoCadastrarSolicitacao _servicoSolicitacao;
		private ServicoDeferirSolicitacao _servicoDeferir;

		public SolicitacaoDeClienteController(
		SolicitacaoRepositorio repositorio,
		ServicoCadastrarSolicitacao servicoSolicitacao,
		ServicoDeferirSolicitacao servicoDeferir)
		{
			this._repositorio = repositorio;
			this._servicoSolicitacao = servicoSolicitacao;
			this._servicoDeferir = servicoDeferir;
		}

		// GET: api/Solicitacoes
		[HttpPost]
		[Route("listar")]
		public HttpResponseMessage Listar(FiltroDeListagemDeSolicitacoes filtro)
		{
			var response = new HttpResponseMessage();

			var solicitacoes = _repositorio.Listar(filtro);

			if (solicitacoes == null || solicitacoes.Count() == 0)
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
			var response = new HttpResponseMessage();

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

		//[HttpGet]
		//[Route("analisar")]
		//public HttpResponseMessage Analisar(Guid idSolicitacao)
		//{
		//	var response = new HttpResponseMessage();

		//	var solicitacao = _repositorio.ObterPorId(idSolicitacao);

		//	if (solicitacao == null)
		//	{
		//		response = Request.CreateResponse(HttpStatusCode.BadRequest, new { estaValido = true, titulo = "Nenhuma solicitação foi encontrada" });
		//	}
		//	else
		//	{
		//		response = Request.CreateResponse(HttpStatusCode.OK, new { entidadeDeRetorno = solicitacao });
		//	}

		//	return response;
		//}

		//[HttpPost]
		//[Route("deferir")]
		//public HttpResponseMessage Deferir(Guid idSolicitacao)
		//{
		//	var response = new HttpResponseMessage();

		//	var solicitacao = _repositorio.ObterPorId(idSolicitacao);

		//	_servicoDeferir.Executar(solicitacao);

		//	return DefinirResposta(ref response, _servicoDeferir);
		//}

		#region Métodos compartilhados

		private HttpResponseMessage RegistrarSolicitacao(ref HttpResponseMessage response, Cliente cliente)
		{
			var solicitacao = new Solicitacao(cliente);

			_servicoSolicitacao.Executar(solicitacao);

			return DefinirResposta(ref response, _servicoSolicitacao);
		}

		private HttpResponseMessage DefinirResposta(ref HttpResponseMessage response, IServico<Solicitacao> servico)
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
