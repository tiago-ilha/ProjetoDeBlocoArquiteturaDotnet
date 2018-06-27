using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Interfaces
{
	public interface PossuiLimite
	{
		decimal LimiteDeCredito { get; }
	}
}
