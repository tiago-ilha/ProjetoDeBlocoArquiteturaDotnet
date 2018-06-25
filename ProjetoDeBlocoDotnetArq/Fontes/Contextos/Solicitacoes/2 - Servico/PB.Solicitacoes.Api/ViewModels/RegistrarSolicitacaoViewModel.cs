namespace PB.Solicitacoes.Api.ViewModels
{
    public class RegistrarSolicitacaoViewModel
    {
        public string TipoCliente { get; set; }
        public string NomeCompleto { get; set; }
        public string Documento { get; set; }
        public EnderecoViewModel Endereco { get; set; }

    }
}