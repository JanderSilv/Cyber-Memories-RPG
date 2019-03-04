using _3ReaisEngine.Core;

namespace _3ReaisEngine.Components
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
