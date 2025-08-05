namespace CleanCode.Introduction
{
    public class AvoidGenericNames
    {
        public void DoStuff(int x)
        {
            // faz alguma coisa
        }

        /// <summary>
        /// Aqui só de bater o olho, sabemos o que o método faz, pois seu nome é claro, tanto para o método quanto para seu parâmetro!
        /// </summary>
        /// <param name="quantidadeItens"></param>
        public void CalculateFreight(int quantidadeItens)
        {
            // lógica do frete
        }
    }
}
