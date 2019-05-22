using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            window.SetCurrent();

            Player p = new Player(new Vector2(400,300));
            AmbienteJogo.currentCamera.setSeek(p);
            
            AmbienteJogo.AdcionarEntidade(p);
           

            p.Nome = "ntbp";
            AmbienteJogo.AdcionarEntidade(new Tronco(new Vector2(100+window.Widht/2, window.Height/2)));

            

            //try
            //{
            //    Engine.save(p, "E:/Projects/RPG-LP2/RPG/RPG/Src/saves/player.txt");

            //}
            //catch (Exception e)
            //{
            //    Engine.Debug("Message: " + e.Message);
            //    Engine.Debug("Stacktrace: " + e.StackTrace);
            //    Engine.Debug("InnerException" + e.InnerException);
            //}

            DungeonGenerator dg = new DungeonGenerator();
            dg.heightDungeon = 100;
            dg.widhtDungeon = 100;
            dg.qntRooms = 10;
            dg.roomXMin = 8;
            dg.roomXMax = 16;
            dg.roomYMin = 8;
            dg.roomYMax = 16;
            dg.Generate();

            string map="";

            for (int j = 0; j < dg.heightDungeon; j++)
            {
                for (int i = 0; i < dg.widhtDungeon; i++)
                {
                    if (dg.dungeonMap[i, j] == 0)
                    {
                        map += "  ";
                        Debug.Write("  ");
                    }
                    else
                    {
                        map += dg.dungeonMap[i, j] + " ";
                        Debug.Write(dg.dungeonMap[i, j] + " ");
                    }
                   
                }
                map += '\n';
                Engine.Debug("");
            }

            try
            {
                Engine.saveAsync(map,"map.txt");
            }
            catch(Exception e)
            {
                Engine.Debug(e.StackTrace);
                Engine.Debug(e.InnerException);
                Engine.Debug(e.Message);
            }
        }
    }
    }

