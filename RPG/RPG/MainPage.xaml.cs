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
  
        SelPersonagem selecao;
        MenuPrin menuPrin;
        public static Laboratorio lab;
        public static GameWin game;
        public MainPage()
        {       
            InitializeComponent();

            selecao = new SelPersonagem(this);         
            menuPrin = new MenuPrin(this);
            lab = new Laboratorio(this);
            game = new GameWin(this);

            menuPrin.SetCurrent();
            menuPrin.next = selecao;
            selecao.game = lab;
            Laboratorio.next = game;
           
        }

      

    }
}