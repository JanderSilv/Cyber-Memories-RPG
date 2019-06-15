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

    class Planta: Entidade
    {
        Colisao col;
        public Planta(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 30;
            col.tamanho.y = 50;
            col.relativePos.x -= 10;
            col.relativePos.y -= 20;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0008_Planta.png");
        }
    }
}
