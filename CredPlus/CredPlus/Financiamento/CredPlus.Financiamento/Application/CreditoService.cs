using CredPlus.Financiamento.Domain.Model.Creditos;
using CredPlus.Financiamento.Domain.Model.Creditos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Financiamento.Application
{

    public class CreditoService
    {
        private ICreditoRepository _creditoRepository;

        public CreditoService(ICreditoRepository creditoRepository)
        {
            _creditoRepository = creditoRepository;
        }

        public void RegistrarCredito(Guid clienteId, decimal valor, int quantidadeParcelas)
        {
            var credito = Credito.Factory.New(clienteId, valor, quantidadeParcelas);
            _creditoRepository.Salvar(credito);
        }
    }
}
