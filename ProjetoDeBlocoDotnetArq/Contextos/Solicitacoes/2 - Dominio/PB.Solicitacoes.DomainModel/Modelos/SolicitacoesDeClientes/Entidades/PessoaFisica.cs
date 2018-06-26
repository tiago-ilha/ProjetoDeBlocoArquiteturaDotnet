using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades
{
	public class PessoaFisica : Cliente
	{
		public PessoaFisica(Nome nome, Documento documento, RG rg)
			: base(nome, documento)
		{
			this.RG = rg;
		}

		public RG RG { get; private set; }
	}
}
