using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.Servico.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PB.Solicitacoes.Servico
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICasoDeUsoSolicitacao" in both code and config file together.
	[ServiceContract]
	public interface ICasoDeUsoSolicitacao
	{
		[OperationContract]
		void ResgistrarSolicitacao(SolicitacaoDeClientePessoaViewModel modelo);
	}
}
