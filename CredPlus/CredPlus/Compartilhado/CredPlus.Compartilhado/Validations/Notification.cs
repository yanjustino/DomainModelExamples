using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Compartilhado.Validations
{
    public class Notification
    {
        public int Code { get; private set; }
        public string Message { get; private set; }

        public Notification(string mensagem)
        {
            Code = 0;
            Message = mensagem;
        }

        public Notification(int code, string mensagem)
        {
            Code = code;
            Message = mensagem;
        }
    }
}
