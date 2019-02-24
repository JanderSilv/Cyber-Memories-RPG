using _3ReaisEngine.RPG.Core;

namespace _3ReaisEngine.RPG.Components
{
    public sealed class Posicao : Componente<Posicao>
    {
        public Vector2 posicao;

        public Posicao()
        {
            posicao = new Vector2();
            m_ComponenteID = ComponenteReg.Posicao;
        }
    }
}
