using CredPlus.Financiamento.Domain.Model.Creditos.Enums;
using System;

namespace CredPlus.Financiamento.Domain.Model.Creditos
{
    public class Credito
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public TipoCredito Tipo { get; private set; }

        internal Credito(decimal valor, TipoCredito tipo)
        {
            Id = Guid.NewGuid();
            Valor = valor;

            if (valor < 0 || valor > 20000)
                throw new Exception("Valor inválido");
        }

        public class Factory
        {
            public static Credito New(decimal valor, TipoCredito tipo)
            {
                var credito = new Credito(valor, tipo);

                return credito;
            }
        }

    }
}
