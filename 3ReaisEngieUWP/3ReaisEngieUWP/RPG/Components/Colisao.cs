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

    public class Colisao : Componente<Colisao>
    {
       

        public Vector4 momentoDeColisao;
        
        public Vector2 tamanho;
        public Vector2 relativePos;
        public Vector2 Position { get { return entidade.EntPos + relativePos; } }

        public TipoColisao tipo = TipoColisao.Estatica;
        [JsonIgnore]
        public OnColision onColisionAction = null;
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
