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
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
        public static Player p;

        Window winConf;
        Window winMenu;
        Window winGame;

        public MainPage()
        {
            InitializeComponent();

          
            AmbienteJogo.window = new Window(this, 840, 620);
            
            winConf = new Window(this, 840, 620); 
            winMenu = new Window(this, 840, 620);
            winGame = new Window(this, 840, 620);

            p = new Player(new Vector2(0, 0));

            winMenu.AddUI(new UImage("Src/Images/Menu/Logo2.png", new Vector2(23, 14), new Vector2(100, 100)));

            UButton start = new UButton("", new Vector2(50, 50), new Vector2(150, 50), Start);
            start.setBackground("Src/Images/Menu/Botões/Iniciar.png", Stretch.Fill);
            start.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png"); // imagem quando o mouse ficar por cima
            start.setOnClick("Src/Images/Menu/Botões/Configurações.png"); //imagem quando o botao for clicado (ainda n funciona)

            UButton settings = new UButton("", new Vector2(50, 65), new Vector2(150, 50), Settings);
            settings.setBackground("Src/Images/Menu/Botões/Configurações.png");
            settings.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");

            UButton exit = new UButton("", new Vector2(50, 80), new Vector2(150, 50), Exit);
            exit.setBackground("Src/Images/Menu/Botões/Sair.png");
            exit.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");

            UButton about = new UButton("", new Vector2(92, 92), new Vector2(70, 30), About);
            about.setBackground("Src/Images/Menu/Botões/Sobre.png");
            about.setOnHover("Src/Images/Menu/Botões/Sobre_Selecionado.png");

            winMenu.AddUI(start);
            winMenu.AddUI(settings);
            winMenu.AddUI(exit);
           // winMenu.AddUI(about);

            /* Algoritmo de Configurações */

            UButton voltar = new UButton("", new Vector2(11, 7), new Vector2(142, 43), Comeback);
            voltar.setBackground("Src/Images/Menu/Botões/Voltar.png");

            winConf.AddUI(new UButton("Controles", new Vector2(40,20), Controls));
            winConf.AddUI(new UButton("Aúdio", new Vector2(60,20), Volume));

            winConf.AddUI(voltar);

            winMenu.SetCurrent();

            winGame.Add(p);
            AmbienteJogo.currentCamera.setSeek(p);

            UButton voltarg = new UButton("", new Vector2(92, 82), new Vector2(70, 30), Comeback);
            voltarg.setBackground("Src/Images/Menu/Botões/Voltar.png");

            Dictionary<int, Type> dic = new Dictionary<int, Type>();
            dic.Add(22, typeof(Grama));
            dic.Add(100, typeof(Flores));
            dic.Add(121, typeof(Rocha1));
            dic.Add(141, typeof(Rocha2));
            dic.Add(122, typeof(Tronco));
            dic.Add(242, typeof(Areia));
            dic.Add(202, typeof(Arvore));

            try{
                
               
                List<Entidade> ent = MapLoader.LoadMap("Src/Maps/map.xml", dic);
                foreach (Entidade e in ent)
                {
                    winGame.Add(e);
                }

            }
            catch(Exception e)
            {
                Engine.Debug("Load Map Error> "+e.StackTrace);
                Engine.Debug("Load Map Error> "+ e.Message);
            }

           

            winGame.AddUI(about);
            winGame.AddUI(voltarg);
            winGame.Add(new Undead(new Vector2(150, 0)));
            winGame.Add(new Undead(new Vector2(-150, -200)));
            winGame.Add(new Undead(new Vector2(50, 275)));
            winGame.Add(new Undead(new Vector2(10, -20)));
           
          
        }

        /* Algoritmo dos Botões do Menu */

        private void Start(object Sender) {
            winGame.SetCurrent();
           
        }

        private void Settings(object Sender) {
            winConf.SetCurrent();
        }

        private void Exit(object Sender) {
            Environment.Exit(0);
        }

        private void About(object Sender) {
            // Abrir aba sobre;
        }

        /* Algoritmo dos Botões de Configurações */

        private void Comeback(object Sender) {
            winMenu.SetCurrent(); 
        }

        private void Controls(object Sender) {
            // Abre o canvas de controles;
        }

        private void Volume(object Sender) {
            // Abre o canvas de volume;
        }
    }
}
