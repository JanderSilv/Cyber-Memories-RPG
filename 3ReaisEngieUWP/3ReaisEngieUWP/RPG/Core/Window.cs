using _3ReaisEngine.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace _3ReaisEngine.RPG.Core
{
   public class Window 
    {
        public float Widht { set { game_layer.Width = value; } get { return (float)game_layer.Width;} }
        public float Height { set { game_layer.Height = value; } get { return (float)game_layer.Height; } }
        private Panel game_layer;
        private Panel ui_layer;

        public Window(Page root)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            canv.Width = 840;
            canv.Height = 620;
            ui.Width = 840;
            ui.Height = 620;

            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;

            canv.Children.Add(ui);
            canv.Children.Add(new Button());

            canv.SetValue(Canvas.ZIndexProperty, 0);
            ui.SetValue(Canvas.ZIndexProperty, 1);

            root.Content = canv;
            root.Height = canv.Height;
            root.Width = canv.Width;
            game_layer = canv;
        }
        public Window(Page root,float Widht,float Height)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            canv.Width = Widht;
            canv.Height = Height;
            ui.Width = Widht;
            ui.Height = Height;

            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;

            canv.Children.Add(ui);
            canv.Children.Add(new Button());

            canv.SetValue(Canvas.ZIndexProperty, 0);
            ui.SetValue(Canvas.ZIndexProperty, 1);

            root.Height = canv.Height;
            root.Width = canv.Width;
            root.Content = canv;
            game_layer = canv;
        }

        public void SetPanel(Panel panel)
        {
            this.game_layer = panel;
        }

        public void Add(UIElement element)
        {
            game_layer.Children.Add(element);
        }
        public void Remove(UIElement element)
        {
            game_layer.Children.Remove(element);
        }

        private void Game_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyDown };
            AmbienteJogo.EnviarEvento(te);
           
        }

        private void Game_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyUp };
            AmbienteJogo.EnviarEvento(te);
           
        }

    }
}
