using System;
using System.Collections.Generic;
using System.Linq;
using _3ReaisEngine.Core;

public interface Armazenavel
{
    bool getEstacavel();
    uint  getID();
    ushort getTipo();
}


public class Slot{
   public Armazenavel arm;
   public int qnt;
}

public class Inventario : Componente<Inventario>
 {
    public Dictionary<uint, Slot> inventario = new Dictionary<uint, Slot>();
 }

public static class InventarioHelper
{
    public static bool Add(Armazenavel item,Inventario inventario)
    {
        if (!item.getEstacavel() && inventario.inventario.ContainsKey(item.getID()))
        {
            return false;
        }
        else if (!item.getEstacavel() && !inventario.inventario.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            inventario.inventario.Add(item.getID(), s);
        }else if(item.getEstacavel() && inventario.inventario.ContainsKey(item.getID()))
        {
            inventario.inventario[item.getID()].qnt++;
        }else if(item.getEstacavel() && !inventario.inventario.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            inventario.inventario.Add(item.getID(), s);
        }
      
      
        return true;
    }
    public static Armazenavel Remove(Armazenavel item,Inventario inventario)
    {
        if (!inventario.inventario.ContainsKey(item.getID())) return null;
        if (item.getEstacavel())
        {
            inventario.inventario[item.getID()].qnt--;
            Armazenavel a = inventario.inventario[item.getID()].arm;
            if (inventario.inventario[item.getID()].qnt == 0) inventario.inventario.Remove(a.getID());
            return a;
        }
        else if(!item.getEstacavel())
        {
            Armazenavel a = inventario.inventario[item.getID()].arm;
            inventario.inventario.Remove(a.getID());
            return a;
        }
        return null;
      }
    public static Armazenavel GetByID(uint ID,Inventario inventario)
    {
        if (!inventario.inventario.ContainsKey(ID)) return null;
        return inventario.inventario[ID].arm;

    }
    public static Armazenavel[] GetItensOfType(uint tipo,Inventario inventario)
    {
        var itens = from Armazenavel in inventario.inventario.Values where (Armazenavel.arm.getTipo() & tipo) != 0 select Armazenavel.arm;
        return itens.ToArray();
    }
    public static Armazenavel[] GetItensOfExactType(uint tipo, Inventario inventario)
    {
        var itens = from Armazenavel in inventario.inventario.Values where Armazenavel.arm.getTipo() == tipo select Armazenavel.arm;
        return itens.ToArray();
    }
    public static void Sort() { }
}
