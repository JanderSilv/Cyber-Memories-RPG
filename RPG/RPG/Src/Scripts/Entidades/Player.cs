using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player:Entidade
{
    public Animacao anim;
    Body body;
    Render render;
    public Player()
    {
        anim = AddComponente<Animacao>();
        body = AddComponente<Body>();
        render = GetComponente<Render>();
        render.img.Width = 50;
        render.img.Height = 50;
    }

    public override void Update()
    {
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
        {
            body.velocity.y = -5;
            anim.Play("Move_Up");
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
        {
            body.velocity.y = 5;
            anim.Play("Move_Down");
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.A))
        {
            body.velocity.x = -5;
            anim.Play("Move_Left");
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
        {
            body.velocity.x = 5;
            anim.Play("Move_Right");
        }
    }
}

