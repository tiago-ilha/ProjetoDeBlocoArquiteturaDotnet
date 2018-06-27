using Alfa.Core.Servicos;
using System;

namespace PB.Solicitacoes.DomainModel.Servicos
{
	public interface ServicoDeferirSolicitacao : Servico
	{
		void Executar(Guid idSolicitacao);
	}
}
