using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Components;
using _3ReaisEngine.RPG.Core;

using Windows.UI.Xaml.Media.Imaging;

namespace RPG.Src.Scripts
{
    class Player :Entidade
    {
        bool mudou=false;
        Colisao col;
        float vel;
        public Player(Vector2 pos)
        {
            //col = new Colisao();
           // col.tipo = TipoColisao.Dinamica;
          //  AddComponente(col);
            AddComponente<Render>();
            Posicao = pos;
            vel = 15;

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
                    Posicao.x -= vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.D))
            {
                if (col.momentoDeColisao.x >= 0)
                {
                    Posicao.x += vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.W))
            {
                if (col.momentoDeColisao.y >= 0)
                {
                    Posicao.y -= vel;
                }
            }
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.S))
            {
                if (col.momentoDeColisao.w >= 0)
                {
                    Posicao.y += vel;
                }
            }
        }

        public override void OnColide(Colisao col)
        {
            if (!mudou)
            {
                Render r = GetComponente<Render>();
                r.img.Source = new BitmapImage(new System.Uri("ms-appx:/Src/dance.gif"));
                mudou = true;
            }
        
        }
    }
}
