using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;


namespace RPG.Src.Scripts
{
    [RequerComponente(typeof(Render))]
    public class Areia: Entidade
    {
        public Areia(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/areia.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Grama : Entidade
    {
        public Grama(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/grama.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Tronco : Entidade
    {
        public Tronco(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/tronco.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Flores : Entidade
    {
        public Flores(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/flores.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Arvore : Entidade
    {
        public Arvore(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/arvore.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Rocha1 : Entidade
    {
        public Rocha1(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/rocha1.png");
        }
    }

    [RequerComponente(typeof(Render))]
    public class Rocha2 : Entidade
    {
        public Rocha2(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/tiles/rocha2.png");
        }
    }

}
