using Alfa.Core.Validacoes;
using System.Runtime.Serialization;

namespace PB.Solicitacoes.Servico
{
	[DataContract]
	public class ResultadoOperacao<TEntidade> where TEntidade : class
	{
		[DataMember]
		public TEntidade EntidadeDeRetorno { get; set; }

		[DataMember]
		public Notificador Notificacao { get; set; }
	}
}