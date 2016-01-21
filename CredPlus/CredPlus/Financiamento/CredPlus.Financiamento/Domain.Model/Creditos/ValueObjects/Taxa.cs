using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Financiamento.Domain.Model.Creditos.ValueObjects
{
    public class Taxa
    {
        public decimal Juros { get; private set; }
        public decimal Multa { get; private set; }

        internal Taxa(decimal juros, decimal multa)
        {
            Juros = juros;
            Multa = multa;
        }

        internal decimal ValorJuros(decimal valorPago, DateTime vencimento, DateTime pagamento)
        {
            return Calcular(valorPago, Juros, vencimento, pagamento);
        }

        internal decimal ValorMulta(decimal valorPago, DateTime vencimento, DateTime pagamento)
        {
            return Calcular(valorPago, Multa, vencimento, pagamento);
        }

        private decimal Calcular(decimal valorPago, decimal taxa, DateTime vencimento, DateTime pagamento)
        {
            return (valorPago * (taxa / 100)) * (pagamento - vencimento).Days;
        }
    }
}
