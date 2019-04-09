using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;
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
using Windows.UI.Xaml.Media;

namespace _3ReaisEngine.RPG.Core
{
   public class Window 
    {
        public float Widht { set { game_layer.Width = value; } get { return (float)game_layer.Width;} }
        public float Height { set { game_layer.Height = value; } get { return (float)game_layer.Height; } }
        private Panel game_layer;
        private Panel ui_layer;
        private Page root;

        public Window(Page root)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            this.root = root;

            canv.Width = 840;
            canv.Height = 620;
            ui.Width = 840;
            ui.Height = 620;
            
            canv.Children.Add(ui);
           

            canv.SetValue(Canvas.ZIndexProperty, 0);
            ui.SetValue(Canvas.ZIndexProperty, 1);

            root.Content = canv;
            root.Height = canv.Height;
            root.Width = canv.Width;
            game_layer = canv;
            ui_layer = ui;

            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;
            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
        }

        public Window(Page root,float Widht,float Height)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            this.root = root;

            canv.Width = Widht;
            canv.Height = Height;
            ui.Width = Widht;
            ui.Height = Height;

            canv.Children.Add(ui);
          
            canv.SetValue(Canvas.ZIndexProperty, 0);
            ui.SetValue(Canvas.ZIndexProperty, 1);

            root.Height = canv.Height;
            root.Width = canv.Width;
            root.Content = canv;
            game_layer = canv;
            ui_layer = ui;

            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;
            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
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

        public void Add(IUIEntidade element)
        {

            UIElement e = element.getElement();
            TranslateTransform tt= ((TranslateTransform)e.RenderTransform);

            Vector2 pos = element.getPosition();
            Vector2 si = element.getSize();

            tt.X = (pos.x/2 / 100.0) * Widht;
            tt.Y = (pos.y/2 / 100.0) * Height;

            ui_layer.Children.Add(e);
        }

        public void Remove(IUIEntidade element)
        {
            ui_layer.Children.Remove(element.getElement());
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

        private void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            Debug.WriteLine(args.Size.ToString());

            Vector2 a = new Vector2();
            a.x = (float)(args.Size.Width / game_layer.Width);
            a.y = (float)(args.Size.Height / game_layer.Height);

            game_layer.Width = args.Size.Width;
            game_layer.Height = args.Size.Height;
            ui_layer.Width = args.Size.Width;
            ui_layer.Height = args.Size.Height;
            root.Height = game_layer.Height;
            root.Width = game_layer.Width;

            foreach(UIElement e in ui_layer.Children)
            {
                ((TranslateTransform)e.RenderTransform).X *= a.x;
                ((TranslateTransform)e.RenderTransform).Y *= a.y;
            }
        }
    }
}
