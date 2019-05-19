using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace _3ReaisEngine.UI
{
    public class UPanel : UIEntidade, IUIStack
    {
        Rectangle rect = new Rectangle();

        public Brush brush = new SolidColorBrush(Colors.Aqua);

        public List<UIEntidade> childs = new List<UIEntidade>();


        public void start()
        {
            rect.Fill = brush;
            rect.HorizontalAlignment = HorizontalAlignment.Left;
            rect.VerticalAlignment = VerticalAlignment.Top;
            rect.ManipulationDelta += rect_ManipulationDelta;
            rect.RenderTransform = transform;
            element = rect;
        }

        public UPanel()
        {
           
            rect.Width = 100;
            rect.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            start();

        }



        public UPanel(Vector2 pos)
        {
            
            rect.Width = 100;
            rect.Height = 50;
            position = pos;
            start();

        }
        public UPanel(Vector2 pos, Vector2 size)
        {

            
            rect.Width = size.x;
            rect.Height = size.y;
            this.size = size;
            position = pos;
            start();
        }

        public void Content(byte Red, byte Green, byte Blue, byte Alpha)
        {
            Color C = new Color() { A = Alpha, B = Blue, R = Red, G = Green };
            brush = new SolidColorBrush(C);
        }
        public void Content(Color cor)
        {
            brush = new SolidColorBrush(cor);
        }

        public void addChild(UIEntidade child)
        {
            child.parent = this;
            childs.Add(child);
        }

        public void removeChild(UIEntidade child)
        {
            child.parent = null;
            childs.Remove(child);
        }

        public List<UIEntidade> getChilds()
        {
            return childs;
        }

        private void rect_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            position.x += (float)e.Delta.Translation.X;
            position.y += (float)e.Delta.Translation.Y;
        }

    }
}
