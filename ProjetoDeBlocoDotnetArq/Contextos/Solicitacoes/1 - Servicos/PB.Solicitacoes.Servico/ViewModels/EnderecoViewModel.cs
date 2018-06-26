using System.Runtime.Serialization;

namespace PB.Solicitacoes.Servico.ViewModels
{
	public class EnderecoViewModel
	{
		[DataMember]
		public string Cep { get; set; }

		[DataMember]
		public string Logradouro { get; set; }

		[DataMember]
		public int Numero { get; set; }

		[DataMember]
		public int? Complemento { get; set; }

		[DataMember]
		public string Bairro { get; set; }

		[DataMember]
		public string Cidade { get; set; }

		[DataMember]
		public string Estado { get; set; }
	}
}