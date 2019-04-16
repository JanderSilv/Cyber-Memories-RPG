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
        bool add = true;
        Window window;
        UComboBox b = new UComboBox(new Vector2(100, 0), new Vector2(200, 50),(object a)=> { Engine.Debug("Selecionado: " +((UComboBox)a).Selected()); });
        UButton bb;

        void a(object sender)
        {
            if (!add) {
                window.Remove(b);
                add = true;
            }
            else {
                window.Add(b);
                add = false;

            }
        }

        public MainPage()
        {

            
            InitializeComponent();

            b.AddItem("Button 1");
            b.AddItem("Button 2");
            b.AddItem("Button 3");

            string tt = "";

            window = new Window(this, 840, 620);
            bb = new UButton("Teste", new Vector2(0, 0), a);

           
            
          
            window.Add(bb);
            AmbienteJogo.Init(window);
            
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
