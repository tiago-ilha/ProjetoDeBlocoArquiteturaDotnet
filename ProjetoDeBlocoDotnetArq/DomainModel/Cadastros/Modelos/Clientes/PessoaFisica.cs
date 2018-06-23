using System;
using DomainModel.Cadastros.ObjetosDeValor;

namespace DomainModel.Cadastros.Modelos.Clientes
{
    public class PessoaFisica : Cliente
    {
        protected PessoaFisica(Nome nome, CPF documento, Endereco endereco) : 
            base(nome, documento, endereco)
        {
        }
    }
}
