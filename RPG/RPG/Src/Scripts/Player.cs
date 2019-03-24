using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;

using Windows.UI.Xaml.Media.Imaging;

namespace RPG.Src.Scripts
{
    [RequerComponente(typeof(Colisao))]
    [RequerComponente(typeof(Render))]
    [RequerComponente(typeof(Inventario))]

    class Player :Entidade
    {
        bool mudou=false;
        Colisao col;
        float vel;

        public Player(Vector2 pos)
        {
            
            EntPos = pos;
            vel = 5;
            col = GetComponente<Colisao>();
            col.tipo = TipoColisao.Dinamica;
            AmbienteJogo.AdcionarEntidade(this);
           
        }

        public override void Update()
        {
            
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.A))
            {
                if (col.momentoDeColisao.z >= 0)
                {
                    EntPos.x -= vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
            {
                if (col.momentoDeColisao.x >= 0)
                {
                    EntPos.x += vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
            {
                if (col.momentoDeColisao.y >= 0)
                {
                    EntPos.y -= vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
            {
                if (col.momentoDeColisao.w >= 0)
                {
                    EntPos.y += vel;
                }
            }
        }

        public override void OnColide(Colisao col)
        {
            if (!mudou)
            {
                Render r = GetComponente<Render>();
                r.LoadImage("Src/dance.gif");
                mudou = true;
            }
        }
    }
}
