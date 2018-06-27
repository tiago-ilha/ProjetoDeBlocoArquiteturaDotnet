using Alfa.Core.Validacoes;
using PB.Solicitacoes.DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.Modelos
{
	public class Solicitacao : Notificar
	{
		public Solicitacao()
		{
			this.IdSolicitacao = Guid.NewGuid();

			this.Solicitar();
		}

		public Guid IdSolicitacao { get; private set; }

		public DateTime? DataDeSolicitacao { get; private set; }
		public DateTime? DataDeAnalise { get; private set; }
		public DateTime? DataDeDefericao { get; private set; }
		public TipoSituacaoSolicitacaoEnum Situacao { get; private set; }

		public virtual void Solicitar()
		{
			this.DataDeSolicitacao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Solicitado;
		}

		public virtual void Analisar()
		{
			this.DataDeAnalise = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.EmAnalise;
		}

		public virtual void Deferir()
		{
			this.DataDeDefericao = DateTime.Now;
			this.Situacao = TipoSituacaoSolicitacaoEnum.Deferido;
		}
	}
}
