using System;

namespace Alfa.Core.Transacao
{
	public interface UnidadeDeTrabalho : IDisposable
	{
		void AbrirTransacao();
		void Comitar();
		void Desfazer();
	}
}
