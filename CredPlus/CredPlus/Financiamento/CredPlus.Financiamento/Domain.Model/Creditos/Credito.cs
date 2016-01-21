using CredPlus.Financiamento.Domain.Model.Creditos.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CredPlus.Financiamento.Domain.Model.Creditos
{
    public class Credito
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal Valor { get; private set; }
        public ICollection<Parcela> Parcelas { get; private set; }

        internal Credito(Guid clienteId, decimal valor)
        {
            Id = Guid.NewGuid();
            Valor = valor;

            if (valor < 0 || valor > 20000)
                throw new Exception("Valor inválido");
        }

        public class Factory
        {
            public static Credito New(Guid clienteId, decimal valor, int quantidadeParcelas)
            {
                var credito = new Credito(clienteId, valor);
                var parcelas = new List<Parcela>();
                var dataBase = DateTime.Now;

                for (int i = 0; i < quantidadeParcelas; i++)
                {
                    var parcela = Parcela.Nova(valor, 0, 0, quantidadeParcelas, dataBase);
                    parcelas.Add(parcela);
                    dataBase = parcela.Vencimento;
                }

                return credito;
            }
        }

    }
}
