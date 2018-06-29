using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.DomainModel.ObjetosDeValor
{
	public class Documento
	{
		internal Documento() { }

		public Documento(string numeroDocumento)
		{
			this.NumeroDocumento = numeroDocumento;
		}

		public string NumeroDocumento { get; set; }
	}
}
