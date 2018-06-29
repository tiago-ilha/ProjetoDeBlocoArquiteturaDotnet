using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades
{
	public class PessoaJuridica : Cliente
	{
		public PessoaJuridica(Nome nome, Documento documento)
			: base(nome, documento)
		{

		}
	}
}
