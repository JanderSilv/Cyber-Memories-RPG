using _3ReaisEngieUWP.RPG.Components;
using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Components;
using _3ReaisEngine.RPG.Core;

namespace RPG.Src.Scripts
{
    class Player :Entidade
    {
        public Player()
        {
            AddComponente<Colisao>();
            AddComponente<Render>();
            AmbienteJogo.AdcionarEntidade(this);
        }
    }
}
