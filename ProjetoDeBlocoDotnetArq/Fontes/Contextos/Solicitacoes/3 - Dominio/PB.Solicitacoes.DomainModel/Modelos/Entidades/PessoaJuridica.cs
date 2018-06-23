using System;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class PessoaJuridica : Cliente
    {
        protected PessoaJuridica(RazaoSocial razaoSocial, NomeFantasia nomeFantasia, CNPJ cnpj, Endereco endereco) :
            base(razaoSocial, cnpj, endereco)
        {
        }
    }
}
