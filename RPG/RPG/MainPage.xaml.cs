using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
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
        Player p;
        Colisao c;
        Caixa cx;
        public MainPage()
        {

            InitializeComponent();
           
            AmbienteJogo.Init(Game_Screen);
            Canvas.SetZIndex(Game_Screen, AmbienteJogo.defaltuLayer.prioridade);
            Canvas.SetZIndex(UIPanel, AmbienteJogo.UILayer.prioridade);
           
            Mercador m1, m2;
          
            p = new Player(new Vector2(60, 60));
            cx = new Caixa(new Vector2(160, 160));
            c = p.GetComponente<Colisao>();

            Arco arc = new Arco();
            Arco arc1 = new Arco();
            Arco arc2 = new Arco();

            Armadura arm = new Armadura();
            Armadura arm1 = new Armadura();
            Armadura arm2 = new Armadura();

            if (InventarioManager.Add(arc, p.GetComponente<Inventario>())) Engine.Debug("Arc adicionado");
            if (InventarioManager.Add(arc, p.GetComponente<Inventario>())) Engine.Debug("Arc adicionado");
            if (InventarioManager.Add(arc1, p.GetComponente<Inventario>())) Engine.Debug("Arc1 adicionado");

            if (InventarioManager.Add(arm, p.GetComponente<Inventario>())) Engine.Debug("Arm adicionado");
            if (InventarioManager.Add(arm1, p.GetComponente<Inventario>())) Engine.Debug("Arm1 adicionado");
            
            if(InventarioManager.Remove(arc.ID, p.GetComponente<Inventario>()) != null)
            {
                Engine.Debug("Arc removido");
            }
            if (InventarioManager.Remove(arc.ID, p.GetComponente<Inventario>()) != null)
            {
                Engine.Debug("Arc removido");
            }
            else
            {
                Engine.Debug("Arc nao encontrado");
            }

            p.GetComponente<Mercador>().dinheiro = 50;


            Player m = new Player(Vector2.Zero);
            m.AddComponente<Mercador>();
            InventarioManager.Add(arc, m.GetComponente<Inventario>());
            InventarioManager.Add(arm, m.GetComponente<Inventario>());

            m1 = p.GetComponente<Mercador>();
            m2 = m.GetComponente<Mercador>();

             Engine.Debug(m1.Comprar(m2, arc.ID));
             Engine.Debug(m1.Comprar(m2, arm.ID));
             Engine.Debug(m1.Comprar(m2, arm.ID));

            Status m_status = m.GetComponente<Status>();

            p.Atacar(m_status);

            Engine.Debug(m_status.saude);

            AmbienteJogo.Execute(120, LateUpdate);

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
