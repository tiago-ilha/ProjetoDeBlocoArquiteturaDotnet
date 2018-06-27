using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using System;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades
{
	public class Cliente
	{
		public Cliente(Nome nome, Documento documento)
		{
			this.Nome = nome;
			this.Documento = documento;
		}

		public Guid IdSoliclitacaoCliente { get; private set; }
		public Nome Nome { get; private set; }
		public Documento Documento { get; private set; }

		public SolicitacaoDeCliente Solicitacao { get; private set; }
	}
}
