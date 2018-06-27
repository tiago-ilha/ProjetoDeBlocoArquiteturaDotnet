using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Enums;
using System;
using System.Collections.Generic;

namespace PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes
{
	public class SolicitacaoDeCliente  : Notificar
	{
		public SolicitacaoDeCliente(Cliente cliente)
		{
			this.Id = Guid.NewGuid();

			this.Cliente = cliente;
			//this.Produto = produto;

			this.Solicitar();
		}

		public Guid Id { get; private set; }
		public Cliente Cliente { get; private set; }
		//public Produto Produto { get; private set; }

		public DateTime? DataDeSolicitacao { get; private set; }
		public DateTime? DataDeAnalise { get; private set; }
		public DateTime? DataDeDefericao { get; private set; }
		public TipoSituacaoSolicitacaoEnum Situacao { get; private set; }

		public virtual void Solicitar()
		{
			this.DataDeSolicitacao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Solicitado;
		}

		public virtual void Analisar()
		{
			this.DataDeAnalise = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.EmAnalise;
		}

		public virtual void Deferir()
		{
			this.DataDeDefericao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Deferido;
		}
		
	}
}
