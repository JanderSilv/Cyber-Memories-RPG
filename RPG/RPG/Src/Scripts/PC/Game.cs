using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{
    protected UPanel screen;
    public Input teclado;
    public bool run;

    public Game(UPanel scr)
    {
        screen = scr;
    }

    public virtual void Render()
    {

    }
    public virtual void Start()
    {
        
    }

    public virtual void UpdateGame()
    {

    }

    public virtual void Close()
    {

    }

    public virtual void KeyBoardUpdate()
    {
       
    }

}

