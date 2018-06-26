using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PB.Solicitacoes.Servico.ViewModels
{
	[DataContract]
	public class SolicitacaoDeClientePessoaViewModel
	{
		[DataMember]
		public string TipoCliente { get; set; }

		[DataMember]
		public string Nome { get; set; }

		[DataMember]
		public string Documento { get; set; }

		[DataMember]
		public string RG { get; set; }

		//[DataMember]
		//public EnderecoViewModel Endereco { get; set; }
	}
}