using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Entidades
{
    [RequerComponente(typeof(Render))]

    class PlacaDeSaida : Entidade
    {
        public PlacaDeSaida(Vector2 pos)
        {
            EntPos = pos;
            EntPos.x += 2;
            EntPos.y += 25;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_Exit.png");
        }
    }
}
