using System;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class PessoaJuridica : Cliente
    {
        protected PessoaJuridica(Nome nomeCompleto, string nomeFantasia, string documento) : 
            base(nomeCompleto, documento)
        {
            // this.NomeFantasia = nomeFantasia;
        }

        // public string NomeFantasia { get; private set; }
    }
}
