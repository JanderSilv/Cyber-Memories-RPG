using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Movel:Componente<Movel>
{
    public Colisao col;
    
    public bool Mover(float x, float y)
    {
        if (col == null)
        {
            entidade.EntPos.x += x;
            entidade.EntPos.y += y;
            return true;
        }

        bool m = false;
        
        if (x < 0) if (col.momentoDeColisao.z == 0){ entidade.EntPos.x += x; m = true; }
        if (x > 0) if (col.momentoDeColisao.x == 0) entidade.EntPos.x += x;m = true;

        if (y < 0) if (col.momentoDeColisao.w == 0) { entidade.EntPos.y += y; m = true; }
        if (y > 0) if (col.momentoDeColisao.y == 0) { entidade.EntPos.y += y; m = true; }
        return m;
    }

    public bool Mover(Vector2 direcao)
    {
        if (col == null)
        {
            entidade.EntPos += direcao;
            return false;
        }

        bool m = false;
       
        if (direcao.x < 0) if (col.momentoDeColisao.z == 0) { entidade.EntPos.x += direcao.x; m = true; }
        if (direcao.x > 0) if (col.momentoDeColisao.x == 0) entidade.EntPos.x += direcao.x; m = true;

        if (direcao.y < 0) if (col.momentoDeColisao.w == 0) { entidade.EntPos.y += direcao.y; m = true; }
        if (direcao.y > 0) if (col.momentoDeColisao.y == 0) { entidade.EntPos.y += direcao.y; m = true; }
        return m;
    }

   
}

