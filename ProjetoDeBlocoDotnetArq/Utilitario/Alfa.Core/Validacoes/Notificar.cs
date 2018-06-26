using System.Collections.Generic;
using System.Linq;

namespace Alfa.Core.Validacoes
{
	public abstract class Notificar
	{
		private IList<Notificacao> _notificacoes;

		public Notificar()
		{
			_notificacoes = new List<Notificacao>();
		}

		public bool EstaValido { get { return _notificacoes.Count == 0; } }
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
