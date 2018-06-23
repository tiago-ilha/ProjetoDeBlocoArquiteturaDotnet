using System;
namespace DomainModel.Cadastros.ObjetosDeValor
{
    public class Nome
    {
        public Nome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        public string NomeCompleto { get; }
    }
}
