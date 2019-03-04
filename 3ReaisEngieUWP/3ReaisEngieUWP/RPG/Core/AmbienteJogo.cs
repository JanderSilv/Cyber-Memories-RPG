using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _3ReaisEngine
{

    public delegate void LateUpdae();


    public static class AmbienteJogo
    {
        public static bool Run = true;

        static Panel window;

        static List<Entidade> entidades = new List<Entidade>();
        static List<Colisao> colisores = new List<Colisao>();
        static List<Render> renders = new List<Render>();

        static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        static GerenciadorFisica gerenciadorFisica = new GerenciadorFisica();
        public static Input Input { get; private set; }

        public static float time = 0;

        public static void Init(Panel p)
        {

            Run = true;
            window = p;
            Input = new Input();
            RegistrarEventoCallBack(PrioridadeEvento.Interface, Input.UpdateTeclado);

            Debug.WriteLine("Engine Inciada");

            /*
                 var t= typeof(ComponenteMnager).GetTypeInfo().Assembly.GetTypes().Where(s=> s.GetInterfaces().Contains(typeof(IComponente)));

                 foreach (Type ty in t)
                 {

                     Debug.WriteLine(ty.Name);
                 }
              */

        }

        public static async Task Execute(int frames = 60, LateUpdae late = null)
        {
            while (Run)
            {
                gerenciadorEventos.Update();

                if (colisores.Count > 0) gerenciadorFisica.UpdateColisions(colisores.ToArray());

                foreach (Entidade e in entidades)
                {
                    if (!e.IsStatic) e.Update();
                }

                foreach (Render r in renders)
                {
                    Canvas.SetZIndex(r.img, r.layer);
                    r.transform.X = r.entidade.EntPos.x;
                    r.transform.Y = r.entidade.EntPos.y;
                    
                }

                time++;
                await Task.Delay(1000 / frames);
                late?.Invoke();
            }

        }

        public static void AdcionarEntidade(Entidade e)
        {

            entidades.Add(e);
            Colisao c = null;
            Render r = null;
            if (e.GetComponente(ref c))
            {
                colisores.Add(c);
            }
            if (e.GetComponente(ref r))
            {
                renders.Add(r);
                window.Children.Add(r.img);
            }

        }

        public static void RemoverEntidade(Entidade e)
        {
            entidades.Remove(e);
            Colisao c = null;
            Render r = null;
            if (e.GetComponente(ref c))
            {
                colisores.Remove(c);
            }
            if (e.GetComponente(ref r))
            {
                renders.Remove(r);
                window.Children.Remove(r.img);
            }
        }

        public static void EnviarEvento<T>(T e) where T : EventArgs
        {
            gerenciadorEventos.Enviar(e);
        }

        public static void RegistrarEventoCallBack(PrioridadeEvento prioridade, HandleEvent<TecladoEvento> e)
        {
            gerenciadorEventos.handleTeclado[(int)prioridade] += e;
        }
        public static void RegistrarEventoCallBack(PrioridadeEvento prioridade, HandleEvent<MouseEvento> e)
        {
            gerenciadorEventos.handleMouse[(int)prioridade] += e;
        }
        public static void RegistrarEventoCallBack(PrioridadeEvento prioridade, HandleEvent<EventArgs> e)
        {
            gerenciadorEventos.handle[(int)prioridade] += e;
        }


    }
}
