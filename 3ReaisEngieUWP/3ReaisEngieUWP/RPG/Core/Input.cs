using _3ReaisEngine.RPG.Events;
using System.Collections.Generic;
using Windows.System;

namespace _3ReaisEngine.RPG.Core
{
    public class Input
    {

        Dictionary<VirtualKey, byte> teclado = new Dictionary<VirtualKey, byte>();

        public Input()
        {
            RegistrarTecla(VirtualKey.A);
            RegistrarTecla(VirtualKey.W);
            RegistrarTecla(VirtualKey.D);
            RegistrarTecla(VirtualKey.S);
        }

        public void RegistrarTecla(VirtualKey key)
        {
            if (!teclado.ContainsKey(key)) teclado.Add(key, 0);
        }

        public void RegistrarTeclas(VirtualKey[] keys)
        {
            foreach (VirtualKey key in keys)
                if (!teclado.ContainsKey(key)) teclado.Add(key, 0);
        }

        public bool UpdateTeclado(TecladoEvento e)
        {
            VirtualKey k = (VirtualKey)e.Tecla;

            if (teclado.ContainsKey(k))
            {
                if (e.Modificador == (byte)ModificadorList.KeyDown)
                {
                    teclado[k] = 1;
                }
                else if (e.Modificador == (byte)ModificadorList.KeyUp)
                {
                    teclado[k] = 0;
                }
            }

            return false;
        }

        public bool TeclaPressionada(VirtualKey key)
        {

            if (teclado.ContainsKey(key) && teclado[key] > 0)
            {
                return true;
            }
            return false;
        }
    }
}
