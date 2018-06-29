using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Queries.Comandos
{
	public class ListagemDeSolicitacoesComando
	{
		public Guid Id;
		public string NomeCompleto;
		public string Documento;
		public DateTime DataDeCadastro;
		public DateTime? DataDeSolicitacao;
		public DateTime? DataDeDefericao;
		public string Situacao;
	}
}
