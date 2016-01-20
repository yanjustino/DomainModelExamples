using System;

namespace CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands
{
    public class RegistroSolicitacaoCreditoCommand
    {
        public Guid ClienteId { get; set; }
        public decimal Valor { get; set; }
    }
}
