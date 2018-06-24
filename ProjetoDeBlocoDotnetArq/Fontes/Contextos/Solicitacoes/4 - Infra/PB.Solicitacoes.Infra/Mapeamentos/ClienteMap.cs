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
                 mapeamento.Map(x => x.NomeCompleto);
             });

             Map(x => x.Documento).Column("Documento").Not.Nullable();
        }
    }
}