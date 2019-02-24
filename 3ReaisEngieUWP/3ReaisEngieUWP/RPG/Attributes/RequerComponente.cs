using System;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using _3ReaisEngine.RPG.Core;

namespace _3ReaisEngine.RPG.Attributes
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
