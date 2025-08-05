using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Classes.GodClass
{
    /// <summary>
    /// Aqui dividimos as responsabilidades em classes.
    /// Aumentamos a coesão, cada classe faz uma coisa e a faz bem.
    /// Diminuimos o tamanho da classe, o que facilita sua leitura e compreensão.
    /// E para testes nem se fala, infinitamente mais fácil de realizar!
    /// E se alguma regra mudar? Somente onde ela mudou será afetado, o sistema fica mais seguro!
    /// </summary>
    public class CustomerRegistrar
    {
        public void Register(string name, string email) { /* lógica de cadastro */ }
    }

    public class WelcomeEmailService
    {
        public void Send(string email) { /* lógica de envio */ }
    }

    public class DiscountCalculator
    {
        public decimal Calculate(int customerId) { return 0; /* lógica de desconto */ }
    }

    public class ReportGenerator
    {
        public void GenerateCustomerReport() { /* lógica de relatório */ }
    }

    public class BackupService
    {
        public void RunBackup() { /* lógica de backup */ }
    }
}
