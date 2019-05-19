using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts
{
    
    public class Undead : Entidade
    {
        Render render;
        Colisao colider;
        Animacao anim;
        Movel mob;
        Itinerario caminho;

        public Undead(Vector2 pos)
        {
            
            AddComponente<Render>();
            AddComponente<Colisao>();
            AddComponente<Animacao>();
            AddComponente<Movel>();
            AddComponente<Itinerario>();

            mob = GetComponente<Movel>();
            anim = GetComponente<Animacao>();
            render = GetComponente<Render>();
            colider = GetComponente<Colisao>();
            caminho = GetComponente<Itinerario>();

            render.img.Width = 128;
            render.img.Height = 128*1.5f;

            colider.tamanho = render.size;
            colider.ignoreTypes.Add(typeof(Undead));
            EntPos = pos;
            colider.tipo = TipoColisao.Dinamica;
          

            caminho.AddPos("Esq", new Vector2(400,50));
            caminho.AddPos("Dir", new Vector2(200, 50));
            caminho.Conect("Esq", "Dir");

            anim.AddAnimation("attack", "Src/Sprites/Zumbi/undead_attack.gif");
            anim.AddAnimation("death", "Src/Sprites/Zumbi/undead_death.gif");
            anim.AddAnimation("hurt", "Src/Sprites/Zumbi/undead_hurt.gif");
            anim.AddAnimation("idle", "Src/Sprites/Zumbi/undead_idle.gif");
            anim.AddAnimation("walk", "Src/Sprites/Zumbi/undead_walk.gif");
            anim.Play("idle", render);
        }

        public override void Update()
        {
            

          if (Engine.Distance(EntPos, MainPage.p.EntPos) < 65)
            {
                anim.Play("attack", render);
            }
            else
            {
                mob.MoveTo(MainPage.p.EntPos, 4);
                anim.Play("walk", render);
            }

        }

    }
}
