
using Alfa.Core.Servicos;
namespace PB.Solicitacoes.DomainModel.Servicos
{
	public interface ServicoCadastrarSolicitacao<TAgregador> : Servico where TAgregador : class
	{
		void Executar(TAgregador solicitacao);
	}
}
