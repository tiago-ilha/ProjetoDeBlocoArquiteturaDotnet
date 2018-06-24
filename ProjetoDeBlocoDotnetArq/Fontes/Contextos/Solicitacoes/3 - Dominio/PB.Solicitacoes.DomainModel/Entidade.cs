using System;

namespace PB.Solicitacoes.DomainModel
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}