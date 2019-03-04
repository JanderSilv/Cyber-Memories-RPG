using System;

namespace _3ReaisEngine.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RequerComponente : Attribute
    {
        public Type componente;

        public RequerComponente(Type Componente)
        {
            componente = Componente;
        }
    }
}
