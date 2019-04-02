using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;


namespace RPG.Src.Scripts
{
    [RequerComponente(typeof(Colisao))]
    [RequerComponente(typeof(Render))]
    class Caixa : Entidade
    {
        public Caixa(Vector2 pos) : base()
        {
            EntPos = pos;
            Nome = "Rocha";
            IsStatic = true;
            AmbienteJogo.AdcionarEntidade(this);
            Render r = GetComponente<Render>();
            GetComponente<Colisao>().tipo = TipoColisao.Dinamica;
            r.LoadImage("Src/JunglerockAlpha.png");
        }
    }
}
