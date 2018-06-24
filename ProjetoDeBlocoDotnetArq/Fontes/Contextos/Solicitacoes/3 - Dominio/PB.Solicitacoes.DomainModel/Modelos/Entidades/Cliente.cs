using System;
using System.Collections.Generic;
using System.Linq;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;

namespace PB.Solicitacoes.DomainModel.Modelos.Entidades
{
    public class Cliente : Entidade
    {
        // private IList<Endereco> _enderecos;

        public Cliente()
        {
            
            // _enderecos = new List<Endereco>();
        }

        public Cliente(Nome nomeCompleto, string documento)
        {
            Nome = nomeCompleto;
            Documento = documento;
        }

        public virtual Nome Nome { get; protected set; }
        public virtual string Documento { get; protected set; }

        public ICollection<SolicitacaoDoCliente> Solicitacoes { get; private set; }

        // public virtual ICollection<Endereco> Enderecos => _enderecos.ToArray();

        // public virtual void AdicionarEndereco(Endereco endereco)
        // {
        //     _enderecos.Add(endereco);
        // }
    }
}