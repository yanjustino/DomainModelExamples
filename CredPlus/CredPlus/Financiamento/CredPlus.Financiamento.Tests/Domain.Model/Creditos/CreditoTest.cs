using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CredPlus.Financiamento.Domain.Model.Creditos;

namespace CredPlus.Financiamento.Tests.Domain.Model.Creditos
{
    [TestClass]
    public class CreditoTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteValorMaximoCredito()
        {
            var credito = new Credito(21000);
        }
    }
}
