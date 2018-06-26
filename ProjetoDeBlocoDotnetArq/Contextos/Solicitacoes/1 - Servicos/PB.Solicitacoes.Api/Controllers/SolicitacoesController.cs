using PB.Solicitacoes.Api.Models;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using PB.Solicitacoes.DomainServices.Modelos.Solicitacoes.Servicos;
using PB.Solicitacoes.Infra.Configuracoes;
using PB.Solicitacoes.Infra.Repositorios;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PB.Solicitacoes.Api.Controllers
{
	[RoutePrefix("api/solicitacao")]
	public class SolicitacoesController : ApiController
	{
		private ContextoDeSolicitacao _contexto;
		private SolicitacaoDeClienteRepositorioImp _repositorio;
		private ServicoSolicitarClienteImp _servicoSolicitacao;

		public SolicitacoesController()
		{
			_contexto = new ContextoDeSolicitacao();
			_repositorio = new SolicitacaoDeClienteRepositorioImp(_contexto);
			_servicoSolicitacao = new ServicoSolicitarClienteImp(_repositorio);
		}

		// GET: api/Solicitacoes
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Solicitacoes/5
		public string Get(int id)
		{
			return "value";
		}

		[HttpPost]
		[Route("pessoa-fisica")]
		public HttpResponseMessage Post([FromBody]SolicitacaoDeClientePessoaFisicaFisicaViewModel modelo)
		{
			var response  = new HttpResponseMessage();

			var nome = new Nome(modelo.Nome);
			var documento = new Documento(modelo.Documento);
			var rg = new RG(modelo.RG);
			Cliente cliente = new PessoaFisica(nome, documento, rg);

			//var solicitacao = new SolicitacaoDeCliente(cliente);

			//_servicoSolicitacao.Executar(solicitacao);

			//if (!_servicoSolicitacao.EstaValido)
			//{
			//	response = Request.CreateResponse(HttpStatusCode.BadRequest, new { estaValido = false, titulo = "Operação canceleada.", mensagens = _servicoSolicitacao.Notificacoes });
			//}
			//else
			//{
			//	response = Request.CreateResponse(HttpStatusCode.Created, new { estaValido = true, titulo = "Operação sucesso." });
			//}

			return response;
		}

		// PUT: api/Solicitacoes/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Solicitacoes/5
		public void Delete(int id)
		{
		}
	}
}
