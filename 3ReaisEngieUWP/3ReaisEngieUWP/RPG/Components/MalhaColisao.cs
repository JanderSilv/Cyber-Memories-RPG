using _3ReaisEngine.Core;

namespace _3ReaisEngine.Components
{
    public class MalhaColisao : Componente<MalhaColisao>
    {
        public Colisao[] colisoes;

        public MalhaColisao()
        {
            colisoes = new Colisao[0];
        }
        public MalhaColisao(Colisao[] colisoes)
        {
            this.colisoes = colisoes;

        }
    }
}
