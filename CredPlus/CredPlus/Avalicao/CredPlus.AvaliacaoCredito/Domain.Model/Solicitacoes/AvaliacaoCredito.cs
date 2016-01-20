using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Enums;
using System;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes
{
    public class AvaliacaoCredito
    {
        public Guid Id { get; private set; }
        public TipoRisco Risco { get; private set; }
        public DateTime DataAvaliacao { get; private set; }
        public string Justificativa { get; private set; }
        public string Avalidador { get; private set; }

        public AvaliacaoCredito(string avaliador, TipoRisco risco, string justificativa)
        {
            Id = Guid.NewGuid();
            Avalidador = avaliador;
            Justificativa = justificativa;
            Risco = risco;
        }
    }
}
