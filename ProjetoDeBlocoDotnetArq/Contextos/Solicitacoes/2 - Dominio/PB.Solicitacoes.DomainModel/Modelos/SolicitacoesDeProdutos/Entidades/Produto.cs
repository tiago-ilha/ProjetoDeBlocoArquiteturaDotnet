using System;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeProdutos.Entidades
{
	public abstract class Produto
	{
		public Guid IdSolicitacaoDeProduto { get; private set; }
		public SolicitacaoDeProduto Solicitacao { get; private set; }
	}
}
