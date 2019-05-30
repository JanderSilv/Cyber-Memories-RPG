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
        Window selecao;

        private string[] ImagePath = new string [4];
        private int i=0;

        UImage charSelector;

        public MainPage()
        {
            InitializeComponent();

            ImagePath[0] = "Src/Images/Menu/Botões/Iniciar.png";
            ImagePath[1] = "Src/Images/Menu/Botões/Iniciar.png";
            ImagePath[2] = "Src/Images/Menu/Botões/Iniciar.png";
            ImagePath[4] = "Src/Images/Menu/Botões/Iniciar.png";


            window = new Window(this, 840, 620);
            selecao = new Window(this, 840, 620);
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

           // panel.addChild(play);
            panel.addChild(conf);
            panel.addChild(sair);
            panel.manipulationMode = ManipulationModes.All;

            window.Add(play);

            selecao.SetCurrent();

            Player p = new Player(new Vector2(window.Widht/2, window.Height/2));
            p.Nome = "ntbp";
            AmbienteJogo.AdcionarEntidade(new Tronco(new Vector2(100+window.Widht/2, window.Height/2)));
            
            AmbienteJogo.currentCamera.Seek = p;
            AmbienteJogo.AdcionarEntidade(p);

            charSelector = new UImage(ImagePath[i], new Vector2(65, 40));

            //try
            //{
            //    Engine.save(p, "E:/Projects/RPG-LP2/RPG/RPG/Src/saves/player.txt");

            //}catch(Exception e)
            //{
            //    Engine.Debug("Message: "+e.Message);
            //    Engine.Debug("Stacktrace: "+e.StackTrace);
            //    Engine.Debug("InnerException"+e.InnerException);
            //}


        }

        void SelecaoDePersonagem()
        {


            UButton man = new UButton("", new Vector2(25,20), new Vector2(178,67), Man);
            UButton woman = new UButton("", new Vector2(25,30), new Vector2(178,67), Woman);
            UButton rightSelector = new UButton("", new Vector2(70, 70), new Vector2(100, 50), RightSelector);
            UButton leftSelector = new UButton("", new Vector2(70, 60), new Vector2(100, 50), LeftSelector);

            man.setBackground("");
            man.setOnHover("");
            woman.setBackground("");
            woman.setOnHover("");
            rightSelector.setBackground("");
            leftSelector.setBackground("");

        }

        

        private void LeftSelector(object sender)
        {
            i--;
            charSelector.Content = ImagePath[i];
        }

        private void RightSelector(object sender)
        {
            i++;
            charSelector.Content = ImagePath[i];

        }

        private void Woman(object sender)
        {
            i = 2;
            charSelector.Content = ImagePath[i];
        }

        private void Man(object sender)
        {
            i = 0;
            charSelector.Content = ImagePath[i];
        }
    }
}
