
namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
	public class Nome
	{
		private Nome nome;

		internal Nome()
		{

		}

		public Nome(string nomeCompleto)
		{
			this.NomeCompleto = nomeCompleto;
		}

		public string NomeCompleto { get; set; }
	}
}
