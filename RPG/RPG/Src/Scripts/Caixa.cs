using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Components;
using _3ReaisEngine.RPG.Core;


namespace RPG.Src.Scripts
{
    class Caixa : Entidade
    {
        public Caixa(Vector2 pos)
        {
            AddComponente<Colisao>();
            AddComponente<Render>();
            this.Posicao = pos;
            AmbienteJogo.AdcionarEntidade(this);
        }
    }
}
