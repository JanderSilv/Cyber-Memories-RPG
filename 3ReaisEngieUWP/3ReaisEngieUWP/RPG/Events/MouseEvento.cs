using _3ReaisEngine.Core;
using System;
using Windows.System;

namespace _3ReaisEngine.Events
{
    public enum Modificador : byte
    {
        ButtonDown,
        ButtonUp
    }

    public enum MouseButton : byte
    {
        Left=1,
        Right=2,
        Scroll = 4
    }

    public class MouseEvento : EventArgs
    {
        public MouseButton Botao;
        public uint Repeticoes;
        public VirtualKeyModifiers Modificador;
        public Vector2 Position;
        public Modificador Tipo;
    }
}
