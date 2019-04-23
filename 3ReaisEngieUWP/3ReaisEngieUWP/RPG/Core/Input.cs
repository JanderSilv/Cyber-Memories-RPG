using _3ReaisEngine.Events;
using System.Collections.Generic;
using Windows.System;

namespace _3ReaisEngine.Core
{

    public class Input
    {

        byte[] teclado = new byte[(int)(VirtualKey.GamepadRightThumbstickLeft+1)];
        List<VirtualKey> keyUp = new List<VirtualKey>();

        public Input()
        {
            
        }
        
        public bool UpdateMouse(MouseEvento e)
        {

            return false;
        }

        public bool UpdateTeclado(TecladoEvento e)
        {
            int k = e.Tecla;
            keyUp.Clear();

           
                if (e.Modificador == (byte)ModificadorList.KeyDown)
                {
                    teclado[k] = 1;
                }
                else if (e.Modificador == (byte)ModificadorList.KeyUp)
                {
                    teclado[k] = 0;
                    keyUp.Add((VirtualKey)k);
                    
                }
            

            return false;
        }

        public bool TeclaPressionada(VirtualKey key)
        {

            if (teclado[(int)key] > 0)
            {
                return true;
            }
            return false;
        }
        public bool TeclaSolta(VirtualKey key)
        {
            return keyUp.Contains(key);
        }
    }
}
