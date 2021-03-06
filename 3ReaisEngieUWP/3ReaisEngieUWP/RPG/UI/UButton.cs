﻿using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.UI
{
   

    public delegate void Execute(object sender);

    public enum AnchorType
    {
        Proporcional,
        Exact
    }

    public abstract class UIEntidade
    {
        public UIElement element;
        public FrameworkElement frameworkElement;
        public Execute Action;
        public int zIndex=0;

        
        public string Nome;
        public Vector2 position = new Vector2(50,50);
        public Vector2 size {
            get { return new Vector2((float)frameworkElement.Width,(float)frameworkElement.Height); }
            set { frameworkElement.Width = value.x; frameworkElement.Height = value.y; }
        }
        
        public UIEntidade parent;
        public ManipulationModes manipulationMode { get { return element.ManipulationMode; } set { element.ManipulationMode = value; } }
        public TranslateTransform transform { get { return (TranslateTransform)element.RenderTransform; }
            protected set { element.RenderTransform = value; } }
        public AnchorType anchor = AnchorType.Proporcional;

        public virtual void Resize(float x, float y) {
            
            ((FrameworkElement)element).Width = x;
            ((FrameworkElement)element).Height = y;
            size.x = x;
            size.y = y;

        }

        protected void act(object sender, RoutedEventArgs e)
        {
            Action?.Invoke(this);
        }
    }

    public interface IUIStack
    {
        void setUiLayerProp(bool val);
        bool IsUiLayer();

        void UpdateUI();
        void addChild(UIEntidade child);
        void removeChild(UIEntidade child);
        List<UIEntidade> getChilds();
    }

    public interface IUIBackground
    {
        void setBackground(string path);
        void setBackground(string path, Stretch strech);
    }

    public class UButton : UIEntidade, IUIBackground
    {
       
        public object Content { get { return btn.Content; } set { btn.Content = value; } }

        Button btn = new Button();
        BitmapImage Normal;
        BitmapImage OnHover;
        BitmapImage OnClick;
        ImageBrush brush = new ImageBrush();


        void Start()
        {
             btn.Style = (Style)Application.Current.Resources["ButtonStyle"];
             VisualStateManager.GoToState(btn, "Normal", false);

            element = btn;
            btn.ManipulationDelta += btn_ManipulationDelta;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.RenderTransform = new TranslateTransform();
            btn.PointerEntered += btn_PointerEntered;
            btn.PointerExited += btn_PointerExited;
            btn.Click += act;
            frameworkElement = (FrameworkElement)element;
            parent = null;

        }

        public UButton(object Content, Vector2 position, Vector2 size, Execute Action = null)
        {

            Start();
            btn.ManipulationDelta += btn_ManipulationDelta;
            btn.CanDrag = true;
            btn.Content = Content;
            btn.Width = size.x;
            btn.Height = size.y;
            transform.X = position.x;
            transform.Y = position.y;
            base.position = position;
            base.size = size;
            this.Action = Action;
           
        }
        public UButton(object Content, Execute Action = null)
        {
            btn.CanDrag = true;
            btn.Content = Content;
            btn.Width = 100;
            btn.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            this.Action = Action;
            Start();
        }
        public UButton(object Content, Vector2 position, Execute Action = null)
        {
            Start();
            btn.Content = Content;
            btn.Width = 100;
            btn.Height = 50;
            transform.X = position.x;
            transform.Y = position.y;
            base.position = position;
            this.Action = Action;
            this.size = new Vector2(100, 50);
        }

        private void btn_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            position.x += (float)e.Delta.Translation.X;
            position.y += (float)e.Delta.Translation.Y;

        }
        public void setBackground(string path)
        {
            Normal = new BitmapImage(new Uri("ms-appx:/" + path));
            if (OnHover == null) OnHover = Normal;
            if (OnClick == null) OnClick = Normal;

            brush.Stretch = Stretch.UniformToFill;
            brush.ImageSource = Normal;
            btn.Background = brush;
        }
        public void setBackground(string path, Stretch strech = Stretch.Uniform)
        {
            Normal = new BitmapImage(new Uri("ms-appx:/" + path));
            if (OnHover == null) OnHover = Normal;
            if (OnClick == null) OnClick = Normal;

            brush.ImageSource = Normal;
            btn.Background = brush;
            brush.Stretch = strech;
        }
        public void setOnHover(string path)
        {
            OnHover = new BitmapImage(new Uri("ms-appx:/" + path));
        }
        public void setOnClick(string path)
        {
            OnClick = new BitmapImage(new Uri("ms-appx:/" + path));
        }
        private void btn_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (OnHover != null)
                brush.ImageSource = OnHover;
        }
        private void btn_PointerExited(object sender, PointerRoutedEventArgs e)
        {

            brush.ImageSource = Normal;
        }
        

       


    }


}