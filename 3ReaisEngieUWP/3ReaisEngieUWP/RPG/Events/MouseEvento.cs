using System;

namespace _3ReaisEngine.RPG.Events
{
    public class MouseEvento:EventArgs
    {
        public int Botao;
        public uint Repeticoes;
        public byte Modificador;
    }
}
