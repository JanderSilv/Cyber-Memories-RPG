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
            Tronco t = new Tronco(new Vector2(100, 50));
            AmbienteJogo.AdcionarEntidade(t);

            Player p = new Player(new Vector2(window.Widht / 2, window.Height / 2));
            p.Nome = "ntbp";

            p.GetComponente<QuestSystem>().AddQuest(new ColidirComTronco());
            
            AmbienteJogo.currentCamera.setSeek (p);
            AmbienteJogo.AdcionarEntidade(p);


            window.ShowMessageBox("Ola", "ola", new Vector2(40, 60), "Claro", "Nunca");
        }

       
    }
}
