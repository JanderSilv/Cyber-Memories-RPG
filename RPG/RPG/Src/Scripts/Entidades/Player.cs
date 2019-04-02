using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;

[RequerComponente(typeof(Colisao))]
[RequerComponente(typeof(Render))]
[RequerComponente(typeof(Inventario))]
[RequerComponente(typeof(Status))]
class Player : Entidade, Atacavel
{
    bool mudou = false;
    Colisao col;
    float vel;
    Arco arc;
    public Player(Vector2 pos)
    {
        AddComponente<Mercador>();
        Nome = "Tust";
        EntPos = pos;
        vel = 5;
        col = GetComponente<Colisao>();
        col.tipo = TipoColisao.Dinamica;
        arc = new Arco();

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
               // Engine.Debug("A");
            }
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
        {
            if (col.momentoDeColisao.x == 0)
            {
                 EntPos.x += vel;
                AmbienteJogo.currentCamera.delta.x += vel;
              //  Engine.Debug(col.momentoDeColisao.x);
            }
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
        {
            if (col.momentoDeColisao.y == 0)
            {
               EntPos.y -= vel;
                AmbienteJogo.currentCamera.delta.y -= vel;
              //  Engine.Debug("W");
            }
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
        {
            if (col.momentoDeColisao.w == 0)
            {
                EntPos.y += vel;
                AmbienteJogo.currentCamera.delta.y += vel;
              //  Engine.Debug("S");
            }
        }
    }

    public override void OnColide(Colisao col)
    {
        if (!mudou)
        {
            Render r = GetComponente<Render>();
            r.LoadImage("Src/dance.gif");
            mudou = true;
        }
    }

    public void Atacar(Status e)
    {
        Engine.Debug("Atacando oponente");

        arc.Atacar(e);
    }
}

