using _3ReaisEngine.RPG.Core;

namespace _3ReaisEngine.RPG.Components
{
    public enum TipoColisao:byte
    {
        Estatica,
        Dinamica
    }

   public class Colisao:Componente<Colisao>
    {
        public Vector2 posicao;
        public Vector2 momentoDeColisao;
        public float largura = 1f, altura = 1f;
        public Vector2 Posicao { get { return entidade.Posicao; } set { entidade.Posicao = value; } }

        public Colisao()
        {
            m_ComponenteID = ComponenteReg.Colisao;
        }
        public Colisao(Vector2 posicao)
        {
            m_ComponenteID = ComponenteReg.Colisao;
            this.posicao = posicao;
        }

    }

   
}
