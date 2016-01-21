using CredPlus.Compartilhado.Validations;
using System.Linq;

namespace CredPlus.Captacao.Domain.Model.Clientes.ValueObjects
{
    public abstract class Documento : Validatable
    {
        public string Numero { get; protected set; }
        public string NumeroOriginal { get; protected set; }

        public Documento(string numero)
        {
            NumeroOriginal = numero;
            Numero = RemoverCaracteres(NumeroOriginal, "./-");
        }

        public static TipoDocumento TipoDocumento(string numero)
        {
            numero = RemoverCaracteres(numero, "./-");

            switch (numero.Length)
            {
                case 11: return  ValueObjects.TipoDocumento.CPF;
                case 14: return ValueObjects.TipoDocumento.CNPJ;
                default: return ValueObjects.TipoDocumento.DESCONHECIDO;
            };
        }

        private static string RemoverCaracteres(string numeroOriginal, string caracteres)
        {
            var numero = numeroOriginal;
            foreach (var item in caracteres.ToArray())
                numero = numero?.Replace(item.ToString(), string.Empty);

            return numero;
        }


        public class Factory
        {
            public static Documento New(string numero)
            {
                if (TipoDocumento(numero) == ValueObjects.TipoDocumento.CPF)
                    return new Cpf(numero);
                else if (TipoDocumento(numero) == ValueObjects.TipoDocumento.CNPJ)
                    return new Cnpj(numero);
                else
                    return null;
            }
        }
    }
}
