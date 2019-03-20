using System.Collections.Generic;
using System.Linq;
using _3ReaisEngine.Core;

public interface Armazenavel
{
    int getID();
    int getTipo();
}

public class Inventario : Componente<Inventario>
 {
    public Dictionary<int, Armazenavel> inventario = new Dictionary<int, Armazenavel>();
 }

public static class InventarioHelper
{
    public static bool Add(Armazenavel item,Inventario inventario)
    {
        if (inventario.inventario.ContainsKey(item.getID())) return false;
        inventario.inventario.Add(item.getID(), item);
        return true;
    }
    public static Armazenavel Remove(Armazenavel item,Inventario inventario)
    {
        if (!inventario.inventario.ContainsKey(item.getID())) return null;
        Armazenavel arm = inventario.inventario[item.getID()];
        inventario.inventario.Remove(item.getID());
        return arm;
    }
    public static Armazenavel GetByID(int ID,Inventario inventario)
    {
        if (!inventario.inventario.ContainsKey(ID)) return null;
        return inventario.inventario[ID];

    }
    public static Armazenavel[] GetItensOfType(int tipo,Inventario inventario)
    {
        var itens = from Armazenavel in inventario.inventario.Values where (Armazenavel.getTipo() & tipo) != 0 select Armazenavel;
        return itens.ToArray();
    }
    public static Armazenavel[] GetItensOfExactType(int tipo, Inventario inventario)
    {
        var itens = from Armazenavel in inventario.inventario.Values where Armazenavel.getTipo() == tipo select Armazenavel;
        return itens.ToArray();
    }
    public static void Sort() { }
}
