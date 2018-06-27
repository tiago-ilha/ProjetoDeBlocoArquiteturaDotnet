using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Interfaces;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades
{
	public class ContaEspecialEletronica : ContaCorrente, PossuiLimite
	{
		public decimal LimiteDeCredito { get; private set; }
	}
}
