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
            UButton btn = new UButton("Button");
            InitializeComponent();
            
            window = new Window(this, 840, 620);
            window.AddUI(btn);
            AmbienteJogo.Init(window);
            
            new Caixa(new Vector2(-200, 0));
            //new Caixa(new Vector2(0, -200));
            //new Caixa(new Vector2(200, 0));
            //new Caixa(new Vector2(0, 200));
            //new Caixa(new Vector2(0, 290));
            //new Player(new Vector2(0, 0));
           
            AmbienteJogo.Execute(120);
        }
    }
}
