using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Specs
{
    public static class  SolicitacaoCreditoSpec
    {
        public static bool SolictacaoDeRisco(this SolicitacaoCredito solicitacao)
        {
            return solicitacao.Avaliacao.Risco == Enums.TipoRisco.Alto &&
                   solicitacao.Valor <= 5000;
        }

        public static Expression<Func<SolicitacaoCredito, bool>> QuerySolictacaoDeRisco
        {
            get
            {
                return x => x.SolictacaoDeRisco();
            }
        }
    }
}
