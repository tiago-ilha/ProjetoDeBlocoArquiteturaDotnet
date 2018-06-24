namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
    public class Endereco
    {
        public Endereco(string cep, string logradouro, int numero, int? complemento, string bairro, string cidade, string estado)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public virtual string Cep { get; private set; }
        public virtual string Logradouro { get; private set; }
        public virtual int Numero { get; private set; }
        public virtual int? Complemento { get; private set; }
        public virtual string Bairro { get; private set; }
        public virtual string Cidade { get; private set; }
        public virtual string Estado { get; private set; }
    }
}