using System;

namespace CredPlus.Financiamento.Domain.Model.Creditos
{
    public class Credito
    {
        public Credito(decimal valor)
        {
            if (valor > 20000)
                throw new Exception("Valor inválido");
        }

    }
}
