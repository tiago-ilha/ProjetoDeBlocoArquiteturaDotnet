using System;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public abstract class Cliente
    {
        protected Cliente() { }

        protected Cliente(Nome nome,Documento documento, Endereco endereco) : this()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Endereco = endereco;
        }

        public Guid Id { get; protected set; }
        public Nome Nome { get; protected set; }

        public Documento Documento { get; protected set; }

        public Endereco Endereco { get; protected set; }
    }
}
