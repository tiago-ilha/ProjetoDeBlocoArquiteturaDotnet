using Alfa.Core.Base;
using PB.Solicitacoes.DomainModel.Enums;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using System;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes
{
	public class Solicitacao : Agregador
	{
		internal Solicitacao()
		{

		}

		public Solicitacao(Cliente cliente) : base()
		{
			// TODO: Complete member initialization
			this.Cliente = cliente;

			this.Rascunhar();
		}

		public Cliente Cliente { get; set; }
		public Produto Produto { get; private set; }

		public DateTime DataDeCadastro { get; set; }
		public DateTime? DataDeSolicitacao { get; set; }
		public DateTime? DataDeDefericao { get; set; }
		public TipoSituacaoSolicitacaoEnum Situacao { get; set; }

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
