namespace CleanCode.Boundary
{
    /// <summary>
    /// Note que o nosso serviço depende de um interface nossa, logo se houver alguma necessidade de troca de base de dados
    /// o serviço permanece intacto, ele apenas recebe um adaptador, uma interface como contrato.
    /// A implementação da interface não diz respeito ao serviço, logo nosso código fica mais coeso e de fácil manutenção!
    /// </summary>
    /// <param name="clientRespository"></param>
    public class GetClientService(IClientRespository clientRespository)
    {

        public Client GetClient(int clientId)
        {
            var client = clientRespository.GetClient(clientId);

            //Lógica de validação

            return client;
        }

    }

    public class Client
    {
    }

    public interface IClientRespository
    {
        public Client GetClient(int id);
    }

    /// <summary>
    /// Veja que temos várias implementações possíveis aqui!
    /// O serviço fica desacoplado do banco de dados, o que gera maior facilidade para troca/manutenção!
    /// </summary>
    public class SQLServerClientRespository : IClientRespository
    {
        public Client GetClient(int id)
        {
            //Acessa uma base SQL e realiza toda a lógica necessária para recuperar o cliente
            throw new NotImplementedException();
        }
    }

    public class MySQLClientRespository : IClientRespository
    {
        public Client GetClient(int id)
        {
            //Acessa uma base SQL e realiza toda a lógica necessária para recuperar o cliente
            throw new NotImplementedException();
        }
    }
}
