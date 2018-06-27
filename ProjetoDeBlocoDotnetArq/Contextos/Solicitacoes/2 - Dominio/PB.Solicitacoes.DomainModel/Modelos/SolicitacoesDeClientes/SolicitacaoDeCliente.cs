using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes
{
	public class SolicitacaoDeCliente : Solicitacao
	{
		public SolicitacaoDeCliente(Cliente cliente) : base()
		{
			
		}
		
		public Cliente Cliente { get; private set; }
	}
}
