using FluentNHibernate.Mapping;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class PessoaJuridicaMap : SubclassMap<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            Table("PessoaJuridica");

            KeyColumn("IdCliente");
        }
    }
}