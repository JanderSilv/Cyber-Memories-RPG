using System;
using System.Collections.Generic;


namespace _3ReaisEngine.RPG.Events
{
    /*
     * Ordena os eventos distribuindo-os pela aplicação de acordo com a prioridade do evento
     */
    public delegate bool HandleEvent<T> (T e);

    public class ManipuladorEventos
    {
        public Queue<EventArgs> eventos = new Queue<EventArgs>();

        public HandleEvent<EventArgs>[] handle            = new HandleEvent<EventArgs>[(int)PrioridadeEvento.Count];
        public HandleEvent<TecladoEvento>[] handleTeclado = new HandleEvent<TecladoEvento>[(int)PrioridadeEvento.Count];
        public HandleEvent<MouseEvento>[] handleMouse     = new HandleEvent<MouseEvento>[(int)PrioridadeEvento.Count];


        public void Enviar<T> (T e) where T : EventArgs
        {
            eventos.Enqueue(e);
        }

        public void Update()
        {
            while(eventos.Count>0)
            {
                EventArgs e = eventos.Dequeue(); 
                for (int i = 0; i < (int)PrioridadeEvento.Count; i++)
                {
                    if (e.GetType() == typeof(TecladoEvento))
                    {
                        if (handleTeclado[i] == null) break;
                        if(handleTeclado[i].Invoke((TecladoEvento)e)) break;
                        continue;
                    }
                    if (e.GetType() == typeof(MouseEvento))
                    {
                        if (handleMouse[i] == null) break;
                        if (handleMouse[i].Invoke((MouseEvento)e)) break;
                        continue;
                    }
                    handle[0]?.Invoke(e);
                   
                }    
            }
        }
    }
}
