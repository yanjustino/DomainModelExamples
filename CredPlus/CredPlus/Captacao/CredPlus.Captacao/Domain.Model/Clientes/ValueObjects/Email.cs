using CredPlus.Compartilhado.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Captacao.Domain.Model.Clientes.ValueObjects
{
    public class Email : Validatable
    {
        public string Address { get; private set; }

        internal Email(string email)
        {
            Address = email;
        }

        protected override void Validate()
        {
            Notify
            (
                AssertionConcern.AssertEmailIsValid(Address, "email inválido")
            );
        }
    }
}
