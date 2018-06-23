using System;
using DomainModel.Cadastros.ObjetosDeValor;

namespace DomainModel.Cadastros.Modelos
{
    public abstract class Pessoa
    {
        public Pessoa(string nome, string documento, Endereco endereco)
        {
            Nome = nome;
            Documento = documento;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }

        public Endereco Endereco { get; private set; }
    }
}
