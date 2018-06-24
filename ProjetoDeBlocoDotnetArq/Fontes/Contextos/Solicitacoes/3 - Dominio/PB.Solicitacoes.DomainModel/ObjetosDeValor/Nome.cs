namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
    public class Nome
    {
        protected Nome() {}

        public Nome(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        public virtual string NomeCompleto { get; private set; }
    }
}