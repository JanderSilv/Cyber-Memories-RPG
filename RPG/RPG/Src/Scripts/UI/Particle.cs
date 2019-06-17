using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


    public class Particle
    {
       

        public static void Show(string path,Vector2 position,float duration,int zindex=1)
        {
            Task.Run(async () =>
            {
                Render r = new Render();
                Canvas.SetZIndex(r.img, zindex);
                r.transform.X = position.x;
                r.transform.Y = position.y;
                r.LoadImage(path);
               await Task.Delay((int)(duration * 1000));
               
            });
        }
    }

