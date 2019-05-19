using _3ReaisEngine.Components;
using System;

namespace _3ReaisEngine.Core
{
    public static class ComponenteMnager
    {
        public static int componenteCount=0;

    }
    public abstract class Componente<T> : IComponente
    {
        
        protected static int m_intComponenteID;
        public static int IntComponenteID { get { return m_intComponenteID; } }
   
        public Entidade entidade;

        public Componente(){
            if(m_intComponenteID == 0)
            {
                ComponenteMnager.componenteCount++;
                m_intComponenteID = ComponenteMnager.componenteCount;
            }
         }
      
        public virtual void Init()
        {

        }

        public void setEntidade(Entidade e)
        {
            entidade = e;
        }

        public int getRegister()
        {
            return m_intComponenteID;
        }
    }
}
