using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using RPG.Src.Scripts;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
        Window window;
      
        public MainPage()
        {
            InitializeComponent();
            window = new Window(this, 840, 620);
            window.SetCurrent();
            AmbienteJogo.AdcionarEntidade(new Tronco(new Vector2(window.Widht / 2, window.Height / 2)));
            Player p = new Player(new Vector2(window.Widht/4, window.Height/4));
            p.Nome = "ntbp";


            AmbienteJogo.currentCamera.Seek = p;
            AmbienteJogo.AdcionarEntidade(p);



            try
            {
            
                Engine.save(p, "Player.txt");
              
            }
            catch (Exception e)
            {
                Engine.Debug("Message: " + e.Message);
                Engine.Debug("Stacktrace: " + e.StackTrace);
                Engine.Debug("InnerException" + e.InnerException);
            }


        }

    
    }
}
