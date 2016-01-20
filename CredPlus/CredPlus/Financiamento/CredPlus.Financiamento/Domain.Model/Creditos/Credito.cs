using CredPlus.Financiamento.Domain.Model.Creditos.Enums;
using CredPlus.Financiamento.Domain.Model.Creditos.ObjetosValor;
using System;

namespace CredPlus.Financiamento.Domain.Model.Creditos
{
    public class Credito
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public AvaliacaoCredito Avaliacao { get; private set; }
        public TipoCredito Tipo { get; private set; }

        public Credito(decimal valor)
        {
            Id = Guid.NewGuid();

            if (valor < 0 || valor > 20000)
                throw new Exception("Valor inválido");
        }

    }
}
