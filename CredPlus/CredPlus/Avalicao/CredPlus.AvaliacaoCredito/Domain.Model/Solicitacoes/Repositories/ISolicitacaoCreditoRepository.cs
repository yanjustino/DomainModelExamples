using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.AvaliacaoCredito.Domain.Model.Solicitacoes.Repositories
{
    public interface ISolicitacaoCreditoRepository
    {
        void Salvar(SolicitacaoCredito solicitacao);
    }
}
