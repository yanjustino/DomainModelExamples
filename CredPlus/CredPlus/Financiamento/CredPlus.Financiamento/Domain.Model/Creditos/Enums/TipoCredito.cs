using System.ComponentModel;

namespace CredPlus.Financiamento.Domain.Model.Creditos.Enums
{
    public enum TipoCredito
    {
        [Description("Capital de Griro")]
        CapitalGiro = 1,

        [Description("Equipamentos")]
        Equipamento = 2
    }
}
