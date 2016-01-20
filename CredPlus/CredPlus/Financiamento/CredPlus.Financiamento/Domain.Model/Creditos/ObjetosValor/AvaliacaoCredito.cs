using CredPlus.Financiamento.Domain.Model.Creditos.Enums;
using System;

namespace CredPlus.Financiamento.Domain.Model.Creditos.ObjetosValor
{
    public class AvaliacaoCredito
    {
        public TipoRisco Risco { get; private set; }
        public bool Aprovado { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public string Justificativa { get; private set; }
    }
}
