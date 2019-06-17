using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{
    UPanel screen;
    public virtual void Start(UPanel scr)
    {
        screen = scr;
    }

    public virtual void UpdateGame()
    {

    }

    public virtual void Close()
    {

    }

}

