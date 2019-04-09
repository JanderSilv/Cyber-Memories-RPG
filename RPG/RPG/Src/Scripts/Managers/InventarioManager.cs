using System.Linq;

public static class InventarioManager
{
    public static bool Add(Armazenavel item, Inventario inventario)
    {
        if (!item.getEstacavel() && inventario.slots.ContainsKey(item.getID()))
        {
            return false;
        }
        else if (!item.getEstacavel() && !inventario.slots.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            inventario.slots.Add(item.getID(), s);
        }
        else if (item.getEstacavel() && inventario.slots.ContainsKey(item.getID()))
        {
            inventario.slots[item.getID()].qnt++;
        }
        else if (item.getEstacavel() && !inventario.slots.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            inventario.slots.Add(item.getID(), s);
        }


        return true;
    }
    public static Armazenavel Remove(Armazenavel item, Inventario inventario)
    {
        if (!inventario.slots.ContainsKey(item.getID())) return null;
        if (item.getEstacavel())
        {
            inventario.slots[item.getID()].qnt--;
            Armazenavel a = inventario.slots[item.getID()].arm;
            if (inventario.slots[item.getID()].qnt == 0) inventario.slots.Remove(a.getID());
            return a;
        }
        else if (!item.getEstacavel())
        {
            Armazenavel a = inventario.slots[item.getID()].arm;
            inventario.slots.Remove(a.getID());
            return a;
        }
        return null;
    }
    public static Armazenavel Remove(uint itemID, Inventario inventario)
    {
        Armazenavel item = GetByID(itemID, inventario);
        if (item == null) return null;

        if (item.getEstacavel())
        {
            inventario.slots[item.getID()].qnt--;
            if (inventario.slots[item.getID()].qnt == 0) inventario.slots.Remove(item.getID());
            return item;
        }
        else if (!item.getEstacavel())
        {
            inventario.slots.Remove(item.getID());
            return item;
        }
        return null;
    }
    public static Armazenavel GetByID(uint ID, Inventario inventario)
    {
        if (!inventario.slots.ContainsKey(ID)) return null;
        return inventario.slots[ID].arm;

    }
    public static Armazenavel[] GetItensOfType(uint tipo, Inventario inventario)
    {
        var itens = from Armazenavel in inventario.slots.Values where (Armazenavel.arm.getTipo() & tipo) != 0 select Armazenavel.arm;
        return itens.ToArray();
    }
    public static Armazenavel[] GetItensOfExactType(uint tipo, Inventario inventario)
    {
        var itens = from Armazenavel in inventario.slots.Values where Armazenavel.arm.getTipo() == tipo select Armazenavel.arm;
        return itens.ToArray();
    }

}