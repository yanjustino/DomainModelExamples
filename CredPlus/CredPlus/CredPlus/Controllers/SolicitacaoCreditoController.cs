using CredPlus.AvaliacaoCredito.Application.Solicitacoes;
using CredPlus.AvaliacaoCredito.Application.Solicitacoes.Commands;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes;
using CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Repositories;
using System;
using System.Web.Mvc;

namespace CredPlus.Controllers
{
    public class SolicitacaoCreditoController : Controller
    {

        public class RepositoryMock : ISolicitacaoCreditoRepository
        {
            public bool Chamado { get; set; }

            public void Salvar(SolicitacaoCredito solicitacao)
            {
                Chamado = true;
                return;
            }
        }
        private readonly SolicitacaoCreditoService _solicitacaoCreditoService;

        public SolicitacaoCreditoController( )
        {
            _solicitacaoCreditoService = new SolicitacaoCreditoService(new RepositoryMock());
        }

        public ActionResult Index()
        {
            _solicitacaoCreditoService.Solicitar
            (
                new RegistroSolicitacaoCreditoCommand
                {
                    ClienteId = Guid.NewGuid(),
                    Valor = 0
                }
            );

            if (!_solicitacaoCreditoService.IsValid)
            {
                ViewBag.message = _solicitacaoCreditoService.StringifyNotifications();
            }

            return View();
        }
    }
}