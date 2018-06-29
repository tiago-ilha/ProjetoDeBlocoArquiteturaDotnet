using Alfa.Core.Base;
using PB.Solicitacoes.DomainModel.Enums;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes
{
	public class Solicitacao : Agregador
	{
		private IList<Cliente> _clientes;
		private IList<Produto> _produtos;

		public Solicitacao()
			: base()
		{
			this.Rascunhar();

			_clientes = new List<Cliente>();
			_produtos = new List<Produto>();
		}

		public ICollection<Cliente> Clientes
		{
			get
			{
				return _clientes.ToArray();
			}
		}

		public ICollection<Produto> Produtos
		{
			get
			{
				return _produtos.ToArray();
			}
		}

		public DateTime DataDeCadastro { get; set; }
		public DateTime? DataDeSolicitacao { get; set; }
		public DateTime? DataDeDefericao { get; set; }
		public TipoSituacaoSolicitacaoEnum Situacao { get; set; }

		public void AdicionarCliente(Cliente cliente)
		{
			_clientes.Add(cliente);
		}

		public void AdicionarProduto(Produto produto)
		{
			_produtos.Add(produto);
		}

		public virtual void Rascunhar()
		{
			this.DataDeCadastro = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Rascunho;
		}

		public virtual void Solicitar()
		{
			this.DataDeSolicitacao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Solicitado;
		}

		public virtual void Deferir()
		{
			this.DataDeDefericao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Deferido;
		}
	}
}
