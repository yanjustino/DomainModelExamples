using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredPlus.Compartilhado.Events
{
    public interface IEventContainer
    {
        IEnumerable<T> GetServices<T>();
    }
}
