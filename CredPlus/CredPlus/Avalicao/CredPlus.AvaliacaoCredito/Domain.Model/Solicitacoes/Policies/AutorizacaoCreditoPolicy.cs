using CredPlus.Compartilhado.Validations;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Resources;

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
            if (Solicitacao.Avaliacao.Risco == Enums.TipoRisco.Alto)
                Notificar(Solicitacao.SolictacaoAltoRisco(), 
                    SolicitacaoResource.MensagemSolicitacaoRisco);

            else if (Solicitacao.Avaliacao.Risco == Enums.TipoRisco.Medio)
                Notificar(Solicitacao.SolictacaoMedioRisco(),
                    SolicitacaoResource.MensagemSolicitacaoRisco);

            else if (Solicitacao.Avaliacao.Risco == Enums.TipoRisco.Baixo)
                Notificar(Solicitacao.SolictacaoBaixoRisco(),
                    SolicitacaoResource.MensagemSolicitacaoRisco);
        }

        private void Notificar(bool condicao, string mensagem)
        {
            Notify
            (
                AssertionConcern.AssertTrue(condicao, mensagem)
            );
        }

    }
}
