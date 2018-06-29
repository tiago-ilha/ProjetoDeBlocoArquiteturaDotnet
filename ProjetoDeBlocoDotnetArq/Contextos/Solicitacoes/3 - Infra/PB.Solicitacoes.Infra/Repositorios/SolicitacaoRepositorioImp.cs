using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Queries.Comandos;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios;
using PB.Solicitacoes.Infra.Configuracoes;
using System.Linq;

namespace PB.Solicitacoes.Infra.Repositorios
{
	public class SolicitacaoRepositorioImp : Repositorio<Solicitacao>, SolicitacaoRepositorio
	{
		public SolicitacaoRepositorioImp(ContextoDeSolicitacao contexto)
			: base(contexto)
		{
			_contexto = contexto;
		}

		public IQueryable<ListagemDeSolicitacoesComando> Listar(FiltroDeListagemDeSolicitacoes filtro)
		{
			return _contexto.Solicitacao.AsNoTracking().Where(filtro.AplicarFiltros()).Select(x => new ListagemDeSolicitacoesComando
			{
				Id = x.Id,
				//NomeCompleto = x.Cliente.Nome.NomeCompleto,
				//Documento = x.Cliente.Documento.NumeroDocumento,
				DataDeCadastro = x.DataDeCadastro,
				DataDeSolicitacao = x.DataDeSolicitacao,
				DataDeDefericao = x.DataDeDefericao,
				Situacao = x.Situacao.Descricao
			});
		}

	}
}
