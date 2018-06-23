using System;
using DomainModel.Cadastros.ObjetosDeValor;

namespace DomainModel.Cadastros.Modelos.Clientes
{
    public class PessoaJuridica : Cliente
    {
        protected PessoaJuridica(RazaoSocial razaoSocial, NomeFantasia nomeFantasia, CNPJ cnpj, Endereco endereco) : 
            base(razaoSocial, cnpj, endereco)
        {
        }
    }
}
