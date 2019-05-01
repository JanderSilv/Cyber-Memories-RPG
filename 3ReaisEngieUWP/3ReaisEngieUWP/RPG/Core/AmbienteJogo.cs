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

    public delegate void Func();


    public static class AmbienteJogo
    {
        #region DefineVar

        static bool Run = true;
        static ManipuladorEventos gerenciadorEventos = new ManipuladorEventos();
        static GerenciadorFisica gerenciadorFisica = new GerenciadorFisica();
        static Audio musicaDeFundo = new Audio();
        static int frameRate = 60;
        static Func posUpdate = null;

        public static Input Input { get; private set; }
        public static Camera currentCamera { get; private set; }
        public static Window window;
        

        #endregion

        static AmbienteJogo()
        {
            Run = true;
            Input = new Input();
            currentCamera = new Camera();

            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateTeclado);
            RegistrarEventoCallBack(PrioridadeEvento.Game, Input.UpdateMouse);
            Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { Execute(); });


        }

     
        static async Task Execute()
        {
            while (Run)
            {
                try
                {
                    if (window == null)
                    {
                        Engine.Debug("Window is missing");
                        continue;
                    }
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

                    await Task.Delay(1000 / frameRate);
                    posUpdate?.Invoke();
                }catch(Exception e)
                {
                    Engine.Debug(e.StackTrace);
                  
                }
                   
            }
          
        }

        #region Management Functions
        public static Entidade AdcionarEntidade(Entidade e)
        {
            window.Add(e);
            return e;
        }

        public static void RemoverEntidade(Entidade e)
        {
            window.Remove(e);         
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
