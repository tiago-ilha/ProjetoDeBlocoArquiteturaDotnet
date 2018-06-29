using Alfa.Core.Filtros;
using PB.Solicitacoes.DomainModel.Enums;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Entidades;
using PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Queries.Comandos;
using PB.Solicitacoes.DomainModel.ObjetosDeValor;
using System;
using System.Linq.Expressions;

namespace PB.Solicitacoes.DomainModel.Modelos.Solicitacoes.Filtros
{
	public class FiltroDeListagemDeSolicitacoes : FiltroDeBuscaAbstrato<Solicitacao>
	{
		public string NomeCompleto { get; set; }
		public string Documento { get; set; }

		public override Expression<Func<Solicitacao, bool>> AplicarFiltros()
		{
			return x => x.Situacao.Descricao == TipoSituacaoSolicitacaoEnum.Rascunho.Descricao ||
					   x.Situacao.Descricao == TipoSituacaoSolicitacaoEnum.Solicitado.Descricao ||
					   x.Situacao.Descricao == TipoSituacaoSolicitacaoEnum.Deferido.Descricao;
        }

		//public override Expression<Func<Solicitacao, ListagemDeSolicitacoesComando>> AplicarProjecao()
		//{
		//	return x => new ListagemDeSolicitacoesComando
		//	{
		//		Id = x.Id,
		//		NomeCompleto = x.Cliente.Nome.NomeCompleto,
		//		Documento = x.Cliente.Documento.NumeroDocumento,
		//		DataDeCadastro = x.DataDeCadastro,
		//		DataDeSolicitacao = x.DataDeSolicitacao,
		//		DataDeDefericao = x.DataDeDefericao,
		//		Situacao = x.Situacao.Descricao

		//		//Id = x.Id,
		//		//Cliente = new Cliente
		//		//{
		//		//	Nome = new Nome
		//		//	{
		//		//		NomeCompleto = x.Cliente.Nome.NomeCompleto
		//		//	},
		//		//	Documento = new Documento
		//		//	{
		//		//		NumeroDocumento = x.Cliente.Documento.NumeroDocumento
		//		//	}
		//		//},
		//		//DataDeCadastro = x.DataDeCadastro,
		//		//DataDeSolicitacao = x.DataDeSolicitacao,
		//		//DataDeDefericao = x.DataDeDefericao,
		//	};
		//}
	}
}
