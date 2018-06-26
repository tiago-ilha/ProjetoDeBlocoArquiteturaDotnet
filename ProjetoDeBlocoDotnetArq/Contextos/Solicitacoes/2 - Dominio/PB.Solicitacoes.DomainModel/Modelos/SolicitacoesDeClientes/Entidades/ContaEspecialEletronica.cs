using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades
{
	public class ContaEspecialEletronica : ContaCorrente, PossuiLimite
	{
		public decimal LimiteDeCredito { get; private set; }
	}
}
