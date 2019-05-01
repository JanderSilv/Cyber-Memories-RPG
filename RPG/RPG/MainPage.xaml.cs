using System;
using System.Threading.Tasks;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using RPG.Src.Scripts;
using Windows.UI.Xaml.Controls;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
        Window winConf;
        Window winMenu;
        public MainPage()
        {
            InitializeComponent();

            //cria a janela e seta ela como a atual
            //                                           v~~ altura da janela  
            AmbienteJogo.window = new Window(this, 840, 620);
            //                                      ^~~ largura da janela

            /* Algoritmo do Menu */
            winConf = new Window(this, 840, 620); 
            winMenu = new Window(this, 840, 620);
            
           // winMenu.AddUI(new UImage("Src/Animations/Menu/Menu.gif", new Vector2(0, 0), new Vector2(100, 100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Logo2.png", new Vector2(23, 14), new Vector2(100, 100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Botões/Iniciar.png", new Vector2(43,50), new Vector2(100,100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Botões/Configurações.png", new Vector2(43, 67), new Vector2(100, 100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Botões/Sair.png", new Vector2(43, 85), new Vector2(100, 100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Botões/Sobre.png", new Vector2(92, 98), new Vector2(100, 100)));

            winMenu.AddUI(new UButton("", new Vector2(50,50), new Vector2(150,50), Start));
            winMenu.AddUI(new UButton("", new Vector2(50,65), new Vector2(150,50), Settings));
            winMenu.AddUI(new UButton("", new Vector2(50,80), new Vector2(150,50), Exit));
            winMenu.AddUI(new UButton("", new Vector2(92,92), new Vector2(70,30), About));

            /* Algoritmo de Configurações */

            winConf.AddUI(new UImage("Src/Images/Menu/Botões/Voltar.png", new Vector2(9, 10), new Vector2(100, 100)));
           // winConf.AddUI(new UImage("Src/Images/Menu/.png", new Vector2(30, 15), new Vector2(100, 100)));
           // winConf.AddUI(new UImage("Src/Images/Menu/.png", new Vector2(10, 10), new Vector2(100, 100)));

            winConf.AddUI(new UButton("X", new Vector2(11, 7), new Vector2(142,43), Comeback));
            winConf.AddUI(new UButton("Controles", new Vector2(40,20), Controls));
            winConf.AddUI(new UButton("Aúdio", new Vector2(60,20), Volume));
            
            winConf.SetCurrent();
            

            //adiciona botao na janela (posição dada em %)
            //    AmbienteJogo.window.AddUI(new UButton("Jander", new Vector2(50, 50), new Vector2(100, 50))); 
            //                                                   ^~~ posicao na janela       ^~~ tamanho do botao

            //instancia jogador
            Player p = new Player(new Vector2(0, 0)); 

            //adiciona jogador ao jogo
           // AmbienteJogo.AdcionarEntidade(p); 

            //seta jogador pra ser seguido pela camera
           // AmbienteJogo.currentCamera.setSeek(p);
            //            ^~~ pode ser simplificado com AmbienteJogo.currentCamera.setSeek(AmbienteJogo.AdcionarEntidade(p)); visto q AdicionarEntidade retorna a entidade adicionada

            //cria caixa ("opera") e adiciona ao jogo
            //AmbienteJogo.AdcionarEntidade(new Caixa(new Vector2(-200, 0)));
        }

        /* Algoritmo dos Botões do Menu */

        private void Start(object Sender) {
            // Iniciar jogo;
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
