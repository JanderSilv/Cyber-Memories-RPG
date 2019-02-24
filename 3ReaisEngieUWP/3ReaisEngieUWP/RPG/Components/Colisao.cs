using _3ReaisEngine.RPG.Core;

namespace _3ReaisEngine.RPG.Components
{
    public enum TipoColisao : byte
    {
        Estatica,
        Dinamica
    }

    public class Colisao : Componente<Colisao>
    {
        public Vector4 momentoDeColisao;
        public Vector2 tamanho;
        public Vector2 Posicao { get { return entidade.Posicao; } set { entidade.Posicao = value; } }
        public TipoColisao tipo = TipoColisao.Estatica;

        public Colisao()
        {
            m_ComponenteID = ComponenteReg.Colisao;
            momentoDeColisao = new Vector4();
            tamanho = new Vector2(85, 85);
        }
        public Colisao(Vector2 posicao)
        {
            m_ComponenteID = ComponenteReg.Colisao;
            tamanho = new Vector2(85, 85);
            momentoDeColisao = new Vector4();
        }
        public Colisao(Vector2 posicao, Vector2 size)
        {
            m_ComponenteID = ComponenteReg.Colisao;
            momentoDeColisao = new Vector4();
            tamanho = size;
        }


    }


}
