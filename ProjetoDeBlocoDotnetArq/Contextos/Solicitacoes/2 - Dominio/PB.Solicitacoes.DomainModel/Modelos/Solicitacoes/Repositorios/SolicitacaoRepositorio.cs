using Alfa.Core.Repositorios;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Filtros;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Queries.Comandos;
using System.Linq;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Repositorios
{
	public interface SolicitacaoRepositorio : IRepositorio<Solicitacao>
	{
		IQueryable<ListagemDeSolicitacoesComando> Listar(FiltroDeListagemDeSolicitacoes filtro);
	}
}
