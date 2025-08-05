using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Classes.Encapsulation
{
    /// <summary>
    /// Essa classe aplica corretamente o princípio de encapsulamento.
    /// Os dados são atribuídos no momento da criação do objeto, e não podem ser alterados depois.
    /// Isso garante a integridade e confiabilidade do estado interno da classe,
    /// facilitando o raciocínio sobre seu comportamento e reduzindo erros.
    /// </summary>
    public class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Email.Contains("@");
        }
    }
}
