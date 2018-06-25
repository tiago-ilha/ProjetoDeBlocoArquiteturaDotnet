using System;

namespace PB.Solicitacoes.DomainModel
{
    public interface ITransacao : IDisposable
    {
         void AbrirTransacao();
         void Comitar();
         void Desfazer();
    }
}