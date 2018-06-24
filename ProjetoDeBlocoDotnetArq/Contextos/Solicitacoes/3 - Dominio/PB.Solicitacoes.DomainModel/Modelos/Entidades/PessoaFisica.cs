using System;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class PessoaFisica : Cliente
    {
        protected PessoaFisica(Nome nome,RG rg, CPF documento, Endereco endereco) :
            base(nome, documento, endereco)
        {
        }

        public RG RG { get; private set; }
    }
}
