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
        byte[] tecladoDown = new byte[(int)(VirtualKey.GamepadRightThumbstickLeft + 1)];
        byte[] tecladoAtivo = new byte[(int)(VirtualKey.GamepadRightThumbstickLeft + 1)];
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
            

                if (e.Modificador == (byte)ModificadorList.KeyHold)
                {
                    tecladoDown[k] = 1;
                    tecladoAtivo[k] = 1;
                }
                else if (e.Modificador == (byte)ModificadorList.KeyUp)
                {                 
                    tecladoUp[k] = 1;
                    tecladoAtivo[k] = 0;
                }
                else if (e.Modificador == (byte)ModificadorList.KeyDown)
                {
                    teclado[k] = 1;
                    tecladoAtivo[k] = 1;
            }


            return false;
        }

        public void ClearTeclado()
        {
            for (int i = 0; i < tecladoUp.Length; i++)
            {
                tecladoUp[i] = 0;
                teclado[i] = 0;
                tecladoDown[i] = 0;
                
            }
        }
        public bool Tecla(VirtualKey key)
        {
            return tecladoAtivo[(int)key] != 0;
        }
        public bool TeclaPresa(VirtualKey key)
        {
            return tecladoDown[(int)key] == 1;
        }
        public bool TeclaSolta(VirtualKey key)
        {
            return tecladoUp[(int)key]==1;
        }

        public bool TeclaPressionada(VirtualKey key)
        {
            return teclado[(int)key] == 1;
        }

        public bool MouseButton(MouseButton btn)
        {
            return (MouseButtons & (byte)btn)==(byte)btn;
        }
        
    }
}
