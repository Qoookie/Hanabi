using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HanabiServeur
{
    public static class SystemExtension
    {
        /// <summary>
        /// Permet de cloner un objet
        /// Utilise la meme liste mais avec une différente instance
        /// Cette méthode est utilié pour creer un monde personnel a chaque personne.
        /// Dans la partie que le client reçoit, il sera toujours le joueur 0.
        /// </summary>
        /// <source href="https://www.wwt.com/article/how-to-clone-objects-in-dotnet-core">05.05.2022</source>
        /// <typeparam name="T">type de la liste (n'importe)</typeparam>
        /// <param name="list">Liste a dupliquer</param>
        /// <returns></returns>
        public static T Clone<T>(this T list)
        {
            string serialized = JsonConvert.SerializeObject(list);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
