
using Alfa.Core.Servicos;
namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos
{
	public interface ServicoCadastrarSolicitacaoCliente : Servico
	{
		void Executar(SolicitacaoDeCliente solicitacao);
	}
}
