
namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
	public class Nome
	{
		private Nome nome;

		public Nome(string nomeCompleto)
		{
			this.NomeCompleto = nomeCompleto;
		}

		public string NomeCompleto { get; private set; }
	}
}
