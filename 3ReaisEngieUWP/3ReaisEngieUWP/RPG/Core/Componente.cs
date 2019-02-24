using System;

namespace _3ReaisEngine.RPG.Core
{
    public abstract class Componente<T> :IComponente
    {
        protected static ComponenteReg m_ComponenteID;
        public static ComponenteReg ComponenteID { get { return m_ComponenteID; } }
        public Entidade entidade;

        public ComponenteReg getRegister()
        {
            return m_ComponenteID;
        }

        public void setEntidade(Entidade e)
        {
            entidade = e;
        }
    }
}
