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
using _3ReaisEngine.RPG.Components;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI.Core;

namespace _3ReaisEngine
{

    public delegate void LateUpdae();


    public static class AmbienteJogo
    {
        #region DefineVar
        public static bool Run = true;

        public static float deltaTime;
        static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        static GerenciadorFisica gerenciadorFisica = new GerenciadorFisica();

        static Stopwatch watch;
        static Audio musicaDeFundo = new Audio();

        public static float time { get; private set; }

        public static Input Input { get; private set; }
        public static Camera currentCamera { get; private set; }
        public static Window window { get; private set; }
        public static Vector2 drawOffset = new Vector2();
      
        #endregion

        #region Construtores
        public static void Init(Page p)
        {
            drawOffset.x = 0;
            drawOffset.y = 0;
            window = new Window(p, 720, 640);
            time = 0;
            Run = true;
            watch = Stopwatch.StartNew();
            Input = new Input();
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateTeclado);
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateMouse);
            currentCamera = new Camera();
            watch.Stop();
            musicaDeFundo.Audios.Add("back", new AudioSource() { Name = "rain.mp3", Loop = true, Volume = 50 });
            musicaDeFundo.Play("back");
          
        }

        public static void Init(Window w)
        {
            drawOffset.x = 0;
            drawOffset.y = 0;
            window = w;
            time = 0;
            Run = true;
            watch = Stopwatch.StartNew();
            Input = new Input();
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateTeclado);
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateMouse);
            currentCamera = new Camera();
            watch.Stop();
            musicaDeFundo.Audios.Add("back", new AudioSource() { Name = "rain.mp3", Loop = true, Volume = 50 });
            musicaDeFundo.Play("back");
            

        }

        #endregion

        public static async Task Execute(int frames = 60, LateUpdae late = null)
        {
            while (Run)
            {
                watch = Stopwatch.StartNew();
              
                currentCamera.Update();
                gerenciadorEventos.Update();
                gerenciadorFisica.UpdateColisions(window.colisores.ToArray()); 

                foreach (Entidade e in window.entidades)
                {
                    if (!e.IsStatic) e.Update();
                }
              
                foreach (Render r in window.renders)
                {
                    r.transform.X = r.entidade.EntPos.x - currentCamera.delta.x;
                    r.transform.Y = r.entidade.EntPos.y - currentCamera.delta.y;            
                }

                time++;
                watch.Stop();
                deltaTime =(float)watch.ElapsedMilliseconds;

                await Task.Delay(1000/frames);
                late?.Invoke();
               
            }
            
        }

        #region Management Functions
        public static void AdcionarEntidade(Entidade e)
        {

            window.entidades.Add(e);
            Colisao c = null;
            Render r = null;
            
            e.EntPos.x += window.Widht / 4;
            e.EntPos.y += window.Height / 4;
            
            if (e.GetComponente(ref c))
            {
                window.colisores.Add(c);
            }
            if (e.GetComponente(ref r))
            {
                window.renders.Add(r);
                window.Add(r.img);
            }
          
        }

        public static void RemoverEntidade(Entidade e)
        {
            window.entidades.Remove(e);
            Colisao c = null;
            Render r = null;
            if (e.GetComponente(ref c))
            {
                window.colisores.Remove(c);
            }
            if (e.GetComponente(ref r))
            {
                window.renders.Remove(r);
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

        public static void RemoverEventoCallBack(PrioridadeEvento prioridade, HandleEvent<TecladoEvento> e)
        {
            gerenciadorEventos.handleTeclado[(int)prioridade] -= e;
        }
        public static void RemoverEventoCallBack(PrioridadeEvento prioridade, HandleEvent<MouseEvento> e)
        {
            gerenciadorEventos.handleMouse[(int)prioridade] -= e;
        }
        public static void RemoverEventoCallBack(PrioridadeEvento prioridade, HandleEvent<EventArgs> e)
        {
            gerenciadorEventos.handle[(int)prioridade] -= e;
        }

        #endregion

    }
}
