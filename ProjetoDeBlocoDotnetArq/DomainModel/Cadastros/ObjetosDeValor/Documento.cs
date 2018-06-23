using System;
namespace DomainModel.Cadastros.ObjetosDeValor
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
