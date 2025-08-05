using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Introduction
{
    /// <summary>
    /// Ambas as funções fazem a mesma coisa, mas qual é melhor para manutenção?
    /// </summary>
    public class Example1
    {
        /// <summary>
        /// O que isso faz?
        /// </summary>
        /// <param name="d"></param>
        public bool FunctionA(int d)
        {
            return d < 120;            
        }

        /// <summary>
        /// Note que o nome da função é mais claro, você sabe que o que ela faz só de bater o olho.
        /// Poderia deixar mais enxuto o código? Sim, claro! Mas isso reduziria a clareza.
        /// É melhor um código mais fácil de ler e dar manutenção. Economizar palavras ou pequenas estruturas pode parecer algo legal,
        /// mas quando você precisar dar manutenção voltando no futuro para esse código, quanto mais organizado e explicado, melhor!
        /// </summary>
        /// <param name="daysSinceLastBackup"></param>
        /// <returns></returns>
        public bool IsDayForBackup(int daysSinceLastBackup)
        {
            const int MAX_DURATION_IN_DAYS = 120;

            if (daysSinceLastBackup < MAX_DURATION_IN_DAYS)            
                return true;            

            return false;
        }
    }
}
