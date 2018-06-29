using Alfa.Core.Transacao;
using PB.Solicitacoes.Infra.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.Infra.Transacao
{
	public class UnidadeDeTrabalhoImp : UnidadeDeTrabalho
	{
		private ContextoDeSolicitacao _contexto;
		private DbContextTransaction _transacao;

		public UnidadeDeTrabalhoImp(ContextoDeSolicitacao contexto)
		{
		_contexto = contexto;
		}

		public void AbrirTransacao()
		{
			_transacao = _contexto.Database.BeginTransaction();
		}

		public void Comitar()
		{
			_contexto.SaveChanges();
			_transacao.Commit();
		}

		public void Desfazer()
		{
			_transacao.Rollback();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing && _transacao != null)
					_contexto.Dispose();
			}

			this.disposed = true;
		}
	}
}
