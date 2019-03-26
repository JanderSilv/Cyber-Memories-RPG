using System;
using System.Collections.Generic;
using System.Linq;
using _3ReaisEngine.Core;

public class Slot{
   public Armazenavel arm;
   public int qnt;
}

public class Inventario : Componente<Inventario>
 {
    public int limite = 30;
    public Dictionary<uint, Slot> slots = new Dictionary<uint, Slot>();
 }


