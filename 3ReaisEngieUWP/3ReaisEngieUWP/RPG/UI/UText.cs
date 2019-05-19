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
    public class UText : UIEntidade
    {
        TextBlock txt = new TextBlock();

        public string content { get { return txt.Text; } set { txt.Text = value; } }

        void start()
        {
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.VerticalAlignment = VerticalAlignment.Top;
            txt.RenderTransform = transform;
        }

        public UText()
        {
            txt.Width = 100;
            txt.Height = 50;
            transform.X = 100;
            transform.Y = 100;
            txt.Text = "UText";

        }
        public UText(string text)
        {
            txt.Width = 100;
            txt.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            txt.Text = text;
            start();
        }
        public UText(string text, Vector2 position)
        {

            txt.Width = 100;
            txt.Height = 50;
            transform.X = position.x;
            transform.Y = position.y;
            position = position;
            txt.Text = text;
            start();
        }
        public UText(string text, Vector2 position, Vector2 size)
        {
            txt.Width = size.x;
            txt.Height = size.y;
            transform.X = position.x;
            transform.Y = position.y;
            position = position;
            size = size;
            txt.Text = text;
            start();
        }

    }
}