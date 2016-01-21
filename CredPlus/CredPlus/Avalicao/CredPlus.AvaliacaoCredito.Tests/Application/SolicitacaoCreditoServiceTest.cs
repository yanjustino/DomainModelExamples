using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;
using CredPlus.AvaliacaoCredito.Application.Solicitacoes;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Repositories;
using CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands;

namespace CredPlus.AvaliacaoCredito.Tests
{
    public class RepositoryMock : ISolicitacaoCreditoRepository
    {
        public bool Chamado { get; set; }

        public SolicitacaoCredito Localizar(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(SolicitacaoCredito solicitacao)
        {
            Chamado = true;
            return;
        }
    }

    [TestClass]
    public class SolicitacaoCreditoServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new RepositoryMock();
            var service = new SolicitacaoCreditoService(mock);

            service.Solicitar(new RegistroSolicitacaoCreditoCommand
            {
                ClienteId = Guid.NewGuid(),
                Valor = 0
            });

            Assert.IsFalse(service.IsValid);
            Assert.IsFalse(mock.Chamado);
        }
    }
}
