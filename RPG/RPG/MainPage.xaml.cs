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
        public static Player p;
        Window window;

        public MainPage()
        {
            InitializeComponent();
            window = new Window(this, 840, 620);
            AmbienteJogo.window = window;

            UPanel panel = new UPanel(new Vector2(50, 50), new Vector2(200, 300));

            UButton play = new UButton("", new Vector2(50, 30), new Vector2(100, 50));
            UButton conf = new UButton("", new Vector2(50, 55), new Vector2(100, 50));
            UButton sair = new UButton("", new Vector2(50, 80), new Vector2(100, 50));

            play.setBackground("Src/Images/Menu/Botões/Iniciar.png");
            play.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png");
            conf.setBackground("Src/Images/Menu/Botões/Configurações.png");
            conf.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");
            sair.setBackground("Src/Images/Menu/Botões/Sair.png");
            sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");

            panel.addChild(play);
            panel.addChild(conf);
            panel.addChild(sair);
            panel.manipulationMode = ManipulationModes.All;

            window.AddUI(panel);

            window.SetCurrent();

        }
    }
}
