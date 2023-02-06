using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classHanabi
{
    static class ShuffleCard
    {
        private static Random rng = new Random();

        /// <summary>
        /// Permet de mélanger aléatoirement une liste
        /// </summary>
        /// <source href="https://stackoverflow.com/questions/45328423/c-sharp-randomize-list-action">03.05.2022</source>
        /// <typeparam name="T">Type de la liste</typeparam>
        /// <param name="list">liste qui sera mélanger</param>
        public static void ShuffleCards<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
