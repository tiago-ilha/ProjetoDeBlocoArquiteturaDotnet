using FluentNHibernate.Mapping;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");

            Id(x => x.Id).Column("IdCliente").Not.Nullable().GeneratedBy.Identity();

             Component<Nome>(propriedade => propriedade.Nome, mapeamento =>{
                 mapeamento.Map(x => x.NomeCompleto).Length(100);
             });

             Map(x => x.Documento).Column("Documento").Length(14).Not.Nullable().Unique();

             HasOne(x => x.Solicitacao).Constrained();
        }
    }
}