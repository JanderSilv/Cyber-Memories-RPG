using System;


namespace _3ReaisEngine.Events
{
    public enum ModificadorTecla : byte
    {
        KeyUp = 1,
        KeyHold = 2,
        Shift = 4,
        KeyDown = 8
    }

    public class TecladoEvento : EventArgs
    {
        public int Tecla = 0;
        public uint Repeticoes = 0;
        public byte Modificador = 0;

    }
}
