namespace solid_principles.DependencyInversion
{
    /// <summary>
    /// Quanto utilizamos a injeção de dependência, apenas recebemos o que precisamos via construtor e utilizamos.
    /// A classe de serviço aqui precisa salvar um texto, ela não precisa saber se o texto vai ser salvo no SQL, NoSQL, pdf ou txt.
    /// Ela só precisa que o texto seja salvo! E ela faz a chamada somente.
    /// Assim evitamos acoplamento entre classes e facilitamos a manutenção, substituição do serviço de salvamento e testabilidade.
    /// </summary>
    public interface IRepository
    {
        public void Save(string text);
    }

    public class SQLRepository: IRepository
    {
        public void Save(string text) { /* Lógica para salvar */ }
    }

    public class ExampleService(IRepository repository)
    {           

        public void Execute(string text)
        {
            repository.Save(text);
        }
    }
}
