using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DriveOracleDevArt // ComponeteAcessoDados
    {
        public object Query()
        {
            return null;
        }
    }

    public interface IDriveDados
    {
        T Buscar<T>();
    }

    public class MeuDriveOracle : IDriveDados
    {
        DriveOracleDevArt devArt;

        public T Buscar<T>()
        {
            return (T)devArt.Query();
        }
    }

    public class MeuDriveSQL : IDriveDados
    {
        DriveOracleDevArt devArt;

        public T Buscar<T>()
        {
            return (T)devArt.Query();
        }
    }

    public class ClassB
    {
        IDriveDados drivedados;
        public ClassB(IDriveDados dados)
        {
            drivedados = new MeuDriveOracle();
        }

        void Teste()
        {
            drivedados.ToString();
        }
    }
}
