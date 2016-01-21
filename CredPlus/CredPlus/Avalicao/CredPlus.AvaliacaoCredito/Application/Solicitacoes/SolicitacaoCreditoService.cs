using CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Enums;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Events;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Repositories;
using CredPlus.Compartilhado.Events;
using CredPlus.Compartilhado.Validations;
using System;

namespace CredPlus.AvaliacaoCredito.Application.Solicitacoes
{
    public class SolicitacaoCreditoService : Validatable
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
                Notify(solicitacao.Policy.GetNotifications());
        }

        public void Autorizar(Guid idSolicitacao, string avaliador, TipoRisco risco, decimal valor)
        {
            var solicitacao = _repository.Localizar(idSolicitacao);
            solicitacao.Autorizar(avaliador, risco, valor);
            _repository.Salvar(solicitacao);
        }

        public void Confirmar(Guid idSolicitacao, int parcelas)
        {
            var solicitacao = _repository.Localizar(idSolicitacao);
            solicitacao.Confirmar(parcelas);
            _repository.Salvar(solicitacao);

            ConfirmarGeracaoCredito(solicitacao);
        }

        private void ConfirmarGeracaoCredito(SolicitacaoCredito solicitacaoConfirmada)
        {
            var evento = new SolicitacaoCreditoConfirmada(solicitacaoConfirmada);
            DomainEventNotifier.Current.Raise(evento);

            if (evento.Processado)
            {
                var solicitacao = _repository.Localizar(solicitacaoConfirmada.Id);
                solicitacao.ConfirmarCreditoGerado();
                _repository.Salvar(solicitacao);
            }
        }
    }
}
