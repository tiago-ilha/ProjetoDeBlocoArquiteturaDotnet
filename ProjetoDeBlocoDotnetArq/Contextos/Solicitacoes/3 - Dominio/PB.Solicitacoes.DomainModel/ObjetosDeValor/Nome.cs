using System;
namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
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
