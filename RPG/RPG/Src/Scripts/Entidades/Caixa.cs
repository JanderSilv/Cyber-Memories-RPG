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
       
        Itinerario caminho;

       
      

        public Caixa(Vector2 pos) : base()
        {
            EntPos = pos;
            Nome = "Rocha";
       
            AmbienteJogo.AdcionarEntidade(this);
            Render r = GetComponente<Render>();
            GetComponente<Colisao>().tipo = TipoColisao.Dinamica;
            r.LoadImage("Src/JunglerockAlpha.png");
            caminho = GetComponente<Itinerario>();

            caminho.AddPos("1", new Vector2(50, 50));
            caminho.AddPos("2", new Vector2(70, 100));
            caminho.AddPos("3", new Vector2(75, 50));
            caminho.AddPos("4", new Vector2(70, 0));
            caminho.AddPos("5", new Vector2(100, 50));

            caminho.Conect("1", "2");
            caminho.Conect("1", "3");
            caminho.Conect("1", "4");
            caminho.Conect("2", "4");
            caminho.Conect("2", "5");
            caminho.Conect("5", "4");
        }

        public override void Update()
        {
            caminho.Update();
          
        }

        public override void OnClick(MouseEvento e)
        {
            
        }
    }
}
