using FluentNHibernate.Mapping;
using PB.Solicitacoes.DomainModel.Modelos.Entidades;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
    public class PessoaFisicaMap : SubclassMap<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            Table("PessoaFisica");

            KeyColumn("IdCliente");
        }
    }
}