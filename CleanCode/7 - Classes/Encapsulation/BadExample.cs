namespace CleanCode.Classes.Encapsulation
{
    /// <summary>
    /// Essa classe viola o princípio de encapsulamento ao expor seus campos diretamente como públicos.
    /// Qualquer parte do sistema pode alterar os valores de Name e Email livremente, sem nenhuma validação ou controle.
    /// Isso torna difícil garantir a consistência e integridade dos dados dentro da classe,
    /// prejudicando a confiabilidade da lógica interna, como o método IsValid().
    /// </summary>
    public class CustomerBadExample
    {
        public string Name;
        public string Email;

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Email.Contains("@");
        }
    }
}
