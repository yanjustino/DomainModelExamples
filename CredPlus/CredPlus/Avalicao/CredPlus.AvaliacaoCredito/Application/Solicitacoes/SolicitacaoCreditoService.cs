using System;
using CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Repositories;
using CredPlus.Compartilhado.Validations;

namespace CredPlus.AvaliacaoCredito.Application.Solicitacoes
{
    public class SolicitacaoCreditoService : Validatable, ISolicitacaoCreditoService
    {
        ISolicitacaoCreditoRepository _repository;

        public SolicitacaoCreditoService(ISolicitacaoCreditoRepository repository)
        {
            _repository = repository;
        }

        public void Solicitar(RegistroSolicitacaoCreditoCommand command)
        {
            var solicitacao = SolicitacaoCredito.Factory.New(command);

            if (solicitacao.Policy.IsValid)
                _repository.Salvar(solicitacao);
            else
            {
                Notify(solicitacao.Policy.GetNotifications());
            }
        }
    }
}
