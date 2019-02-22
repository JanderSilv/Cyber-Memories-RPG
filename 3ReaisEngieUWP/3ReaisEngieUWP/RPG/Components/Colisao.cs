using _3ReaisEngieUWP.RPG.Core;
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
        public Vector4 momentoDeColisao;
        public Vector2 tamanho;
        public Vector2 Posicao { get { return entidade.Posicao; } set { entidade.Posicao = value; } }

        public Colisao()
        {
            m_ComponenteID = ComponenteReg.Colisao;
            momentoDeColisao = new Vector4();
            posicao = new Vector2();
            tamanho = new Vector2(100, 100);
        }
        public Colisao(Vector2 posicao)
        {
            m_ComponenteID = ComponenteReg.Colisao;
            this.posicao = posicao;
            tamanho = new Vector2(100, 100);
            momentoDeColisao = new Vector4();
        }
        public Colisao(Vector2 posicao, Vector2 size)
        {
            m_ComponenteID = ComponenteReg.Colisao;
            momentoDeColisao = new Vector4();
            this.posicao = posicao;
            tamanho = size;
        }
       

    }

   
}
