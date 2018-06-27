using Alfa.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Enums
{
	public class TipoSituacaoSolicitacaoEnum : Enumerador
	{
		public static TipoSituacaoSolicitacaoEnum NaoInformado = new TipoSituacaoSolicitacaoEnum(0, "NaoInformado");

		public static TipoSituacaoSolicitacaoEnum Solicitado = new TipoSituacaoSolicitacaoEnum(1, "Solicitado");

		public static TipoSituacaoSolicitacaoEnum EmAnalise = new TipoSituacaoSolicitacaoEnum(2, "EmAnalise");

		public static TipoSituacaoSolicitacaoEnum Deferido = new TipoSituacaoSolicitacaoEnum(3, "Deferido");

		public TipoSituacaoSolicitacaoEnum(int valor, string descricao)
			: base(valor, descricao) { }
	}
}
