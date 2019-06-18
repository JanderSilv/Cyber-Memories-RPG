using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[RequerComponente(typeof(Body))]
public class Movel:Componente<Movel>
{
    
    public Body bod;
    public override void Init()
    {
        
        bod = entidade.GetComponente<Body>();
    }

    public void Mover(float x, float y)
    {

        bod.velocity.x = x;
        bod.velocity.y = y;
       
     
    }

   public void MoveTo(Vector2 target,float vel)
    {
       
            if (target.x < entidade.EntPos.x)  bod.velocity.x = -vel;
            if (target.x > entidade.EntPos.x)  bod.velocity.x = vel;
            if (target.y < entidade.EntPos.y)  bod.velocity.y = -vel;
            if (target.y > entidade.EntPos.y)  bod.velocity.y = vel;
        
    }

    public bool Mover(Vector2 direcao)
    {
        bool m = false;
       
        if (direcao.x < 0)  { bod.velocity.x = direcao.x; m = true; }
        if (direcao.x > 0)  { bod.velocity.x = direcao.x; m = true; }

        if (direcao.y < 0)  { bod.velocity.y = direcao.y; m = true; }
        if (direcao.y > 0)  { bod.velocity.y = direcao.y; m = true; }
        return m;
    }

   
}

