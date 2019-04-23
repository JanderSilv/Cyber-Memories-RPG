using System;
using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;

namespace RPG.Src.Scripts
{
    [RequerComponente(typeof(Colisao))]
    [RequerComponente(typeof(Render))]
    [RequerComponente(typeof(Itinerario))]
    class Caixa : Entidade
    {
        UComboBox panel = new UComboBox(Vector2.Zero, new Vector2(100, 50));
        Itinerario caminho;
        private  void Destroi(object sender)
        {
            if (((UComboBox)sender).Selected() == 0)
            {
                Destruir();
            }
            if (((UComboBox)sender).Selected() == 2)
            {
                AmbienteJogo.window.Remove((UComboBox)sender);
            }
        }

        bool show = false;

        public Caixa(Vector2 pos) : base()
        {
            EntPos = pos;
            Nome = "Rocha";
           // IsStatic = true;
            AmbienteJogo.AdcionarEntidade(this);
            Render r = GetComponente<Render>();
            GetComponente<Colisao>().tipo = TipoColisao.Dinamica;
            r.LoadImage("Src/JunglerockAlpha.png");
            panel.AddItem("Quebrar");
            panel.AddItem("Empurrar");
            panel.AddItem("Sair");
            panel.Action = Destroi;
            caminho = GetComponente<Itinerario>();

            caminho.caminho.Add("Inicio", EntPos + new Vector2(200, 0));
            caminho.caminho.Add("Meio", EntPos + new Vector2(50, 50));
            caminho.caminho.Add("Fim", EntPos + new Vector2(-50, 0));
        }

        public override void Update()
        {
            if (EntPos != caminho.caminho["Inicio"]) {
                EntPos.x++;
                Engine.Debug(EntPos.x);
            }
            else
            {
                Engine.Debug("ja cheguei");
            }
            
        }

        public override void OnClick(MouseEvento e)
        {
            if (e.Tipo != Modificador.ButtonDown) return;
            panel.position =Vector2.ToScreenPos(e.Position + EntPos);
            if (!show)
            {
                AmbienteJogo.window.AddUI(panel);
                show = true;
            }
            else
            {
                AmbienteJogo.window.Remove(panel);
                show = false;
            }
        }
    }
}
