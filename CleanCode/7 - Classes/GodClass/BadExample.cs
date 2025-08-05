using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Classes.GodClass
{
    /// <summary>
    /// Essa classe faz coisas demais!
    /// Ela ficaria gigante quando implementada, sem coesão, misturando níveis de abstração e difícil de testar.
    /// E se alguma regra mudar, corremos o risco de afetar partes do sistema que já estavam funcionando corretamente!
    /// </summary>
    public class CustomerService
    {
        public void RegisterCustomer(string name, string email) { /* lógica de cadastro */ }

        public void SendWelcomeEmail(string email) { /* lógica de e-mail */ }

        public void CalculateDiscount(int customerId) { /* lógica de desconto */ }

        public void DeleteCustomer(int customerId) { /* deletar cliente */ }

        public void GenerateCustomerReport() { /* gerar relatório */ }

        public void BackupDatabase() { /* lógica de backup */ }
    }
}
