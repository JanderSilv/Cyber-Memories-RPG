using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Imagine;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.Entidades;

namespace _3ReaisEngine
{

    public delegate void LateUpdae();


    public static class AmbienteJogo
    {
        public static bool Run = true;

       
        static List<Entidade> entidades = new List<Entidade>();
        static List<Colisao> colisores = new List<Colisao>();
        static List<Render> renders = new List<Render>();
        static double UpdateTimeElapsed;
        static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        static GerenciadorFisica gerenciadorFisica = new GerenciadorFisica();
        static Stopwatch watch;

        public static Input Input { get; private set; }
        public static float time { get; private set; }
        public static Camera currentCamera { get; private set; }
        public static Window window { get; private set; }

        public static void Init(Page p)
        {
            time = 0;
            window = new Window(p,720,640);
            Run = true;
            watch = Stopwatch.StartNew();
            Input = new Input();
            RegistrarEventoCallBack(PrioridadeEvento.Interface, Input.UpdateTeclado);
            currentCamera = new Camera();
            watch.Stop();
        }

        public static void Init(Window w)
        {
            window = w;
            Run = true;
            watch = Stopwatch.StartNew();
            Input = new Input();
            RegistrarEventoCallBack(PrioridadeEvento.Interface, Input.UpdateTeclado);
            currentCamera = new Camera();
            watch.Stop();
        }

        public static async Task Execute(int frames = 60, LateUpdae late = null)
        {
            while (Run)
            {
                watch = Stopwatch.StartNew();

                currentCamera.Update();
                gerenciadorEventos.Update();
                gerenciadorFisica.UpdateColisions(colisores.ToArray()); 

                foreach (Entidade e in entidades)
                {
                    if (!e.IsStatic) e.Update();
                }
                foreach (Entidade e in entidades)
                {
                    e.EntPos -= currentCamera.delta;
                }

                foreach (Render r in renders)
                {
                    r.transform.X = r.entidade.EntPos.x;
                    r.transform.Y = r.entidade.EntPos.y;            
                }

                time++;
                watch.Stop();
                UpdateTimeElapsed = watch.ElapsedMilliseconds;
               
                await Task.Delay(1000/frames);
                late?.Invoke();
               
                
            }

        }

        public static void AdcionarEntidade(Entidade e)
        {

            entidades.Add(e);
            Colisao c = null;
            Render r = null;
            
            e.EntPos.x += window.Widht / 4;
            e.EntPos.y += window.Height / 4;
            
            if (e.GetComponente(ref c))
            {
                colisores.Add(c);
            }
            if (e.GetComponente(ref r))
            {
                renders.Add(r);
                window.Add(r.img);
            }
            e.OnCreate();
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
                window.Remove(r.img);
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
