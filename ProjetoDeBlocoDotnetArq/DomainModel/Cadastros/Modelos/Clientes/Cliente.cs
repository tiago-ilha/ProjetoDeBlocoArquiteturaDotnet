using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Cadastros.ObjetosDeValor;

namespace DomainModel.Cadastros.Modelos.Clientes
{
    public abstract class Cliente
    {
        private IList<ProdutoDoCliente> _produtos;

        protected Cliente()
        {
            _produtos = new List<ProdutoDoCliente>();
        }

        protected Cliente(Nome nome, Documento documento, Endereco endereco) : this()
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

        public ICollection<ProdutoDoCliente> ProdutosDoCliente => _produtos.ToArray();

        public void AderirProdutos(ProdutoDoCliente produtoDoCliente)
        {
            _produtos.Add(produtoDoCliente);
        }
    }
}
