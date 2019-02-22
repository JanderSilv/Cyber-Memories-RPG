using _3ReaisEngine.RPG.Core;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngieUWP.RPG.Components
{
    public class Render: Componente<Render>
    {
        public Image img;
        public TranslateTransform transform;

        public Render()
        {
            transform = new TranslateTransform();
            img = new Image();
            ImageSource souce = new BitmapImage(new Uri("ms-appx:/Assets/StoreLogo.png"));
            img.Source = souce;
            img.Width = 100;
            img.Height = 100;
            img.RenderTransform = transform;
        }
        public Render(float x, float y)
        {
            transform = new TranslateTransform();
            img = new Image();
            ImageSource souce = new BitmapImage(new Uri("ms-appx:/Assets/StoreLogo.png"));
            img.Source = souce;
            img.Width = 100;
            img.Height = 100;
            img.RenderTransform = transform;
            transform.X = x;
            transform.Y = y;
        }

        public Render(string path) {
            transform = new TranslateTransform();
            img = new Image();
            ImageSource souce = new BitmapImage(new Uri("ms-appx:"+path));
            img.Source = souce;
            img.Width = 100;
            img.Height = 100;
            img.RenderTransform = transform; 
        }

        public Render(string path,float x,float y)
        {
            transform = new TranslateTransform();
            img = new Image();
            ImageSource souce = new BitmapImage(new Uri("ms-appx:"+ path));
            img.Source = souce;
            img.Width = 100;
            img.Height = 100;
            img.RenderTransform = transform;
            transform.X = x;
            transform.Y = y;
        }


    }
}
