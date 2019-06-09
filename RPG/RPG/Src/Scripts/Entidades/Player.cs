using System;
using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using RPG.Src.Scripts;

[RequerComponente(typeof(Colisao))]
[RequerComponente(typeof(Body))]
[RequerComponente(typeof(Render))]
[RequerComponente(typeof(Animacao))]
[RequerComponente(typeof(Inventario))]
[RequerComponente(typeof(Status))]
[RequerComponente(typeof(Movel))]
[RequerComponente(typeof(QuestSystem))]
public class Player : Entidade
{
    readonly Body body;
    readonly Animacao anim;
    readonly Render render;
    readonly Colisao col;
    readonly QuestSystem quests;
    public float vel;  
    public bool dead = false;
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
        anim = GetComponente<Animacao>();;
        body = GetComponente<Body>();
        quests = GetComponente<QuestSystem>();
        quests.OnNewQuest = newQuest;
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

    private void newQuest(Quest q)
    {
        Engine.Debug("New Quest added: " + q.Nome);
    }

    public override void Update()
    {
        quests.UpdateQuest();
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
        if(col.entidade is Tronco)
        {

            Quest q = quests.GetQuestAtiva("Andando ao acaso");
            if (q != null) q.Data["Colidiu"] +=1;
        }
       
    }

   
}

