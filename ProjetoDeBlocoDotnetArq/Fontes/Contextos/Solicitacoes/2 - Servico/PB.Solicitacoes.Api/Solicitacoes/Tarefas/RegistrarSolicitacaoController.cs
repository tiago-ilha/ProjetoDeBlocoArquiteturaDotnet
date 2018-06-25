using Microsoft.AspNetCore.Mvc;
using PB.Solicitacoes.Api.ViewModels;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.Servicos;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.Api.Solicitacoes.Tarefas
{
    [Route("api/registrar-solicitacao")]
    [ApiController]
    public class RegistrarSolicitacaoController : Controller
    {
        private readonly ServicoCadastrarSolicitacao _servico;

        public RegistrarSolicitacaoController(ServicoCadastrarSolicitacao servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] RegistrarSolicitacaoViewModel modelo)
        {
            Cliente cliente;

            if(modelo.TipoCliente == "PF")
            {
                var nome = new Nome(modelo.NomeCompleto);

                cliente = new PessoaFisica(
                    nome, 
                    modelo.Documento);
            }
            else if(modelo.TipoCliente == "PJ")
            {
                var razaoSocial = new Nome(modelo.NomeCompleto);

                cliente = new PessoaJuridica(
                    razaoSocial,
                    modelo.Documento
                );
            }
            else 
                cliente = null;

            if(cliente == null)
            {
                return Json(new {estaValido = false, titulo = "Operação não realizada.", mensagem = "Não foi possível realizar a operacao"});
            }
            else
            {
                var solicitacao = new SolicitacaoDoCliente(cliente);

                _servico.Executar(solicitacao);

                return Json(new {});
            }
        }
    }
}