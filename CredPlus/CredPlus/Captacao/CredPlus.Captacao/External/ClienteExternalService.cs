using CredPlus.Captacao.Domain.Model.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Captacao.External
{
    public class ClienteExternalService
    {
        public Cliente Importar(string cnpj)
        {
            //TODO : WebService Cliente

            var registradoSPC = false;// TODO consultar no SPC

            return new Cliente("nome", "ramo", cnpj, 75000, 
                new Empreendedor("nome", "", "", registradoSPC));
        }
    }
}
