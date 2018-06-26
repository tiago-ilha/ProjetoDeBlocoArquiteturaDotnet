
namespace Alfa.Core.Validacoes
{
	public class Notificacao
	{
		public Notificacao(string propriedade, string mensagem)
		{
			this.Prorpiedade = propriedade;
			this.Mensagem = mensagem;
		}

		public Notificacao(string mensagem) : this(null, mensagem) { }

		public string Prorpiedade { get; private set; }
		public string Mensagem { get; private set; }
	}
}
