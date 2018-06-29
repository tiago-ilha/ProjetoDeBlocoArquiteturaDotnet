using Alfa.Core.Base;

namespace Alfa.Core.Servicos
{
	public interface IServico<TAgregador> where TAgregador : Agregador
	{
		void Executar(TAgregador agregador);
	}
}
