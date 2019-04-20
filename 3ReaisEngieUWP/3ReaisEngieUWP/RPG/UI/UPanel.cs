using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace _3ReaisEngine.UI
{
    public class UPanel : IUIEntidade
    {
        Rectangle element = new Rectangle();
        TranslateTransform transform = new TranslateTransform();

        public Brush brush = new SolidColorBrush(Colors.Aqua);
        private Vector2 pos = new Vector2(), si = new Vector2(100, 50);
        public Vector2 position { get { return pos; } set { pos = value; transform.X = value.x; transform.Y = value.y; } }
        public Vector2 size { get { return si; } set { si = value; element.Width = value.x; element.Height = value.y; } }

        public void Content(byte Red,byte Green,byte Blue,byte Alpha )
        {
            Color C = new Color() { A = Alpha, B = Blue, R = Red, G = Green};
            brush = new SolidColorBrush(C);
        }
        public void Content(Color cor)
        {
            brush = new SolidColorBrush(cor);
        }
        public string Nome;

        public UPanel()
        {
            
            element.Fill = brush;

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 0;
            transform.Y = 0;

            element.RenderTransform = transform;



        }
        public UPanel(Vector2 pos)
        {
            element.Fill = brush;

            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            this.pos = pos;

            element.RenderTransform = transform;



        }
        public UPanel(Vector2 pos, Vector2 size)
        {

            element.Fill = brush;

            element.Width = size.x;
            element.Height = size.y;
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
