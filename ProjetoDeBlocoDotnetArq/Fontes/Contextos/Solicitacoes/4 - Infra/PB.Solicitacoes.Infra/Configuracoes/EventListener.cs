using System.Threading;
using System.Threading.Tasks;
using NHibernate.Event;
using PB.Solicitacoes.DomainModel;

namespace PB.Solicitacoes.Infra.Configuracoes
{
    internal class EventListener :
        IPostInsertEventListener,
        IPostDeleteEventListener,
        IPostUpdateEventListener,
        IPostCollectionUpdateEventListener
    {
        public void OnPostUpdate(PostUpdateEvent ev) => DispatchEvents(ev.Entity as Agregador);

        public void OnPostDelete(PostDeleteEvent ev) => DispatchEvents(ev.Entity as Agregador);

        public void OnPostInsert(PostInsertEvent ev) => DispatchEvents(ev.Entity as Agregador);

        public void OnPostUpdateCollection(PostCollectionUpdateEvent ev) => DispatchEvents(ev.AffectedOwnerOrNull as Agregador);

        private void DispatchEvents(Agregador aggregateRoot)
        {
            if (aggregateRoot == null)
                return;

            foreach (IEventoDeDominio eventoDoDominio in aggregateRoot.EventosDeDominio)
                EventosDeDominio.DespacharEvento(eventoDoDominio);

            aggregateRoot.LimparEventos();
        }

        public Task OnPostInsertAsync(PostInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostDeleteAsync(PostDeleteEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostUpdateAsync(PostUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task OnPostUpdateCollectionAsync(PostCollectionUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

}