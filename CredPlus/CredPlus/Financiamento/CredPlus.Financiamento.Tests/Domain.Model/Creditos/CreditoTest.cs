using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CredPlus.Financiamento.Domain.Model.Creditos;
using CredPlus.Financiamento.Domain.Model.Creditos.Enums;
using CredPlus.Financiamento.Domain.Model.Creditos.ObjetosValor;

namespace CredPlus.Financiamento.Tests.Domain.Model.Creditos
{
    [TestClass]
    public class CreditoTest
    {
        [TestMethod]
        [Description(
            @"Dado um crédito com R$ 21.000,00
              Deve disparar uma exceção!")]
        [ExpectedException(typeof(Exception))]
        public void TesteValorMaximoCredito()
        {
            var credito = Credito.Factory.New(21000, 
                Financiamento.Domain.Model.Creditos.Enums.TipoCredito.CapitalGiro,
                new AvaliacaoCredito("yan", TipoRisco.Alto, true, "teste"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteValorMinimoCreditoMaiorQueZero()
        {
            var credito = Credito.Factory.New(-21000,
                Financiamento.Domain.Model.Creditos.Enums.TipoCredito.CapitalGiro,
                new AvaliacaoCredito("yan", TipoRisco.Alto, true, "teste"));
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteValorRiscoAlto()
        {
            var credito = Credito.Factory.New(20000,
                TipoCredito.CapitalGiro,
                new AvaliacaoCredito("yan", TipoRisco.Alto, true, "teste"));
        }
    }
}
