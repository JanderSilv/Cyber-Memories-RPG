using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;
using Windows.UI.Xaml.Media;

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
            r.img.Width = 64;
            r.img.Height = 64;
           
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
            r.img.Width = 64;
            r.img.Height = 64;
          
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
            r.img.Width = 64;
            r.img.Height = 64;
            AddComponente<Colisao>();
            Colisao col = GetComponente<Colisao>();
            col.tipo = TipoColisao.Dinamica;
            col.tamanho = r.size;
        }

        public override void OnClick(MouseEvento e)
        {
            UButton sair = new UButton("", EntPos, new Vector2(100, 50));
            sair.setBackground("Src/Images/Menu/Botões/Sair.png");
            sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");
            sair.anchor = AnchorType.Exact;
            AmbienteJogo.window.Add(sair, false);
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
            r.img.Width = 64;
            r.img.Height = 64;
            AddComponente<Colisao>();
            Colisao col = GetComponente<Colisao>();
            col.tipo = TipoColisao.Dinamica;
            col.tamanho = r.size;
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
            r.img.Width = 64*2;
            r.img.Height = 64*3;
            AddComponente<Colisao>();
            Colisao col = GetComponente<Colisao>();
            col.tamanho = new Vector2(64*2, 64);
            col.relativePos = new Vector2(128, 64*3);
            col.tipo = TipoColisao.Dinamica;
            
            
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
            r.img.Width = 64;
            r.img.Height = 64;
            AddComponente<Colisao>();
            Colisao col = GetComponente<Colisao>();
            col.tipo = TipoColisao.Dinamica;
            col.tamanho = r.size;
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
            r.img.Width = 64;
            r.img.Height = 64;
            AddComponente<Colisao>();
            Colisao col = GetComponente<Colisao>();
            col.tipo = TipoColisao.Dinamica;
            col.tamanho = r.size;
        }
    }

}
