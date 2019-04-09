using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.Components
{
    [RequerComponente(typeof(Render))]
    public class Animacao:Componente<Animacao>
    {
        Dictionary<string, BitmapImage> animations = new Dictionary<string, BitmapImage>();


        public void AddAnimation(string Nome,string animPath)
        {
            BitmapImage source = new BitmapImage(new Uri("ms-appx:"+animPath));
            if (!animations.ContainsKey(Nome) && source != null)
            {
                animations.Add(Nome, source);
            }
        }
        public void RemoveAnimation(string Nome, BitmapImage anim)
        {
            if (animations.ContainsKey(Nome) && anim != null)
            {
                animations.Remove(Nome);
            }
        }

        public void Play(string Nome,Render render)
        {
            if (animations.ContainsKey(Nome))
            {
                render.img.Source = animations[Nome];
            }
        }
    }
}
