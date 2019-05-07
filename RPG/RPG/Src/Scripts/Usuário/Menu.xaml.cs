using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using RPG.Src.Scripts;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RPG.Src.Scripts.Usuário {

    public sealed partial class Menu : Page {

        Window winConf;
        Window winMenu;

        public Menu() {

            this.InitializeComponent();

            /* Algoritmo do Menu */
            winConf = new Window(this, 840, 620);
            winMenu = new Window(this, 840, 620);

            // winMenu.AddUI(new UImage("Src/Animations/Menu/Menu.gif", new Vector2(0, 0), new Vector2(100, 100)));

            winMenu.AddUI(new UImage("Src/Images/Menu/Logo2.png", new Vector2(21, 14), new Vector2(100, 100)));
            winMenu.AddUI(new UImage("Src/Images/Menu/Botões/Iniciar.png", new Vector2(74, 49), new Vector2(100, 100)));

            UButton start = new UButton("", new Vector2(50, 48), new Vector2(229, 86), Start);
            start.SetImage("Src/Images/Menu/Botões/Iniciar.png");
            UButton settings = new UButton("", new Vector2(50, 67), new Vector2(229, 86), Settings);
            settings.SetImage("Src/Images/Menu/Botões/Configurações.png");
            UButton exit = new UButton("", new Vector2(50, 86), new Vector2(229, 87), Exit);
            exit.SetImage("Src/Images/Menu/Botões/Sair.png");
            UButton about = new UButton("", new Vector2(92, 92), new Vector2(103, 35), About);
            about.SetImage("Src/Images/Menu/Botões/Sobre.png");

            winMenu.AddUI(start);
            winMenu.AddUI(settings);
            winMenu.AddUI(exit);
            winMenu.AddUI(about);

            /* Algoritmo de Configurações */

            UButton comeback = new UButton("", new Vector2(11, 7), new Vector2(145, 37), Comeback);
            comeback.SetImage("Src/Images/Menu/Botões/Voltar.png");
            UButton controls = new UButton("", new Vector2(35, 20), new Vector2(178, 67), Controls);
            controls.SetImage("Src/Images/Menu/Botões/Controles.png");
            UButton volume = new UButton("", new Vector2(65, 20), new Vector2(178, 67), Volume);
            volume.SetImage("Src/Images/Menu/Botões/Volume.png");

            winConf.AddUI(comeback);
            winConf.AddUI(controls);
            winConf.AddUI(volume);

            winMenu.SetCurrent();

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
