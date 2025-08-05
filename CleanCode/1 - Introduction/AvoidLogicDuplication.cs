using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Introduction
{
    public class BadExample
    {
        public void HandleUserAccess(User user)
        {
            if (user.Type == "Admin")
            {
                SendEmail(user.Email, "Acesso concedido ao painel administrativo.");
            }

            if (user.Type == "Admin")
            {
                LogAccess(user.Id, "Painel admin acessado");
            }
        }

        private void LogAccess(int id, string text)
        {
            /*Lógica para acessar*/
        }

        private void SendEmail(string email, string text)
        {
            /*Lógica para enviar e-mail*/
        }
    }


    /// <summary>
    /// Aqui reutilizamos o código assim facilitando a manutenção;
    /// Caso haja necessidade de troca na lógica, ela está em um ponto só!
    /// Ainda não é o caminho ideal, pois estamos deixando a classe aberta para modificações na validaçãod e admin, mas aqui só estamos falando de clean code. Solid está em outro projeto kkkkk.
    /// </summary>
    public class GoodExample
    {
        private const string ADMIN_TYPE = "Admin";

        public void HandleUserAccess(User user)
        {
            if (user.Type == ADMIN_TYPE)
                NotifyAdminAcess(user);
        }

        private void NotifyAdminAcess(User user)
        {
            SendEmail(user.Email, "Acesso concedido ao painel administrativo.");
            LogAccess(user.Id, "Painel admin acessado");
        }

        private void LogAccess(int id, string text)
        {
            /*Lógica para acessar*/
        }

        private void SendEmail(string email, string text)
        {
            /*Lógica para enviar e-mail*/
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
    }
}
