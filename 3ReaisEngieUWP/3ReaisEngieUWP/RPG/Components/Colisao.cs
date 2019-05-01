using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;

namespace _3ReaisEngine.Components
{
    public enum TipoColisao : byte
    {
        Estatica,
        Dinamica
    }
    public class Colisao : Componente<Colisao>
    {
        public delegate void OnColision(Colisao c);

        public volatile Vector4 momentoDeColisao;
        public Vector4 cornAngles;
        public Vector2 tamanho;
        public Vector2 Posicao { get { return entidade.EntPos; } set { entidade.EntPos = value; } }
        public TipoColisao tipo = TipoColisao.Estatica;
        public OnColision onColisionAction = null;

        public Colisao()
        {
          
            momentoDeColisao = new Vector4();
            tamanho = new Vector2(85, 85);
        }
        public Colisao(Vector2 posicao)
        {
          
            tamanho = new Vector2(85, 85);
            momentoDeColisao = new Vector4();
        }
        public Colisao(Vector2 posicao, Vector2 size)
        {
          
            momentoDeColisao = new Vector4();
            tamanho = size;
        }

        public void OnColide(Colisao other)
        {
            onColisionAction?.Invoke(other);
        }
    }


}
