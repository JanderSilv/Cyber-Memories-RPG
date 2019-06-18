using _3ReaisEngine.Events;
using System.Collections.Generic;
using Windows.System;

namespace _3ReaisEngine.Core
{

    public class Input
    {
        byte MouseButtons =0;
        Vector2 mousePos = Vector2.Zero;
        public Vector2 MouseDelta { get => MouseDelta; private set { MouseDelta = value; } }
        byte[] teclado = new byte[(int)(VirtualKey.GamepadRightThumbstickLeft+1)];
        byte[] tecladoUp = new byte[(int)(VirtualKey.GamepadRightThumbstickLeft + 1)];
      

        public Input()
        {
            
        }
        
        public bool UpdateMouse(MouseEvento e)
        {
            
            MouseDelta = e.Position - mousePos;
            mousePos = e.Position;
            if (e.Tipo == Modificador.ButtonDown)
            {
                MouseButtons |= (byte)e.Botao;
            }
            else
            {
                MouseButtons ^= (byte)e.Botao;
            }
            return false;
        }

        public bool UpdateTeclado(TecladoEvento e)
        {
            int k = e.Tecla;
            for (int i = 0; i < tecladoUp.Length; i++) tecladoUp[i] = 0; teclado[k] = 0;

            if (e.Modificador == (byte)ModificadorList.KeyDown)
                {
                    teclado[k] = 1;
                }
                else if (e.Modificador == (byte)ModificadorList.KeyUp)
                {
                    teclado[k] = 0;
                    tecladoUp[k] = 1;
                    
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
            return tecladoUp[(int)key]==1;
        }

        public bool MouseButton(MouseButton btn)
        {
            return (MouseButtons & (byte)btn)==(byte)btn;
        }
        
    }
}
