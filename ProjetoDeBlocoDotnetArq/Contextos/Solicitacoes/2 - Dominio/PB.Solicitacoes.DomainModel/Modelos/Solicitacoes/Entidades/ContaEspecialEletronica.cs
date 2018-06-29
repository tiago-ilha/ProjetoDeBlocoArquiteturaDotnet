using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Interfaces;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades
{
	public class ContaEspecialEletronica : ContaCorrente, PossuiLimite
	{
		public decimal LimiteDeCredito { get; private set; }
	}
}
