
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.UI
{
    using uwpUI = Windows.UI.Xaml.Controls;

    public class UImage : IUIEntidade
    {
        uwpUI.Image element = new uwpUI.Image();
        TranslateTransform transform = new TranslateTransform();

        private Vector2 pos = new Vector2(), si = new Vector2(100, 50);
        public string Nome;
        public object Content { get { return element.Source; } set { element.Source = new BitmapImage(new Uri((string)value)); } }
        public Vector2 position { get { return pos; } set { pos = value; transform.X = value.x; transform.Y = value.y; } }
        public Vector2 size { get { return si; } set { si = value; element.Width = value.x; element.Height = value.y; } }
       
        public UImage(string Content)
        {

            element.Source = new BitmapImage(new Uri("ms-appx:/"+Content));

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 0;
            transform.Y = 0;

            element.RenderTransform = transform;

          

        }
        public UImage(string Content,Vector2 pos)
        {

            element.Source = new BitmapImage(new Uri("ms-appx:/" + Content));

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            this.pos = pos;

            element.RenderTransform = transform;



        }
        public UImage(string Content, Vector2 pos,Vector2 size)
        {

            element.Source = new BitmapImage(new Uri("ms-appx:/" + Content));

            this.si = size;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            this.pos = pos;

            element.RenderTransform = transform;



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

        public string getName()
        {
            return Nome;
        }
    }
}
