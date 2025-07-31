namespace SolidPrinciples.OpenClosed
{
    /// <summary>
    /// Note que neste caso se um novo tipo for criado, o código da classe Discount terá que ser alterado.
    /// Num método pequeno assim, talvez não faça diferença.
    /// Mas quando você está trabalhando com um sistema grande, com regras complexas, este método poderia "inchar" demais, 
    /// tornando difícil sua compreensão, arriscando a quebra do código previamente validado e utilizado e gerando uma díficil manutenção e testabilidade.
    /// </summary>
    public class Discount
    {
        public decimal Calculate(decimal value, DiscountType discountType)
        {
            return discountType switch
            {
                DiscountType.Normal => value * 0.7m,
                DiscountType.Christmas => value * 0.8m,
                DiscountType.VIPClient => value * 0.9m,
                _ => value
            };
        }
    }

    public enum DiscountType
    {
        Normal,
        Christmas,
        VIPClient
    }
}
