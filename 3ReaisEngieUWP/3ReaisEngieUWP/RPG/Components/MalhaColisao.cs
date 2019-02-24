using _3ReaisEngine.RPG.Core;

namespace _3ReaisEngine.RPG.Components
{
    public class MalhaColisao : Componente<MalhaColisao>
    {
        readonly Colisao[] colisoes;

        public MalhaColisao()
        {
            colisoes = new Colisao[] { new Colisao(new Vector2(0, 0)) };
        }
        public MalhaColisao(Colisao[] colisoes)
        {
            this.colisoes = colisoes;

        }
    }
}
