using _3ReaisEngine.Core;
using System.Collections.Generic;

public class Slot
{
    public Armazenavel arm;
    public int qnt;
}

public class Inventario : Componente<Inventario>
{
    public int limite = 30;
    public Dictionary<uint, Slot> slots = new Dictionary<uint, Slot>();
}


