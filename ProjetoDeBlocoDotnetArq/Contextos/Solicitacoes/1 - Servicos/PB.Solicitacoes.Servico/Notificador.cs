using Alfa.Core.Validacoes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PB.Solicitacoes.Servico
{
	[DataContract]
	public abstract class Notificador : INotificar
	{
		private IList<Notificacao> _notificacoes;

		public Notificador()
		{
			_notificacoes = new List<Notificacao>();
		}

		[DataMember]
		public bool EstaValido { get { return _notificacoes.Count == 0; } }

		[DataMember]
		public IReadOnlyCollection<Notificacao> Notificacoes { get { return _notificacoes.ToArray(); } }

		public void AdicionarNotificacao(string propriedade, string mensagem)
		{
			_notificacoes.Add(new Notificacao(propriedade, mensagem));
		}

		public void AdicionarNotificacao(string mensagem)
		{
			_notificacoes.Add(new Notificacao(mensagem));
		}

		public void MesclarNotificacoes(IEnumerable<Notificacao> notificacoes)
		{
			notificacoes.ToList().ForEach(x => AdicionarNotificacao(x.Prorpiedade, x.Mensagem));
		}

		public void MesclarNotificacoes(Notificar notificar)
		{
			MesclarNotificacoes(notificar);
		}
	}
}