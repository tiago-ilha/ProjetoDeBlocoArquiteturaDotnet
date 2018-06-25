using FluentNHibernate.Mapping;
using PB.Solicitacoes.DomainModel.Modelos;
using PB.Solicitacoes.DomainModel.Modelos.Enums;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class SolicitacaoDeClienteMap : ClassMap<SolicitacaoDoCliente>
    {
        public SolicitacaoDeClienteMap()
        {
            Table("SolicitacaoDeCliente");

            Id(x => x.Id).Not.Nullable().GeneratedBy.Identity();

            Map(x => x.DataDeSolicitacao);
            Map(x => x.DataDeAnalise);
            Map(x => x.DataDeDefericao);

            Map(x => x.Situacao).CustomType<TipoSituacaoSolicitacaoEnum>();

            HasOne(x => x.Cliente).Cascade.All();
        }
    }
}