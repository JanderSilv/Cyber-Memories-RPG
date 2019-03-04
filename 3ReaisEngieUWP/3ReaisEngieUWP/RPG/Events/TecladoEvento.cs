using System;


namespace _3ReaisEngine.Events
{
    public enum ModificadorList : byte
    {
        KeyUp = 1,
        KeyDown = 2,
        Shift = 4
    }

    public class TecladoEvento : EventArgs
    {
        public int Tecla = 0;
        public uint Repeticoes = 0;
        public byte Modificador = 0;

    }
}
