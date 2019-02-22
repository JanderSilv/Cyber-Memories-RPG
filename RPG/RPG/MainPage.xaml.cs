using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Events;
using System.Threading;
using Windows.UI.Core;
using _3ReaisEngine.RPG.Core;
using System;
using Windows.UI.Xaml.Media;
using System.Threading.Tasks;
using RPG.Src.Scripts;
using _3ReaisEngine.RPG.Components;
using _3ReaisEngieUWP.RPG.Components;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace RPG
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Player p;
        Colisao c;
         public MainPage()
        {
          
            this.InitializeComponent();
        
            AmbienteJogo.gerenciadorEventos.handleTeclado[(int)PrioridadeEvento.Interface] += KeyE;      
            AmbienteJogo.Init(Canvas);

            p = new Player();
            c = p.GetComponente<Colisao>();
            Player p2  = new Player();

            p2.Posicao.x = 235;
            p2.Posicao.y = 100;
            txt_cxPos.Text = p2.Posicao.ToString();
            AmbienteJogo.Execute(60, LateUpdate);
        }

        public void LateUpdate()
        {
            txt_ciclo.Text = AmbienteJogo.time.ToString();
            txt_colisao.Text = c.momentoDeColisao.ToString();
            txt_playerPos.Text = p.Posicao.ToString();
        }
       
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private bool KeyE(TecladoEvento e)
        {
         
          
            if (e.Tecla == (int)Windows.System.VirtualKey.A)
            {
                if (c!=null && c.momentoDeColisao.z >= 0)
                    p.Posicao.x -= 1;             
            }
            if (e.Tecla == (int)Windows.System.VirtualKey.D)
            {
                if (c != null &&  c.momentoDeColisao.x >= 0)
                    p.Posicao.x += 1;
            }
            if(e.Tecla == (int)Windows.System.VirtualKey.W)
            {
                if (c != null && c.momentoDeColisao.y >= 0)
                    p.Posicao.y -= 1;
            }
            if (e.Tecla == (int)Windows.System.VirtualKey.S)
            {
                if (c != null && c.momentoDeColisao.w >= 0)
                    p.Posicao.y += 1;
            }

            return false;
        }
       

        private void Canvas_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyDown };
            AmbienteJogo.gerenciadorEventos.Enviar(te);
         
        }

        private void Canvas_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyUp };
            AmbienteJogo.gerenciadorEventos.Enviar(te);

        }

        private void Canvas_Unloaded(object sender, RoutedEventArgs e)
        {
            //AmbienteJogo.Run = false;
        }
    }
}
