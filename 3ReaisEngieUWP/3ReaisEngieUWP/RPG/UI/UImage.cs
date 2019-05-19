
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

    public class UImage : UIEntidade
    {
        public uwpUI.Image img = new uwpUI.Image();   
        public object Content { get { return img.Source; } set { img.Source = new BitmapImage(new Uri("ms-appx:/"+(string)value)); } }
       
        void start()
        {
            img.HorizontalAlignment = HorizontalAlignment.Left;
            img.VerticalAlignment = VerticalAlignment.Top;
            img.RenderTransform = transform;
            element = img;
        }

        public UImage(string Content)
        {
            img.Source = new BitmapImage(new Uri("ms-appx:/"+Content));
            img.Width = 100;
            img.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            start();
        }
        public UImage(string Content,Vector2 pos)
        {
            img.Source = new BitmapImage(new Uri("ms-appx:/" + Content));
            img.Width = 100;
            img.Height = 50;
            position = pos;
            start();
        }
        public UImage(string Content, Vector2 pos,Vector2 size)
        {

            img.Source = new BitmapImage(new Uri("ms-appx:/" + Content));
            size = size;
            position = pos;
            start();
        }

      
    }
}
