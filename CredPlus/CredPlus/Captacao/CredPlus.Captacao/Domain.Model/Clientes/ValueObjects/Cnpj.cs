
using CredPlus.Compartilhado.Validations;

namespace CredPlus.Captacao.Domain.Model.Clientes.ValueObjects
{
    public class Cnpj : Documento
    {
        public Cnpj(string numero) : base(numero) { }

        protected override void Validate()
        {
            Validations(
                AssertionConcern.AssertNotEmpty(NumeroOriginal, "CNPJ não pode ser vazio"),
                AssertionConcern.AssertNotNull(NumeroOriginal, "CNPJ não pode ser Nulo"),
                AssertionConcern.AssertLength(Numero, 14, 14, "Tamanho do CPF Inválido")
            );
        }
    }
}
