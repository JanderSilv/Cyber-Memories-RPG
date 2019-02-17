using System.Collections.Generic;
using _3ReaisEngine.RPG.Components;

namespace _3ReaisEngine.RPG.Core
{
    /*
     * Classe que representa as entidades do jogo, ou seja objetos que estão presentes no mapa,
     * contém um dicionário de componenentes que representa todos os comportamentes que esta entidade deve apresentar
     * Toda entidade por padrão inicia com a componente Transform, pois contem os dados de onde o objeto se localiza em relação ao mapa
     */
   public abstract class Entidade
    {
        protected Dictionary<ComponenteReg, IComponente> Componentes;
        public string Nome;

        public Vector2 Posicao { get; set; }

        public Entidade()
        {
            Componentes = new Dictionary<ComponenteReg, IComponente>();
            AddComponente<Posicao>();
            Posicao = ((Posicao)Componentes[ComponenteReg.Posicao]).posicao;
            AmbienteJogo.AdcionarEntidade(this);
        }
        public Entidade(string Nome)
        {
            this.Nome = Nome;
            Componentes = new Dictionary<ComponenteReg, IComponente>();
            AddComponente<Posicao>();
            Posicao = ((Posicao)Componentes[ComponenteReg.Posicao]).posicao;
            AmbienteJogo.AdcionarEntidade(this);
        }

        /*
         *  Adiciona um componente a esta entidade
         *  retorna true se bem sucedido, false se mal sucedido
         */
        public bool AddComponente<T>() where T : Componente<T>, new()
        {
            if (!Componentes.ContainsKey(Componente<T>.ComponenteID))
            {
                T t = new T();
                t.entidade = this;
                Componentes.Add(Componente<T>.ComponenteID,t);
                return true;
            }

            return false;
        }

        /*
         * Procura um componente nesta entidade
         * retorna true se bem sucedido, false se mal sucedido
         */
        public bool GetComponente<T>(ref T Componente) where T : Componente<T>, new()
        {
           
            if (Componentes.ContainsKey(Componente<T>.ComponenteID))
            {
                Componente = (T)Componentes[Componente<T>.ComponenteID];
                return true;
            }
            Componente = null;
            return false;
        }

        /*
         * Procura um componente nesta entidade
         * retorna a propia entidade se bem sucedido, null se mal sucedido
         */
        public T GetComponente<T>() where T : Componente<T>, new()
        {
            if (Componentes.ContainsKey(Componente<T>.ComponenteID))
            {
                return (T)Componentes[Componente<T>.ComponenteID];

            }

            return null;
        }

        /*
         É executado a cada frame do jogo
         */
        public virtual void Update()
        {
           
        }

        public virtual void OnColide(Colisao col)
        {
           
        }

        public void Destruir()
        {
            AmbienteJogo.RemoverEntidade(this);
        }
    }
}
