using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace _3ReaisEngine.UI
{
    public class UText : IUIEntidade
    {
        TextBlock element = new TextBlock();
        TranslateTransform transform = new TranslateTransform();

        private Vector2 pos = new Vector2(), si = new Vector2(100, 50);
        public Vector2 position { get { return pos; } set { pos = value; transform.X = value.x; transform.Y = value.y; } }
        public Vector2 size { get { return si; } set { si = value; element.Width = value.x; element.Height = value.y; } }
        public string content { get { return element.Text; } set { element.Text = value; } }
        public string Nome;

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
        public string getName()
        {
            return Nome;
        }

        public UText()
        {
            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 100;
            transform.Y = 100;

            element.Text = "UText";

            element.RenderTransform = transform;
        }
        public UText(string text)
        {
            element.Width = 100;
            element.Height = 50;
            
            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 0;
            transform.Y = 0;

            element.Text = text;

            element.RenderTransform = transform;
        }
        public UText(string text,Vector2 position)
        {

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;

            element.Text = text;
            element.RenderTransform = transform;
          
        }
        public UText(string text,Vector2 position, Vector2 size)
        {
            element.Width = size.x;
            element.Height = size.y;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;
            si = size;

            element.Text = text;
            element.RenderTransform = transform;
          
        }

    }
}
