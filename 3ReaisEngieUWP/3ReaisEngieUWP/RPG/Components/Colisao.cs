using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace _3ReaisEngine.Components
{
    public enum TipoColisao : byte
    {
        Estatica,
        Dinamica
    }
    public delegate void OnColision(Colisao c);
    /// <summary>
    /// Componente que armazena informações sobre como a entidade colidirá com outras
    /// </summary>
    public class Colisao : Componente<Colisao>
    {
        /// <summary>
        /// Informa se esta colisão é apenas para disparar um evento, ao valer true as outras entidades que entrar em contato nao terão seu momento de colisão alterados
        /// </summary>
        public bool IsTrigger = false;
 
        /// <summary>
        /// Indica as direções onde foram detectadas colisões
        /// </summary>
        public Vector4 momentoDeColisao;
        /// <summary>
        /// Tamanho da caixa de colisão que será usada para verificar sobreposição de entidades
        /// </summary>
        public Vector2 tamanho;
        /// <summary>
        /// Posição relativa da caixa de colisao em relação a posiçao da entidade que a contém
        /// </summary>
        public Vector2 relativePos;
        /// <summary>
        /// Posição total da caixa de colisao, ou seja sua posição relavita mais a posição da entidade
        /// </summary>
        public Vector2 Position { get { return entidade.EntPos + relativePos; } }

        public TipoColisao tipo = TipoColisao.Estatica;

        /// <summary>
        /// Método a ser executado caso seja detectado uma colisão
        /// </summary>
        [JsonIgnore]
        public OnColision onColisionAction = null;
        /// <summary>
        /// Lista de quais entidades deverão ser ignoradas na verificação de colisao
        /// </summary>
        public List<Type> ignoreTypes = new List<Type>();

        public Colisao()
        {
          
            momentoDeColisao = new Vector4();
            tamanho = new Vector2(85, 85);
            relativePos = Vector2.Zero;
        }      
        public Colisao(Vector2 size)
        {
            momentoDeColisao = new Vector4();
            relativePos = Vector2.Zero;
            tamanho = size;
        }
        public Colisao(Vector2 size,Vector2 relativePos)
        {
            momentoDeColisao = new Vector4();
            tamanho = size;
            this.relativePos = relativePos;
        }


    }


}
