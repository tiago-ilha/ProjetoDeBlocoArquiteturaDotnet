using System;
namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
    public abstract class Documento
    {
        public Documento(string numeroDocumento)
        {
            NumeroDocumento = numeroDocumento;
        }

        public string NumeroDocumento { get; }
    }
}
