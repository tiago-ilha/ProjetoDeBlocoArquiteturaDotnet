using System;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades
{
	public class Produto
	{
		public Guid IdProduto { get; private set; }

		public Guid IdSolicitacao { get; set; }
		public Solicitacao Solicitacao { get; private set; }
	}
}
