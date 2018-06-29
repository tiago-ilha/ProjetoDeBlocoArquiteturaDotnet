using Alfa.Core.Base;
using Alfa.Core.Repositorios;
using Alfa.Core.Transacao;
using Alfa.Core.Validacoes;
using System;

namespace Alfa.Core.Servicos
{
	public abstract class ServicoBase<TAgregador> : Notificar, IServico<TAgregador> where TAgregador : Agregador
	{
		protected UnidadeDeTrabalho _transacao;
		protected IRepositorio<TAgregador> _repositorio;

		public ServicoBase(
			UnidadeDeTrabalho transacao,
			IRepositorio<TAgregador> repositorio)
		{
			this._transacao = transacao;
			this._repositorio = repositorio;
		}

		protected virtual void RegistrarOperacao(TAgregador agregador)
		{
			if (EstaValido)
			{
				_repositorio.Salvar(agregador);
				_transacao.Comitar();
			}
			else
			{
				MesclarNotificacoes(agregador);
				_transacao.Desfazer();
			}
		}

		public virtual void Executar(TAgregador agregador)
		{
			_transacao.AbrirTransacao();

			try
			{
				RegistrarOperacao(agregador);
			}
			catch (Exception ex)
			{
                ex.Message.ToString();
				_transacao.Desfazer();
			}
			finally
			{
				_transacao.Dispose();
			}
		}
	}
}
