namespace solid_principles.DependencyInversion
{
    /// <summary>
    /// Note que ao criarmos a instância dentro de nossa classe, geramos uma dependência de uma classe concreta.
    /// Em um serviço, pode não parecer muito preocupante, mas imagine em um cenário que temos vários serviços que criam essa instância e a utilizam?
    /// Caso esse repositório venha a mudar, teremos que alterar em diversos pontos da aplicação, o que geraria um grande trabalho e aumentaria muito o risco de quebra da aplicação.
    /// E para testes unitário fica ainda mais difícil, pois se a classe repositório fizer uma conexão real com alguma ferramenta externa, teremos que conectar de fato ou similar.
    /// Com a injeção de dependência utilizando um interface, conseguimos realizar um mock muito mais facilmente e testar o que realmente importa.
    /// </summary>

    public class SomeRepository
    {
        public void Save(string text) { /* Lógica para salvar */ }
    }

    public class SomeService()
    {
        public void Execute(string text)
        {
            var repository = new SomeRepository();
            repository.Save(text);
        }
    }
}
