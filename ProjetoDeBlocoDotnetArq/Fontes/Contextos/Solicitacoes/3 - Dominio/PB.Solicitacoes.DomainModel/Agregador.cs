using System.Collections.Generic;

namespace PB.Solicitacoes.DomainModel
{
    public abstract class Agregador : Entidade
    {
        private readonly List<IEventoDeDominio> _eventosDeDominio = new List<IEventoDeDominio>();
        public virtual IReadOnlyList<IEventoDeDominio> EventosDeDominio => _eventosDeDominio;

        protected virtual void AdicionarEventosDeDominio(IEventoDeDominio evento) => _eventosDeDominio.Add(evento);
        public virtual void LimparEventos() => _eventosDeDominio.Clear();
    }
}