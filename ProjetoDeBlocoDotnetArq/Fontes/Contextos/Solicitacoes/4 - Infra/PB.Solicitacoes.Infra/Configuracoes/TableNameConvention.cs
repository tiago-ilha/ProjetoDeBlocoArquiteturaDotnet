using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table($"[dbo].[{instance.EntityType.Name}]");
        }
    }
}