using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;

[RequerComponente(typeof(Colisao))]
[RequerComponente(typeof(Body))]
[RequerComponente(typeof(Render))]
[RequerComponente(typeof(Animacao))]
[RequerComponente(typeof(Inventario))]
[RequerComponente(typeof(Status))]
[RequerComponente(typeof(Movel))]

public class Player : Entidade
{
    readonly Body body;
    readonly Animacao anim;
    readonly Render render;
    readonly Colisao col;
    readonly Movel mov;

    float vel;  
  

    public Player(Vector2 pos)
    {
        
        AddComponente<Mercador>();
        Nome = "Tust";
        EntPos = pos;
        vel = 6;

        col = GetComponente<Colisao>();
        render = GetComponente<Render>();
        anim = GetComponente<Animacao>();
        mov = GetComponente<Movel>();
        body = GetComponente<Body>();
        body.drag = vel;

        col.tipo = TipoColisao.Dinamica;
        col.onColisionAction += OnColide;
        col.tamanho.x = 40;

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
            body.velocity.x = -vel;
         
            anim.Play("Walk", render);
            
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.A))
        {      
            anim.Play("Idle", render);
        }

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
        {
            body.velocity.x = vel;
 
            anim.Play("Walk", render);
            
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.D))
        {          
            anim.Play("Idle", render);
        }

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
        {
            body.velocity.y = -vel;
          
            anim.Play("Walk", render);
            
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.W))
        {
          
            anim.Play("Idle", render);
        }

        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
        {
            body.velocity.y = vel;
         
            anim.Play("Walk", render);
            
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.S))
        {
            anim.Play("Idle", render);
        }

     
    }
    public override void OnClick(MouseEvento e)
    {
        Engine.Debug("player aqui");
    }
    public void OnColide(Colisao col)
    {
        anim.Play("Idle", render);
       
    }

   
}

