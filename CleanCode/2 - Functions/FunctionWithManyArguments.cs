using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Functions
{
    internal class FunctionWithManyArguments
    {
        //Ruim: muitos parâmetros
        public void Register(string name, string email, string phone, string cpf, string rg, string endereco)
        {
            // lógica...
        }

        //Bom: encapsula os dados em uma classe
        public void Register(ClientData clientData)
        {
            // lógica...
        }

        public class ClientData
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }   
            public string Cpf { get; set; }
            public string Rg { get; set; }
            public string Address { get; set; }
        }
    }
}
