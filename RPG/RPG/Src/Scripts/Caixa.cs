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
        public Caixa(Vector2 pos):base()
        {  
            this.EntPos = pos;
            IsStatic = true;
            AmbienteJogo.AdcionarEntidade(this);
        }
    }
}
