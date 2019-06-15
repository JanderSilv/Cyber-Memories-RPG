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

    class Parede: Entidade
    {
        private Colisao col;

        public Parede(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 52;
            col.tamanho.y = 52;
            col.relativePos.y -=20;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.Layer = -1;
            r.LoadImage("Src/Images/Laboratório/Lab_Parede.png");
        }
    }
}
