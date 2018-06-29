using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades
{
	public class Cliente
	{
		internal Cliente()
		{

		}

		public Cliente(Nome nome, Documento documento) : this()
		{
			this.Nome = nome;
			this.Documento = documento;
		}

		public Guid IdCliente { get; set; }
		public Nome Nome { get; set; }
		public Documento Documento { get; set; }

		public Guid IdSolicitacao { get; set; }
		public Solicitacao Solicitacao { get; set; }
	}
}
