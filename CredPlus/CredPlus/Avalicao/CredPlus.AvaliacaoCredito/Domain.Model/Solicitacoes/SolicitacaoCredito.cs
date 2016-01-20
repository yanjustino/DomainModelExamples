using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Enums;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Policies;
using CredPlus.Compartilhado.Validations;
using System;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes
{
    public class SolicitacaoCredito
    {
        public Validatable Policy { get; private set; }

        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public bool Aprovada { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime? DataSolicitacaoCliente { get; set; }
        public DateTime? DataGeracaoCredito { get; private set; }
        public bool CreditoGerado { get; private set; }
        public decimal Valor { get; private set; }
        public decimal ValorAutorizado { get; private set; }
        public int? QuantidadeParcelas { get; set; }
        public virtual AvaliacaoCredito Avaliacao { get; private set; }

        protected SolicitacaoCredito() { }

        internal SolicitacaoCredito(Guid clienteID, decimal valor)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteID;
            Valor = valor;
            Data = DateTime.Now;
            CreditoGerado = false;

            Policy = new SolicitacaoCreditoPolicy(this);
        }

        public void Autorizar(string avaliador, TipoRisco risco, decimal valor, string justificativa = "")
        {
            Aprovada = true;
            ValorAutorizado = valor;
            Avaliacao = new AvaliacaoCredito(avaliador, risco, justificativa);


            Policy = new AutorizacaoCreditoPolicy(this);
        }

        internal void Rejeitar(string avaliador, TipoRisco risco, string justificativa)
        {
            Aprovada = false;
            ValorAutorizado = 0;
            Avaliacao = new AvaliacaoCredito(avaliador, risco, justificativa);
        }

        internal void Confirmar(int quantidadeParcelas)
        {
            DataSolicitacaoCliente = DateTime.Now;
            QuantidadeParcelas = quantidadeParcelas;
        }

        internal void ConfirmarCreditoGerado()
        {
            CreditoGerado = true;
            DataGeracaoCredito = DateTime.Now;
        }

        public class Factory
        {
            public static SolicitacaoCredito New(Guid clienteID, decimal valor)
            {
                return new SolicitacaoCredito(clienteID, valor);
            }
        }

    }
}
