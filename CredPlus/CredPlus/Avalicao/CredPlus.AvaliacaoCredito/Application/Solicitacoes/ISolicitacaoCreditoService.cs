using CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;

namespace CredPlus.AvaliacaoCredito.Application.Solicitacoes
{
    public interface ISolicitacaoCreditoService
    {
        SolicitacaoCredito Solicitar(RegistroSolicitacaoCreditoCommand command);
    }
}
