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
    class Piso: Entidade
    {
        public Piso(Vector2 pos)
        {
           EntPos = pos;
           Render r = GetComponente<Render>();
            r.Layer = -1;
            r.LoadImage("Src/Images/Laboratório/Lab_0004_Piso.png"); 
        }
    }
    class Block : Entidade
    {
        Colisao col;
        public Block(Vector2 pos)
        {
            EntPos = pos;
            col = AddComponente<Colisao>();
            col.tamanho.x = 50;
            col.tamanho.y = 100;
            col.tipo = TipoColisao.Estatica;

        }
    }
}
