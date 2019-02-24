using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Events;
using _3ReaisEngine.RPG.Core;
using RPG.Src.Scripts;
using _3ReaisEngine.RPG.Components;

using System;
using System.Diagnostics;

namespace RPG
{
   
    public sealed partial class MainPage : Page
    {
        Player p;
        Colisao c;
         public MainPage()
        {
          
            this.InitializeComponent();

       
            
            AmbienteJogo.Init(Canvas);
            AmbienteJogo.Execute(120, LateUpdate);

            p = new Player(new Vector2(60, 60));
            c = p.GetComponente<Colisao>();
            p.GetComponente<Render>();

            Caixa cx = new Caixa(new Vector2(160,160));
                  
        }

        public void LateUpdate()
        {
            txt_ciclo.Text = AmbienteJogo.time.ToString();
            txt_colisao.Text = c.momentoDeColisao.ToString();
            txt_playerPos.Text = p.Posicao.ToString();
        }
       
        private void Canvas_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyDown };
            AmbienteJogo.EnviarEvento(te);
         
        }

        private void Canvas_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyUp };
            AmbienteJogo.EnviarEvento(te);

        }

        private void Canvas_Unloaded(object sender, RoutedEventArgs e)
        {
            //AmbienteJogo.Run = false;
        }
    }
}
