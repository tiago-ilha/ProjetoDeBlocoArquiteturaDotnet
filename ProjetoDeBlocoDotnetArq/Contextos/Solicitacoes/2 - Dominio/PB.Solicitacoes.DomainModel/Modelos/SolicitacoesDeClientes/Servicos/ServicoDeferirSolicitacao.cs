using Alfa.Core.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Servicos
{
	public interface ServicoDeferirSolicitacao : Servico
	{
		void Executar(Guid idSolicitacao);
	}
}
