using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.Core;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _3ReaisEngine;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace RPG.Src.Scripts.Interface_de_Usuário {

    public sealed partial class Menu : Page {

        public Menu() {

            Window window = new Window(this, 330, 290);
            this.InitializeComponent();

            UButton start = new UButton("Iniciar", new Vector2(100, 100), Start);
            UButton settings = new UButton("Configurações", new Vector2(50, 40), Settings);
            UButton exit = new UButton("Sair", new Vector2(50, 40), Exit);

            window.AddUI(start);
            window.AddUI(settings);
            window.AddUI(exit);

            AmbienteJogo.Init(window);

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
