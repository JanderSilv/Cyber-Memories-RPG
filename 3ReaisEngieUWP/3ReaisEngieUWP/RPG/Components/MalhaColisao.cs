using _3ReaisEngine.Core;

namespace _3ReaisEngine.Components
{
    /// <summary>
    /// Usado para adicionar mais de uma colisão a uma entidade
    /// </summary>
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
