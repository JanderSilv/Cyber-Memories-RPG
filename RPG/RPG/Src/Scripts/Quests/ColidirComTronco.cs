using _3ReaisEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ColidirComTronco : Quest
{
    public ColidirComTronco()
    {
        Nome = "Andando ao acaso";
        Descricao = "Colida com um tronco 3 vezes";
        Data.Add("Colidiu", 0);
    }

    public override bool Validate()
    {
        return Data["Colidiu"]>3;
    }

    public override void OnFinish()
    {
        Engine.Print("Quest finalizada");
        
    }
}

