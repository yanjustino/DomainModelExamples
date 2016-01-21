using CredPlus.Financiamento.Domain.Model.Creditos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Financiamento.Domain.Model.Creditos
{
    public class Parcela
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Vencimento { get; private set; }
        public DateTime? Pagamento { get; private set; }
        public Taxa Taxa { get; private set; }
        public decimal? ValorMulta { get; private set; }
        public decimal? ValorJuros { get; private set; }
        public decimal ValorPago { get; private set; }

        internal Parcela(decimal valor, DateTime vencimento, Taxa taxa)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Vencimento = vencimento;
            Taxa = taxa;
        }

        internal void Baixar(decimal valorPago, decimal juros, decimal multa, DateTime dataPagamento)
        {
            ValorPago = valorPago;
            ValorJuros = juros;
            ValorMulta = multa;
            Pagamento = dataPagamento;
        }

        internal static Parcela Nova(decimal valorCredito, decimal juros, decimal multa, int quantidadeParcelas, DateTime dataBase)
        {
            var valor = (valorCredito / quantidadeParcelas);

            return new Parcela
            (
                valor, dataBase.AddDays(30), new Taxa(juros, multa)
            );
        }
    }
}
