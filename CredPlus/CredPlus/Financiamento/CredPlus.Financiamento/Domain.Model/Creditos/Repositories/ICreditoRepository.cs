using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Financiamento.Domain.Model.Creditos.Repositories
{
    public interface ICreditoRepository
    {
        void Salvar(Credito credito);
    }
}
