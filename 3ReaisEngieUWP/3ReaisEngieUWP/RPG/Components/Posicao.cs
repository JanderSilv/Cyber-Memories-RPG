using _3ReaisEngine.Core;

namespace _3ReaisEngine.Components
{
   
    public sealed class Posicao : Componente<Posicao>
    {
        public Vector2 posicao;
        
        public Posicao()
        {
            posicao = new Vector2();

        }
    }
}
