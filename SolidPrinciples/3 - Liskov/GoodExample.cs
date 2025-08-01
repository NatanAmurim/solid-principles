namespace SolidPrinciples.Liskov
{
    /// <summary>
    /// Perceba que aqui qualquer classe derivada pode ser substituída pela classe mãe, sem quebrar a funcionalidade.
    /// O resultado esperado é que q ave coma.
    /// </summary>
    public class Bird
    {
        public virtual void Eat() { }
    }

    public class Chicken : Bird
    {
        public virtual void Eat() { /* come milho */ }
    }

    public class Penguin : Bird
    {
        public virtual void Eat() { /* come peixe */ }
    }
}
