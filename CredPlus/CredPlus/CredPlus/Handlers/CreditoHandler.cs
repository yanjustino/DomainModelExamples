using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Events;
using CredPlus.Compartilhado.Events;
using CredPlus.Financiamento.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CredPlus.Handlers
{
    public class CreditoHandler : IEventHandler<SolicitacaoCreditoConfirmada>
    {
        private CreditoService _service;

        public CreditoHandler(CreditoService service)
        {
            _service = service;
        }


        public void Handle(SolicitacaoCreditoConfirmada domainEvent)
        {
            _service.RegistrarCredito(
                domainEvent.SolicitacaoCredito.ClienteId,
                domainEvent.SolicitacaoCredito.ValorAutorizado,
                domainEvent.SolicitacaoCredito.QuantidadeParcelas.Value);

            domainEvent.Processado = true;
        }
    }
}