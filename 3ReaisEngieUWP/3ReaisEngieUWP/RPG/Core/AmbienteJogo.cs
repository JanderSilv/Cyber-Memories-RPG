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

        static bool Run = true;
        static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        static GerenciadorFisica gerenciadorFisica = new GerenciadorFisica();
        static Audio musicaDeFundo = new Audio();

        public static Input Input { get; private set; }
        public static Camera currentCamera { get; private set; }
        public static Window window { get; private set; }
       
      
        #endregion

        #region Construtores
        public static void Init(Page p)
        {
            Run = true;

            Input = new Input();
            currentCamera = new Camera();
            window = new Window(p, 720, 640);

            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateTeclado);
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateMouse);
        
            musicaDeFundo.Audios.Add("back", new AudioSource() { Name = "rain.mp3", Loop = true, Volume = 0 });
         //   musicaDeFundo.Play("back");
          
        }

        public static void Init(Window w)
        {
            window = w;         
            Run = true;
       
            Input = new Input();
            currentCamera = new Camera();

            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateTeclado);
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateMouse);
           
            musicaDeFundo.Audios.Add("back", new AudioSource() { Name = "rain.mp3", Loop = true, Volume = 0 });
           // musicaDeFundo.Play("back");
           
        }

        #endregion

        public static async Task Execute(int frames = 60, LateUpdae late = null)
        {
            while (Run)
            {
             
              
                currentCamera.Update();
                gerenciadorEventos.Update();
                gerenciadorFisica.UpdateColisions(window.colisores.ToArray()); 

                foreach (Entidade e in window.entidades)
                {
                    if (!e.IsStatic) e.Update();
                }
              
                foreach (Render r in window.renders)
                {
                    r.transform.X = r.entidade.EntPos.x - currentCamera.drawOffset.x;
                    r.transform.Y = r.entidade.EntPos.y - currentCamera.drawOffset.y;            
                }

              
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
