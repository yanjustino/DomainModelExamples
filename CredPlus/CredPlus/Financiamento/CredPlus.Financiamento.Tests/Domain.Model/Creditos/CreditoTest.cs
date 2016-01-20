using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CredPlus.Financiamento.Domain.Model.Creditos;
using CredPlus.Financiamento.Domain.Model.Creditos.Enums;

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
            var credito = Credito.Factory.New(21000, TipoCredito.CapitalGiro);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteValorMinimoCreditoMaiorQueZero()
        {
            var credito = Credito.Factory.New(-21000, TipoCredito.CapitalGiro);
        }

    }
}
