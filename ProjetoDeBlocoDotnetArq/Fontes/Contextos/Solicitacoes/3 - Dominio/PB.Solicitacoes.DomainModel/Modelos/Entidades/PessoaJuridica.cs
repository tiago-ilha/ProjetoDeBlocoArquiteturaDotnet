using System;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class PessoaJuridica : Cliente
    {
        public PessoaJuridica(Nome razaoSocial, string documento) : 
            base(razaoSocial, documento)
        {
        }
    }
}
