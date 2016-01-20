using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;

namespace CredPlus.AvaliacaoCredito.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solicitacao = SolicitacaoCredito.Factory.New(Guid.NewGuid(), 0);
            Assert.IsFalse(solicitacao.Policy.IsValid);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var solicitacao = SolicitacaoCredito.Factory.New(Guid.NewGuid(), 20000);
            solicitacao.Autorizar("yan", Domain.Model.Solicitacoes.Enums.TipoRisco.Alto, 20000);


            Assert.IsFalse(solicitacao.Policy.IsValid);
        }
    }
}
