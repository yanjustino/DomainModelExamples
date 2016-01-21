using CredPlus.Captacao.Domain.Model.Clientes.ValueObjects;
using CredPlus.Compartilhado.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Captacao.Domain.Model.Clientes
{
    public class Cliente : Validatable
    {
        public Guid Id { get; private set; }
        public Cnpj CNPJ { get; private set; }
        public string Ramo { get; private set; }
        public decimal Rendimentos { get; private set; }
        public string Nome { get; private set; }
        public Empreendedor Proprietario { get; private set; }

        internal Cliente(string nome, string ramo, string cnpj, decimal rendimentos, Empreendedor empreendedor)
        {
            Id = Guid.NewGuid();
            CNPJ = new Cnpj(cnpj);
            Ramo = ramo;
            Nome = nome;
            Rendimentos = rendimentos;
            Proprietario = empreendedor;
        }

        protected override void Validate()
        {
            if (!CNPJ.IsValid)
                Notify(CNPJ.GetNotifications());

            if (!Proprietario.IsValid)
                Notify(Proprietario.GetNotifications());

            Notify
            (
                AssertionConcern.AssertNotEmpty(Nome, "Nome não pode ser vazio ou nulo"),
                AssertionConcern.AssertIsGreaterThan(Rendimentos, 0, "Informe o valor dos Rendimentos")
            );
        }

    }
}
