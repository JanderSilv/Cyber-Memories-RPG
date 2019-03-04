using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using RPG.Src.Scripts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace RPG
{

    public sealed partial class MainPage : Page
    {
        Player p;
        Colisao c;
        Caixa cx;
        public MainPage()
        {

            InitializeComponent();

            AmbienteJogo.Init(Screen);
            AmbienteJogo.Execute(120, LateUpdate);

            p = new Player(new Vector2(60, 60));
            c = p.GetComponente<Colisao>();
            p.GetComponente<Render>().layer=-1;
            
            
            cx = new Caixa(new Vector2(160, 160));

        }

        public void LateUpdate()
        {
            txt_ciclo.Text = AmbienteJogo.time.ToString();
            txt_colisao.Text = c.momentoDeColisao.ToString();
            txt_cxPos.Text = cx.EntPos.ToString();
            txt_playerPos.Text = p.EntPos.ToString();
        }
   
        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyDown };
            AmbienteJogo.EnviarEvento(te);
        }

        private void Page_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyUp };
            AmbienteJogo.EnviarEvento(te);
        }
    }
}
