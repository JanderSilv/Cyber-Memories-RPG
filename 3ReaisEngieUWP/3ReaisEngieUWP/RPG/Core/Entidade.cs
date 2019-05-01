using System;
using System.Collections.Generic;
using System.Reflection;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Events;

namespace _3ReaisEngine.Core
{
    /*
     * Classe que representa as entidades do jogo, ou seja objetos que estão presentes no mapa,
     * contém um dicionário de componenentes que representa todos os comportamentes que esta entidade deve apresentar
     * Toda entidade por padrão inicia com a componente Transform, pois contem os dados de onde o objeto se localiza em relação ao mapa
     */

    public abstract class Entidade
    {
        protected Dictionary<int, IComponente> Componentes;//armazenar os componentes da entidade
        public string Nome;
        private ulong id;
        public bool IsStatic = false;//pra otimização de rotina (objetos estaticos) 
        public Vector2 EntPos { get; set; } // posicao da entidade no mapa
        public ulong ID { get { return id; } set { if (id == 0) id = value; } }

        #region Constructors
        public Entidade()
        {
            ID = 0;
            Componentes = new Dictionary<int, IComponente>();
            AddComponente<Posicao>();
            EntPos = ((Posicao)Componentes[Posicao.IntComponenteID]).posicao;

            foreach (Attribute atr in GetType().GetTypeInfo().GetCustomAttributes(typeof(RequerComponente)))
            {
                
                RequerComponente rc = (RequerComponente)atr;
                dynamic comp =  Activator.CreateInstance(rc.componente);
                int reg = comp.getRegister();
                if (!GetComponente(reg))
                {
                    AddComponente(comp);
                }
            }
        }
        public Entidade(string Nome)
        {
            ID = 0;
            this.Nome = Nome;
            Componentes = new Dictionary<int, IComponente>();
            AddComponente<Posicao>();
            EntPos = ((Posicao)Componentes[Posicao.IntComponenteID]).posicao;

            foreach (Attribute atr in GetType().GetTypeInfo().GetCustomAttributes(typeof(RequerComponente)))
            {
                RequerComponente rc = (RequerComponente)atr;
                IComponente comp = (IComponente)Activator.CreateInstance(rc.componente);
                int reg = comp.getRegister();
                if (!GetComponente(reg))
                {
                    AddComponente(comp);
                }
            }

        }
        #endregion

        #region Geren Componente

        /*
         *  Adiciona um componente a esta entidade
         *  retorna true se bem sucedido, false se mal sucedido
         */
        public bool AddComponente<T>() where T : Componente<T>, new()
        {
            if (!Componentes.ContainsKey(Componente<T>.IntComponenteID))
            {
                T t = new T();

                foreach(Attribute atr in t.GetType().GetTypeInfo().GetCustomAttributes(typeof(RequerComponente)))
                {
                    RequerComponente rc = (RequerComponente)atr;
                    IComponente comp = (IComponente)Activator.CreateInstance(rc.componente);
                    int reg = comp.getRegister();
                   
                    if (!Componentes.ContainsKey(reg)){
                        comp.setEntidade(this);
                        Componentes.Add(reg, comp);
                    }
                }
                
                t.entidade = this;
                Componentes.Add(Componente<T>.IntComponenteID,t);
                return true;
            }

            return false;
        }
       
        public bool AddComponente<T>(Componente<T> c)
        {
            if (!Componentes.ContainsKey(Componente<T>.IntComponenteID))
            {
                foreach (Attribute atr in c.GetType().GetTypeInfo().GetCustomAttributes(typeof(RequerComponente)))
                {
                    RequerComponente rc = (RequerComponente)atr;
                    IComponente comp = (IComponente)Activator.CreateInstance(rc.componente);
                    int reg = comp.getRegister();
                    if (!Componentes.ContainsKey(reg))
                    {
                        comp.setEntidade(this);
                        Componentes.Add(reg, comp);
                    }
                }
                c.entidade = this;
                 Componentes.Add(Componente<T>.IntComponenteID,c);
            }
            return false;
        }

        public bool AddComponente(IComponente c)
        {
            int id = c.getRegister();
            if (!Componentes.ContainsKey(id))
            {
                c.setEntidade(this);
                Componentes.Add(id,c);
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
           
            if (Componentes.ContainsKey(Componente<T>.IntComponenteID))
            {
                Componente = (T)Componentes[Componente<T>.IntComponenteID];
                return true;
            }
            Componente = null;
            return false;
        }
        public bool GetComponente(int ComponenteID) 
        {

            if (Componentes.ContainsKey(ComponenteID))
            {
               
                return true;
            }
            
            return false;
        }

        /*
         * Procura um componente nesta entidade
         * retorna a propia entidade se bem sucedido, null se mal sucedido
         */
        public T GetComponente<T>() where T : Componente<T>, new()
        {          
            IComponente c = null;
            Componentes.TryGetValue(Componente<T>.IntComponenteID, out c);    
            return (T)c;
        }

        /*
         É executado a cada frame do jogo
         */
        #endregion

        #region virtual functions
        public virtual void OnClick(MouseEvento e)
        {

        }

        public virtual void Update()
        {
           
        }
        
        public virtual void Destruir()
        {
            AmbienteJogo.RemoverEntidade(this);
        }
        #endregion
    }
}
