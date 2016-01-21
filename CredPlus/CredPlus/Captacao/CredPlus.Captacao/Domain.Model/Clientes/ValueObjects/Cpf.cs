
using CredPlus.Compartilhado.Validations;

namespace CredPlus.Captacao.Domain.Model.Clientes.ValueObjects
{
    public class Cpf : Documento
    {
        public Cpf(string numero) : base(numero) { }

        protected override void Validate()
        {
            Validations(
                AssertionConcern.AssertNotEmpty(NumeroOriginal, "CPF não pode ser vazio"),
                AssertionConcern.AssertNotNull(NumeroOriginal, "CPF não pode ser Nulo"),
                AssertionConcern.AssertLength(Numero, 11, 11, "Tamanho do CPF Inválido")
            );
        }
    }
}
