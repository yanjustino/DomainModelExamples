using CredPlus.Compartilhado.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Events
{
    public class SolicitacaoCreditoConfirmada : IDomainEvent
    {
        public SolicitacaoCredito SolicitacaoCredito { get; set; }
        public bool Processado { get; set; }

        public SolicitacaoCreditoConfirmada(SolicitacaoCredito solicitacaoCredito)
        {
            SolicitacaoCredito = solicitacaoCredito;
        }
    }
}
