using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;

[RequerComponente(typeof(Colisao))]
[RequerComponente(typeof(Render))]
[RequerComponente(typeof(Animacao))]
[RequerComponente(typeof(Inventario))]
[RequerComponente(typeof(Status))]
class Player : Entidade, Atacavel
{
    bool mudou = false;
    Colisao col;
    Animacao anim;
    Render render;
    float vel;
    Arco arc;
    bool dead = false;

    public Player(Vector2 pos)
    {
        AddComponente<Mercador>();
        Nome = "Tust";
        EntPos = pos;
        vel = 5;
        col = GetComponente<Colisao>();
        col.tipo = TipoColisao.Dinamica;
        arc = new Arco();
        anim = new Animacao();
        render = GetComponente<Render>();
        anim.AddAnimation("Idle", "Src/Animations/idle.gif");
        anim.AddAnimation("Dead", "Src/Animations/dead.gif");
        anim.AddAnimation("JaDead", "Src/Animations/Dead.png");
        anim.AddAnimation("Walk", "Src/Animations/walk.gif");
        anim.Play("Idle",render);
        AmbienteJogo.AdcionarEntidade(this);

    }

    public override void Update()
    {

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.A))
        {
            if (col.momentoDeColisao.z == 0)
            {
                 EntPos.x -= vel;
                AmbienteJogo.currentCamera.delta.x -= vel;
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
            if (col.momentoDeColisao.x == 0)
            {
                 EntPos.x += vel;
                AmbienteJogo.currentCamera.delta.x += vel;
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
            if (col.momentoDeColisao.y == 0)
            {
               EntPos.y -= vel;
                AmbienteJogo.currentCamera.delta.y -= vel;
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
            if (col.momentoDeColisao.w == 0)
            {
                EntPos.y += vel;
                AmbienteJogo.currentCamera.delta.y += vel;
                dead = false;
                anim.Play("Walk", render);
            }
        }
         if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.S))
        {
            Engine.Debug("Tecla solta: A");
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

    public override void OnColide(Colisao col)
    {
        anim.Play("Idle", render);
        if (!mudou)
        {
            Render r = GetComponente<Render>();
            mudou = true;
        }
    }

    public void Atacar(Status e)
    {
        Engine.Debug("Atacando oponente");

        arc.Atacar(e);
    }
}

