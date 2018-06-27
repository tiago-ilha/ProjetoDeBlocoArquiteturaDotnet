using PB.Solicitacoes.DomainModel.Modelos.SolicitacoesDeClientes.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Solicitacoes.Infra.Mapeamentos
{
	public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>, IMapeamento
	{
		public PessoaJuridicaMap()
		{
		}
	}
}
