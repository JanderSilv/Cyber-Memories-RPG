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

namespace _3ReaisEngine.UI
{
    public class UText : UIEntidade
    {
        TextBlock txt = new TextBlock();

        public string content { get { return txt.Text; } set { txt.Text = value; } }
        public float fontSize { get => (float)txt.FontSize; set =>txt.FontSize = value; }

        public HorizontalAlignment horizontalAlignment { get => txt.HorizontalAlignment; set => txt.HorizontalAlignment = value; }
        public VerticalAlignment verticalAlignment { get => txt.VerticalAlignment; set => txt.VerticalAlignment = value; }

        public TextAlignment textAlignment { get => txt.HorizontalTextAlignment; set => txt.HorizontalTextAlignment = value; }

        void start()
        {
            txt.TextWrapping = TextWrapping.Wrap;
            txt.HorizontalTextAlignment = TextAlignment.Center;
           
            element = txt;
            txt.Foreground = new SolidColorBrush(Colors.White); ;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.VerticalAlignment = VerticalAlignment.Top;
            txt.RenderTransform = new TranslateTransform();
            frameworkElement = (FrameworkElement)element;
        }

        public UText()
        {
            start();
            txt.Width = 100;
            txt.Height = 50;
            transform.X = 100;
            transform.Y = 100;
            txt.Text = "UText";
           
            this.position = new Vector2(0, 0);
            this.size = new Vector2(100, 50);
        }
        public UText(string text)
        {
            txt.Width = 100;
            txt.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            txt.Text = text;
          
            start();
            this.position = new Vector2(0, 0);
            this.size = new Vector2(100, 50);
        }
        public UText(string text, Vector2 position)
        {
            start();
            txt.Width = 100;
            txt.Height = 50;
            transform.X = position.x;
            transform.Y = position.y;
            this.position = position;
            txt.Text = text;     
            this.size = new Vector2(100, 50);
        }
        public UText(string text, Vector2 position, Vector2 size)
        {
            start();
          
            txt.Width = size.x;
            txt.Height = size.y;
            transform.X = position.x;
            transform.Y = position.y;
            this.position = position;
            this.size = size;
            txt.Text = text;
           
        }
        public void SetColor(byte Red, byte Green, byte Blue, byte Alpha)
        {
            Color C = new Color() { A = Alpha, B = Blue, R = Red, G = Green };
            txt.Foreground = new SolidColorBrush(C);
        }
        public void SetColor(Color C)
        {
            txt.Foreground = new SolidColorBrush(C);
        }
        
    }
}