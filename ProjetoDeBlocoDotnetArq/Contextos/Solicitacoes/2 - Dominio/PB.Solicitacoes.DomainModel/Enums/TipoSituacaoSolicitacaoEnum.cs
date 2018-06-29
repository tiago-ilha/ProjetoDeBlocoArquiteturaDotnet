using Alfa.Core.Base;

namespace PB.Solicitacoes.DomainModel.Enums
{
	public class TipoSituacaoSolicitacaoEnum : Enumerador
	{
		public static TipoSituacaoSolicitacaoEnum NaoInformado = new TipoSituacaoSolicitacaoEnum(0, "NaoInformado");

		public static TipoSituacaoSolicitacaoEnum Rascunho = new TipoSituacaoSolicitacaoEnum(1, "Rascunho");

		public static TipoSituacaoSolicitacaoEnum Solicitado = new TipoSituacaoSolicitacaoEnum(2, "Solicitado");

		public static TipoSituacaoSolicitacaoEnum Deferido = new TipoSituacaoSolicitacaoEnum(3, "Deferido");

		public TipoSituacaoSolicitacaoEnum(int valor, string descricao)
			: base(valor, descricao) { }
	}
}
