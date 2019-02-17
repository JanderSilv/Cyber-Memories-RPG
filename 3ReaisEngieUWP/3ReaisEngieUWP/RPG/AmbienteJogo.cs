using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using _3ReaisEngine.RPG.Components;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.RPG.Events;

namespace _3ReaisEngine.RPG
{
    public static class AmbienteJogo
    {
        public static bool Run = true;

        public static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        public static GerenciadorFisica  gerenciadorFisica = new GerenciadorFisica();

        static List<Entidade> entidades = new List<Entidade>();
        static List<Colisao> colisores = new List<Colisao>();

        public static void Execute()
        {
          //  while (Run)
            {
                gerenciadorEventos.Update();
                if(colisores.Count>0) gerenciadorFisica.UpdateColisions(colisores.ToArray());

                foreach (Entidade e in entidades)
                {
                    e.Update();
                }
            }
        }

        public static void AdcionarEntidade(Entidade e)
        {
            entidades.Add(e);
            Colisao c = null;
            if (e.GetComponente(ref c))
            {
                colisores.Add(c);
            }
            
        }

        public static void RemoverEntidade(Entidade e)
        {
            entidades.Remove(e);
            Colisao c = null;
            if (e.GetComponente(ref c))
            {
                colisores.Remove(c);
            }
        }

    }
}
