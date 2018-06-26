using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades
{
	public class Produto
	{
		public Guid SoliclitacaoClienteId { get; private set; }
		public SolicitacaoDeCliente Solicitacao { get; private set; }
	}
}
