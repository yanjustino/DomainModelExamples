using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Compartilhado.Validations
{
    public class Notification
    {
        public string Message { get; private set; }

        public Notification(string mensagem)
        {
            Message = mensagem;
        }
    }
}
