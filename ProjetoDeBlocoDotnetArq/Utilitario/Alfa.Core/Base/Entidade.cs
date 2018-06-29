using Alfa.Core.Validacoes;
using System;

namespace Alfa.Core.Base
{
	public abstract class Entidade : Notificar
	{
		public Entidade()
		{
			Id = Guid.NewGuid();
		}

		public Guid Id { get; set; }
	}
}
