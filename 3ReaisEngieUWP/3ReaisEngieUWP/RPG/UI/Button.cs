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

namespace _3ReaisEngine.UI
{
    using uwpUI = Windows.UI.Xaml.Controls;

    public delegate void Execute();

    public interface IUIEntidade
    {
        UIElement getElement();
        Vector2 getPosition();
        Vector2 getSize();
    }

    public class UButton: IUIEntidade
    {
        uwpUI.Button element = new uwpUI.Button();
        TranslateTransform transform = new TranslateTransform();

        private Vector2 pos = new Vector2(), si = new Vector2(100,50);

        public object Content { get { return element.Content; } set { element.Content = value; } }
        public Vector2 position { get { return pos; } set { pos = value; transform.X = value.x; transform.Y = value.y; } }
        public Vector2 size { get { return si; } set { si = value; element.Width = value.x; element.Height = value.y; } }
        public Execute Action;

        public UButton(object Content, Execute Action = null)
        {
           
            element.Content = Content;

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 0;
            transform.Y = 0;
        
            element.RenderTransform = transform;

            this.Action = Action;
            element.Click += act;

        }

        public UButton(object Content,Vector2 position, Execute Action = null)
        {
            element.Content = Content;

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;

            element.RenderTransform = transform;

            this.Action = Action;
            element.Click += act;

        }

        public UButton(object Content, Vector2 position,Vector2 size, Execute Action = null)
        {
            element.Content = Content;

            element.Width = size.x;
            element.Height = size.y;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;
            si = size;

            element.RenderTransform = transform;

            this.Action = Action;
            element.Click += act;
        }

        private void act(object sender, RoutedEventArgs e)
        {
            Action?.Invoke();
        }

        public UIElement getElement()
        {
            return element;
        }

        public Vector2 getPosition()
        {
            return pos;
        }

        public Vector2 getSize()
        {
            return si;
        }
    }
}
