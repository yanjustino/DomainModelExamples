using CredPlus.Compartilhado.Validations;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Policies
{

    public class AutorizacaoCreditoPolicy: Validatable
    {
        public SolicitacaoCredito Solicitacao { get; private set; }

        public AutorizacaoCreditoPolicy(SolicitacaoCredito solicitacao)
        {
            Solicitacao = solicitacao;
        }

        protected override void Validate()
        {
            Notify
            (
                AssertionConcern.AssertTrue(Solicitacao.SolictacaoDeRisco(), 
                "Solicitacao de Crédito inválida. Valor fora de sua faixa")
            );
        }
    }
}
