using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;

[RequerComponente(typeof(Colisao))]
[RequerComponente(typeof(Render))]
[RequerComponente(typeof(Animacao))]
[RequerComponente(typeof(Inventario))]
[RequerComponente(typeof(Status))]
[RequerComponente(typeof(Movel))]

class Player : Entidade
{
    readonly Animacao anim;
    readonly Render render;
    readonly Colisao col;
    readonly Movel mov;

    float vel;  
    bool dead = false;

    public Player(Vector2 pos)
    {
        AddComponente<Mercador>();
        Nome = "Tust";
        EntPos = pos;
        vel = 5;

        col = GetComponente<Colisao>();
        render = GetComponente<Render>();
        anim = GetComponente<Animacao>();
        mov = GetComponente<Movel>();
        mov.col = col;

        col.tipo = TipoColisao.Dinamica;
        col.onColisionAction += OnColide;
      

        anim.AddAnimation("Idle", "Src/Animations/idle.gif");
        anim.AddAnimation("Dead", "Src/Animations/dead.gif");
        anim.AddAnimation("JaDead", "Src/Animations/Dead.png");
        anim.AddAnimation("Walk", "Src/Animations/walk.gif");
        anim.Play("Idle",render);

      
     

    }

    public override void Update()
    {

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.A))
        {
            if (mov.Mover(-vel,0))
            {
                dead = false;
                anim.Play("Walk", render);
            }
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.A))
        {
            anim.Play("Idle", render);
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
        {
            if (mov.Mover(vel, 0))
            {
                dead = false;
                anim.Play("Walk", render);
            }
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.D))
        {
            anim.Play("Idle", render);
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
        {
            if (mov.Mover(0, -vel))
            {
                dead = false;
                anim.Play("Walk", render);
            }
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.W))
        {
            anim.Play("Idle", render);
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
        {
            if (mov.Mover(0, vel))
            {
                dead = false;
                anim.Play("Walk", render);
            }
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.S))
        {
           
            anim.Play("Idle", render);
        }

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.Escape))
        {
            if (!dead)
            {
                anim.Play("Dead", render);
                anim.Play("JaDead", render);
                dead = true;
            }
            else
            {
                anim.Play("JaDead", render);
            } 
        }
    }

    public void OnColide(Colisao col)
    {
        anim.Play("Idle", render);
    }

   
}

