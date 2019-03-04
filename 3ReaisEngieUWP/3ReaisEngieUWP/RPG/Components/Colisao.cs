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
        public Vector4 momentoDeColisao;
        public Vector2 tamanho;
        public Vector2 Posicao { get { return entidade.EntPos; } set { entidade.EntPos = value; } }
        public TipoColisao tipo = TipoColisao.Estatica;

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


    }


}
