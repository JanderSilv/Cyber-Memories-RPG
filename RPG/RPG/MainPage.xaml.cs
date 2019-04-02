using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.RPG.Core;
//using _3ReaisEngine.RPG.Core;
using RPG.Src.Scripts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
     
        public MainPage()
        {

            InitializeComponent();
            AmbienteJogo.Init(this);
           
            new Caixa(new Vector2(-200, 0));
            new Caixa(new Vector2(0, -200));
            new Caixa(new Vector2(200, 0));
            new Caixa(new Vector2(0, 200));
            new Caixa(new Vector2(0, 290));

            new Player(new Vector2(0, 0));

            AmbienteJogo.Execute(120);


        }
        
       

       
    }
}
