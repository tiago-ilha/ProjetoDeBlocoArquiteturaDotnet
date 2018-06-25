using System;
using System.Collections.Generic;
using System.Linq;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class Cliente : Entidade
    {
        public Cliente()
        {
        }

        public Cliente(Nome nomeCompleto, string documento)
        {
            Nome = nomeCompleto;
            Documento = documento;
        }

        public virtual Nome Nome { get; protected set; }
        public virtual string Documento { get; protected set; }

        public virtual SolicitacaoDoCliente Solicitacao { get; private set; }
    }
}