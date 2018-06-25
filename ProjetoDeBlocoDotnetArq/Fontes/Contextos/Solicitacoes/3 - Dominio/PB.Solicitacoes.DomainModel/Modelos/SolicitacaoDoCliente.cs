using System;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.Enums;

namespace PB.Solicitacoes.DomainModel.Modelos
{
    public class SolicitacaoDoCliente : Agregador
    {
        protected SolicitacaoDoCliente() { }

        public SolicitacaoDoCliente(Cliente cliente) : this()
        {
            this.Cliente = cliente;

            this.Solicitar();
        }

        public virtual Cliente Cliente { get; private set; }

        public virtual DateTime? DataDeSolicitacao { get; private set; }
        public virtual DateTime? DataDeAnalise { get; private set; }
        public virtual DateTime? DataDeDefericao { get; private set; }
        public virtual TipoSituacaoSolicitacaoEnum Situacao { get; private set; }

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
