using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ReaisEngine.Components
{
    [RequerComponente(typeof(Colisao))]
    ///<summary>
    /// Gerencia algumas propiedades físicas da entidade, como posição, velocidade, atrito e tamanho
    ///</summary>
    public class Body :Componente<Body>
    {
        public Vector2 position { get { return entidade.EntPos; }  set { entidade.EntPos=value;} }
        public Vector2 velocity = new Vector2();
        public Vector2 size = new Vector2();
        public float drag = 1;

    }
}
