using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ReaisEngine.Components
{
   public class Itinerario : Componente<Itinerario>
    {
        public Dictionary<string, Vector2> caminho = new Dictionary<string, Vector2>();
       
    }
}

