using CleanCode.Introduction;

namespace CleanCode.Functions
{
    public class FlagParameterAndUnclearFunctionName
    {
        // ❌ Ruim: nome vago, parâmetro booleano
        public void HandleClient(Client client, bool isVip)
        {
            if (isVip)
                GiveDiscount(client);
            else
                Console.WriteLine("Sem desconto");
        }

        // Bom: funções específicas e com nomes descritivos
        public void HandleRegularClient(Client client)
        {
            Console.WriteLine("Sem desconto");
        }

        public void HandleVipClient(Client client)
        {
            GiveDiscount(client);
        }

        private void GiveDiscount(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
