using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace _3ReaisEngine.RPG.Core
{
   public class Window 
    {
        //Info das Entidades
        public List<Entidade> entidades = new List<Entidade>();
        public List<Colisao> colisores = new List<Colisao>();
        public List<Render> renders = new List<Render>();
      

        private Panel game_layer;
        private Panel ui_layer;

        private ulong EntidadeCount = 1;
        public float Widht { set { game_layer.Width = value; } get { return (float)game_layer.Width;} }
        public float Height { set { game_layer.Height = value; } get { return (float)game_layer.Height; } }

       
        public Page root;

        public Window(Page root)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            this.root = root;

            canv.Width = 840;
            canv.Height = 620;
            canv.Children.Add(ui);
            
            canv.SetValue(Canvas.ZIndexProperty, 0);
            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;
            canv.PointerPressed += Game_PointerPressed;
            canv.PointerReleased += Game_PointerReleased;

            

            ui.Width = 840;
            ui.Height = 620;
            ui.SetValue(Canvas.ZIndexProperty, 1);
            ui.PointerPressed += Game_PointerPressed;
            ui.PointerReleased += Game_PointerReleased;
            
           // root.Content = canv;
            root.Height = canv.Height;
            root.Width = canv.Width;

            game_layer = canv;
            ui_layer = ui;

            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            ApplicationView.PreferredLaunchViewSize = new Size(840, 620);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
        }
        public Window(Page root,float Widht,float Height)
        {
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();

            this.root = root;

            canv.Width = Widht;
            canv.Height = Height;
            canv.Children.Add(ui);
            canv.SetValue(Canvas.ZIndexProperty, 0);
            canv.KeyDown += Game_KeyDown;
            canv.KeyUp += Game_KeyUp;
            canv.PointerPressed += Game_PointerPressed;
            canv.PointerReleased += Game_PointerReleased;

            ui.Width = Widht;
            ui.Height = Height;
            ui.SetValue(Canvas.ZIndexProperty, 1);
            ui.PointerPressed += Game_PointerPressed;
            ui.PointerReleased += Game_PointerReleased;

            root.Height = canv.Height;
            root.Width = canv.Width;
           // root.Content = canv;

            game_layer = canv;
            ui_layer = ui;

           
            
            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            ApplicationView.PreferredLaunchViewSize = new Size(Widht, Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
        }

        public void SetCurrent() {
            root.Content = game_layer;
            AmbienteJogo.window = this;
        }
      
        public void Add(Entidade element)
        {
           
            entidades.Add(element);
            element.ID = EntidadeCount;
            EntidadeCount++;

            Colisao c = null;
            Render r = null;
            MalhaColisao mc = null;

            element.EntPos.x += Widht / 4;
            element.EntPos.y += Height / 4;

            if (element.GetComponente(ref mc))
            {
                colisores.AddRange(mc.colisoes);
            }
            if (element.GetComponente(ref c))
            {
                colisores.Add(c);
            }
            if (element.GetComponente(ref r))
            {
                renders.Add(r);
                Add(r.img);
            }
        }

        public void Add(Entidade[] elements)
        {
            foreach (Entidade element in elements)
            {
              
                entidades.Add(element);
                element.ID = EntidadeCount;
                EntidadeCount++;

                Colisao c = null;
                Render r = null;
                MalhaColisao mc = null;
                element.EntPos.x += Widht / 4;
                element.EntPos.y += Height / 4;
                if (element.GetComponente(ref mc))
                {
                    colisores.AddRange(mc.colisoes);
                }
                if (element.GetComponente(ref c))
                {
                    colisores.Add(c);
                }
                if (element.GetComponente(ref r))
                {
                    renders.Add(r);
                    Add(r.img);
                }
            }
        }

        public void Remove(Entidade element)
        {
            entidades.Remove(element);
            Colisao c = null;
            Render r = null;
            if (element.GetComponente(ref c))
            {
                colisores.Remove(c);
            }
            if (element.GetComponente(ref r))
            {
                renders.Remove(r);
                Remove(r.img);
            }
        }
        
        public void Add(UIElement element)
        {
            game_layer.Children.Add(element);
        }

        public void Remove(UIElement element)
        {
            game_layer.Children.Remove(element);
        }

        public void AddUI(IUIEntidade element)
        {

            UIElement e = element.getElement();
            e.SetValue(Canvas.HorizontalAlignmentProperty, Canvas.LeftProperty);
            e.SetValue(Canvas.VerticalAlignmentProperty, Canvas.TopProperty);

                TranslateTransform tt= ((TranslateTransform)e.RenderTransform);

                Vector2 pos = element.getPosition();
                Vector2 si = element.getSize();

               tt.X = 2*(((pos.x/2)/ 100.0) * Widht) - si.x/2;
            tt.Y = 2 * (((pos.y / 2) / 100.0) * Height) - si.y/2;

            ui_layer.Children.Add(e);
        }

        public void Remove(IUIEntidade element)
        {
            ui_layer.Children.Remove(element.getElement());
        }



        private void Game_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Pointer ptr = e.Pointer;
            PointerPoint ptrPt = e.GetCurrentPoint(game_layer);
            MouseEvento me = new MouseEvento();
            me.Tipo = Modificador.ButtonUp;
            me.Modificador = e.KeyModifiers;
            me.Position = new Vector2((float)ptrPt.Position.X, (float)ptrPt.Position.Y);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                me.Botao = MouseButton.Left;
            }
            if (ptrPt.Properties.IsMiddleButtonPressed)
            {
                me.Botao = MouseButton.Scroll;
            }
            if (ptrPt.Properties.IsRightButtonPressed)
            {
                me.Botao = MouseButton.Right;
            }

            
            AmbienteJogo.EnviarEvento(me);
        }

        private void Game_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
            Pointer ptr = e.Pointer;
            PointerPoint ptrPt = e.GetCurrentPoint(game_layer);
            MouseEvento me = new MouseEvento();
            me.Tipo = Modificador.ButtonDown;
            me.Modificador = e.KeyModifiers;
            me.Position = new Vector2((float)ptrPt.Position.X, (float)ptrPt.Position.Y);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                me.Botao = MouseButton.Left;
            }
            if (ptrPt.Properties.IsMiddleButtonPressed)
            {
                me.Botao = MouseButton.Scroll;
            }
            if (ptrPt.Properties.IsRightButtonPressed)
            {
                me.Botao = MouseButton.Right;
            }
            AmbienteJogo.EnviarEvento(me);
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
