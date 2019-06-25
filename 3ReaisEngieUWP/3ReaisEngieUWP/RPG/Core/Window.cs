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
using Windows.UI.Core;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.RPG.Core
{
    public class Window
    {
        //Info das Entidades
        public List<Entidade> entidades = new List<Entidade>();
        public List<Colisao> colisores = new List<Colisao>();
        public List<Render> renders = new List<Render>();
        public List<Body> bodies = new List<Body>();
        public List<UIEntidade> uiElements = new List<UIEntidade>();
        public List<UIEntidade> gameUIElements = new List<UIEntidade>();
        CoreWindow coreWindow;
        private Panel game_layer;
        private Panel ui_layer;
        private Vector2 lastSize;
        private ulong EntidadeCount = 1;

        public float Widht { set { game_layer.Width = value; } get { return (float)game_layer.Width; } }
        public float Height { set { game_layer.Height = value; } get { return (float)game_layer.Height; } }


        public Page root;

        public Window(Page root)
        {
            coreWindow = CoreWindow.GetForCurrentThread();
            coreWindow.Activate();

            Canvas canv = new Canvas();         
            Canvas ui = new Canvas();
            Canvas.SetZIndex(canv, 0);
            Canvas.SetZIndex(ui, 10000);
            this.root = root;
            
            canv.Width = 840;
            canv.Height = 620;
            canv.Children.Add(ui);
            lastSize = new Vector2((float)canv.Width,(float)canv.Height);
         
           
            coreWindow.KeyDown += Game_KeyDown;
            coreWindow.KeyUp += Game_KeyUp;


            ui.Width = 840;
            ui.Height = 620;
           
          
            root.Height = canv.Height;
            root.Width = canv.Width;

            game_layer = canv;
            ui_layer = ui;

            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            ApplicationView.PreferredLaunchViewSize = new Size(840, 620);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
        }

    
        public MessageBox ShowMessageBox(string Titulo, string Descricao, Vector2 pos, object contentBtn1 = null, object contentBtn2 = null, Execute act1 = null, Execute act2 = null)
        {
            MessageBox mb = null;
           
                 mb = new MessageBox(Titulo, Descricao, pos, contentBtn1, contentBtn2, act1, act2, this);
                Add(mb.panel);
           
    
            return mb;
        }

        public Window(Page root, float Widht, float Height)
        {
            coreWindow = CoreWindow.GetForCurrentThread();
            Canvas canv = new Canvas();
            Canvas ui = new Canvas();
            Canvas.SetZIndex(canv, 0);
            Canvas.SetZIndex(ui, 10000);
            this.root = root;

            canv.Width = Widht;
            canv.Height = Height;
            canv.Children.Add(ui);
            
            coreWindow.KeyDown += Game_KeyDown;
            coreWindow.KeyUp += Game_KeyUp;
            ui.Width = Widht;
            ui.Height = Height;
            
          
            root.Height = canv.Height;
            root.Width = canv.Width;
         
            game_layer = canv;
            ui_layer = ui;
            lastSize = new Vector2((float)canv.Width, (float)canv.Height);


            Windows.UI.Xaml.Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
            ApplicationView.PreferredLaunchViewSize = new Size(Widht, Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Windows.UI.Xaml.Window.Current.CoreWindow.Activate();
        }

        public virtual void OnActive()
        {

        }
        public void UpdateWindow()
        {
            foreach (UIEntidade element in uiElements)
            {
                Canvas.SetZIndex(element.element, element.zIndex);
                uptPos(element);
            }

            foreach (UIEntidade element in gameUIElements)
            {
                Canvas.SetZIndex(element.element, element.zIndex);
                uptPos(element);
                TranslateTransform tt = ((TranslateTransform) element.element.RenderTransform);
                tt.X -= AmbienteJogo.currentCamera.drawOffset.x;
                tt.Y -= AmbienteJogo.currentCamera.drawOffset.y;
            }

            for (int i = 0; i < entidades.Count; i++)
            {
                if (entidades[i] != null && !entidades[i].IsStatic) entidades[i].Update();
            }
          
            for (int i = 0; i < renders.Count; i++)
            {
                if (renders[i] == null) continue;
                renders[i].transform.X = renders[i].entidade.EntPos.x - AmbienteJogo.currentCamera.drawOffset.x;
                renders[i].transform.Y = renders[i].entidade.EntPos.y - AmbienteJogo.currentCamera.drawOffset.y;
                int l = renders[i].Layer * 1000 + (int)renders[i].entidade.EntPos.y;
                Canvas.SetZIndex(renders[i].img,l);
            }
          
        }

        public void SetCurrent()
        {
            OnActive();
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
            Body b = null;

            //element.EntPos.x += Widht / 4;
            //element.EntPos.y += Height / 4;

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
                game_layer.Children.Add(r.img);
            }
            if (element.GetComponente(ref b))
            {
                bodies.Add(b);
            }
        }

        public void Add(List<Entidade> elements)
        {
            foreach (Entidade element in elements)
            {

                entidades.Add(element);
                element.ID = EntidadeCount;
                EntidadeCount++;

                Colisao c = null;
                Render r = null;
                Body b = null;
                MalhaColisao mc = null;
                //element.EntPos.x += Widht / 4;
                //element.EntPos.y += Height / 4;
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
                    game_layer.Children.Add(r.img);
                }
                if (element.GetComponente(ref b))
                {
                    bodies.Add(b);
                }
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
                Body b = null;
                MalhaColisao mc = null;
              
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
                    game_layer.Children.Add(r.img);
                }
                if (element.GetComponente(ref b))
                {
                    bodies.Add(b);
                }
            }
        }

        

        public void Add(UIEntidade element,bool UILayer = true)
        {
            

            if (UILayer==false)
            {
                if (!game_layer.Children.Contains(element.element))
                {
                    game_layer.Children.Add(element.element);
                    gameUIElements.Add(element);
                }
               
            }
            else
            {
                if (!ui_layer.Children.Contains(element.element))
                {
                    Canvas.SetZIndex(element.element, 100000 + ui_layer.Children.Count);
                    ui_layer.Children.Add(element.element);
                    uiElements.Add(element);
                }
            }

            uptPos(element);

            if (element is IUIStack)
            {
                ((IUIStack)element).setUiLayerProp(UILayer);
              
                foreach (UIEntidade i in ((IUIStack)element).getChilds()) Add(i,UILayer);
            }
            
           
        }

        public void Add(UIEntidade[] elements, bool UILayer = true)
        {
            for (int i = 0; i < elements.Length; i++) Add(elements[i],UILayer);
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

        public void Remove(UIElement element)
        {
            game_layer.Children.Remove(element);


        }
        public void SetBackground(string path)
        {
            game_layer.Background = new ImageBrush() { ImageSource = new BitmapImage(new Uri("ms-appx:" + path))};
        }
        public void Remove(UIEntidade element,bool UILayer = true)
        {
            if (UILayer == false)
            {
                game_layer.Children.Remove(element.element);
            }
            else
            {
                ui_layer.Children.Remove(element.element);
            }
            if (element is IUIStack)
            {
                foreach (UIEntidade i in ((IUIStack)element).getChilds()) Remove(i);
            }
            uiElements.Remove(element);
        }

        void uptPos(UIEntidade element)
        {
           
            UIElement e = element.element;
            UIEntidade parent = element.parent;
            e.SetValue(Canvas.HorizontalAlignmentProperty, Canvas.LeftProperty);
            e.SetValue(Canvas.VerticalAlignmentProperty, Canvas.TopProperty);
            Vector2 pos = element.position;
            Vector2 si = element.size;
            
            if (element.anchor == AnchorType.Proporcional)
            {
                if (parent != null)
                {
                   
                    Vector2 parentSi = parent.size;
                    
                    element.transform.X = parent.transform.X;
                    element.transform.Y = parent.transform.Y;

                    element.transform.X += 2 * (((pos.x / 2) / 100.0) * parentSi.x) - si.x / 2;
                    element.transform.Y += 2 * (((pos.y / 2) / 100.0) * parentSi.y) - si.y / 2;
                    
                }
                else
                {
                        element.transform.X = 2 * (((pos.x / 2) / 100.0) * Widht) - si.x / 2;
                        element.transform.Y = 2 * (((pos.y / 2) / 100.0) * Height) - si.y / 2;                 
                }
            }
            else
            {
                if (parent != null)
                {
                   
                    element.transform.X = parent.transform.X + pos.x - si.x / 2;
                    element.transform.Y = parent.transform.Y + pos.y - si.y / 2;
                   
                }
                else
                {
                    element.transform.X = pos.x - si.x / 2;
                    element.transform.Y = pos.y - si.y / 2;
                    
                }
            }
           
        }
       
       

        private void Game_KeyDown(CoreWindow sender, KeyEventArgs e)
        {
            TecladoEvento te;
            if (e.KeyStatus.WasKeyDown)
            {
                te = new TecladoEvento { Tecla = (int)e.VirtualKey, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorTecla.KeyHold };
            }
            else
            {
                te = new TecladoEvento { Tecla = (int)e.VirtualKey, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorTecla.KeyDown };
            }
            
           
            AmbienteJogo.EnviarEvento(te);

        }

        private void Game_KeyUp(CoreWindow sender, KeyEventArgs e)
        {
            if (e.KeyStatus.IsKeyReleased)
            {
                TecladoEvento te = new TecladoEvento { Tecla = (int)e.VirtualKey, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorTecla.KeyUp };
                AmbienteJogo.EnviarEvento(te);
            }
           

        }

        private void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            

            Vector2 a = new Vector2();
            a.x = (float)(args.Size.Width / game_layer.Width);
            a.y = (float)(args.Size.Height / game_layer.Height);
         
            game_layer.Width = args.Size.Width;
            game_layer.Height = args.Size.Height;

            ui_layer.Width = args.Size.Width;
            ui_layer.Height = args.Size.Height;

            root.Height = game_layer.Height;
            root.Width = game_layer.Width;

            foreach (UIElement e in ui_layer.Children)
            {

                ((TranslateTransform)e.RenderTransform).X *= a.x;
                ((TranslateTransform)e.RenderTransform).Y *= a.y;

            }

            foreach (UIEntidade element in uiElements)
            {
               
                element.Resize(element.size.x* a.x, element.size.y*a.y);
            }
            foreach (UIEntidade element in gameUIElements)
            {
                element.Resize(element.size.x* a.x, element.size.y* a.y);
            }
        }
    }
}