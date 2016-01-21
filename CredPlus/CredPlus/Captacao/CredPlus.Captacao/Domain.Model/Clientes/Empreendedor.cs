using CredPlus.Captacao.Domain.Model.Clientes.ValueObjects;
using CredPlus.Compartilhado.Validations;
using System;

namespace CredPlus.Captacao.Domain.Model.Clientes
{
    public class Empreendedor : Validatable
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Cpf CPF { get; private set; }
        public Email Email { get; private set; }
        public bool RegistradoSPC { get; private set; }

        internal Empreendedor(string nome, string cpf, string email, bool spc = false)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = new Cpf(cpf);
            Email = new Email(email);
            RegistradoSPC = spc;
        }

        protected override void Validate()
        {
            if (!Email.IsValid)
                Notify(Email.GetNotifications());

            if (!CPF.IsValid)
                Notify(CPF.GetNotifications());

            Notify(AssertionConcern.AssertTrue(!RegistradoSPC, "Registrado no SPC"));
        }
    }
}
