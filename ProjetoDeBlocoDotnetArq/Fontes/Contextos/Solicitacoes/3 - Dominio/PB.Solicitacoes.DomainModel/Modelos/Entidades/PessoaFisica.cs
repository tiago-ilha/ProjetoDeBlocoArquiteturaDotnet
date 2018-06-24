using System;
using PB.Solicitacoes.DomainModel.Modelos.Enums;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class PessoaFisica : Cliente
    {
        protected PessoaFisica(Nome nomeCompleto, string documento) : base(nomeCompleto, documento)
        {
        }

        // public string RG { get; private set; }
        // public SexoEnum Sexo { get; private set; }
    }
}
