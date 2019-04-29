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
    
        Window window;

        public MainPage()
        {
            Window window = new Window(this, 840, 620);
            this.InitializeComponent();

            UButton start = new UButton("Iniciar", new Vector2(50, 60), new Vector2(150,50), Start);
            UButton settings = new UButton("Configurações", new Vector2(50, 70), new Vector2(150, 50), Settings);
            UButton exit = new UButton("Sair", new Vector2(50, 80), new Vector2(150, 50), Exit);

            window.AddUI(start);
            window.AddUI(settings);
            window.AddUI(exit);

            AmbienteJogo.Init(window);

            /*  window = new Window(this, 840, 620);



              UButton btn = new UButton("Jander",new Vector2(0,0),new Vector2(100,50), algumaCoisa);

              InitializeComponent();
              window.AddUI(btn);


              AmbienteJogo.Init(window);

              new Caixa(new Vector2(-200, 0));

              new Player(new Vector2(0, 0));

              AmbienteJogo.Execute(120);*/
        }

        private void algumaCoisa(object sender)
        {
            Engine.Debug("Alguma coisa ocorreu");
        }
        private void Start(object Sender) {
            // Iniciar jogo;
        }

        private void Settings(object Sender) {
            // Abrir aba de configurações;
        }

        private void Exit(object Sender) {
            Environment.Exit(0);
        }
    }
}
