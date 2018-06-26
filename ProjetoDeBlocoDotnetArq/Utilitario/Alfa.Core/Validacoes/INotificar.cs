using System.Collections.Generic;

namespace Alfa.Core.Validacoes
{
	public interface INotificar
	{
		bool EstaValido { get; }
		IReadOnlyCollection<Notificacao> Notificacoes { get; }

		void AdicionarNotificacao(string propriedade, string mensagem);

		void AdicionarNotificacao(string mensagem);

		void MesclarNotificacoes(IEnumerable<Notificacao> notificacoes);

		void MesclarNotificacoes(Notificar notificar);
	}
}
