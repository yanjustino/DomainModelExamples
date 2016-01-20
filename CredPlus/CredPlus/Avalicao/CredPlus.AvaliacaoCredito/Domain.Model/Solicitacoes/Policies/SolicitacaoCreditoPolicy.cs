using CredPlus.Compartilhado.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Policies
{
    public class SolicitacaoCreditoPolicy : Validatable
    {
        public SolicitacaoCredito Solicitacao { get; private set; }

        public SolicitacaoCreditoPolicy(SolicitacaoCredito solicitacao)
        {
            Solicitacao = solicitacao;
        }

        protected override void Validate()
        {
            Notify
            (
                AssertionConcern.AssertNotNull(Solicitacao, "Solicitacão não pode ser nula"),
                AssertionConcern.AssertTrue(Solicitacao.Valor > 0, "Solicitação inválida"),
                AssertionConcern.AssertTrue(Solicitacao.Valor > 0, "Valor deve ser maior que zero")
            );
        }
    }
}
