﻿using System;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.Enums;

namespace PB.Solicitacoes.DomainModel.Modelos
{
    public class SolicitacaoDeCliente
    {
        protected SolicitacaoDeCliente() { }

        public SolicitacaoDeCliente(Cliente cliente) : this()
        {
            Cliente = cliente;

            this.Solicitar();
        }

        public Guid Id { get; private set; }
        public Cliente Cliente { get; private set; }

        public TipoSituacaoSolicitacaoEnum Situacao { get; private set; }

        public DateTime? DataDeSolicitacao { get; private set; }
        public DateTime? DataDeAnalise { get; private set; }
        public DateTime? DataDeDefericao { get; private set; }

        public void Solicitar()
        {
            this.DataDeSolicitacao = DateTime.Now;
            this.Situacao = TipoSituacaoSolicitacaoEnum.Solicitado;
        }

        public void Analisar()
        {
            this.DataDeAnalise = DateTime.Now;
            this.Situacao = TipoSituacaoSolicitacaoEnum.EmAnalise;
        }

        public void Deferir()
        {
            this.DataDeDefericao = DateTime.Now;
            this.Situacao = TipoSituacaoSolicitacaoEnum.Deferido;
        }
    }
}