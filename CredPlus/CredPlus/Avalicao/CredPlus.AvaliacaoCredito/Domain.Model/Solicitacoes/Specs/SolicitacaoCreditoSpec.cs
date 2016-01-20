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
        public static bool SolictacaoAltoRisco(this SolicitacaoCredito solicitacao)
        {
            return solicitacao.Avaliacao.Risco == Enums.TipoRisco.Alto &&
                   solicitacao.ValorAutorizado <= 5000;
        }

        public static bool SolictacaoMedioRisco(this SolicitacaoCredito solicitacao)
        {
            return solicitacao.Avaliacao.Risco == Enums.TipoRisco.Medio &&
                   solicitacao.ValorAutorizado <= 10000;
        }

        public static bool SolictacaoBaixoRisco(this SolicitacaoCredito solicitacao)
        {
            return solicitacao.Avaliacao.Risco == Enums.TipoRisco.Baixo &&
                   solicitacao.ValorAutorizado <= 20000;
        }

        public static Expression<Func<SolicitacaoCredito, bool>> QuerySolictacaoAltoRisco
        {
            get
            {
                return x => x.SolictacaoAltoRisco();
            }
        }
    }
}
