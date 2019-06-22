using _3ReaisEngine.Core;
using System.Collections.Generic;
using System.Linq;

public class Slot
{
    public Armazenavel arm;
    public int qnt;
}

public class Inventario : Componente<Inventario>
{
    public int limite = 49;
    public Dictionary<uint, Slot> slots = new Dictionary<uint, Slot>();

    public bool Add(Armazenavel item)
    {
        if (!item.getEstacavel() && slots.ContainsKey(item.getID()))
        {
            return false;
        }
        else if (!item.getEstacavel() && !slots.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            slots.Add(item.getID(), s);
        }
        else if (item.getEstacavel() && slots.ContainsKey(item.getID()))
        {
            slots[item.getID()].qnt++;
        }
        else if (item.getEstacavel() && !slots.ContainsKey(item.getID()))
        {
            Slot s = new Slot() { arm = item, qnt = 1 };
            slots.Add(item.getID(), s);
        }


        return true;
    }
    public  Armazenavel Remove(Armazenavel item)
    {
        if (!slots.ContainsKey(item.getID())) return null;
        if (item.getEstacavel())
        {
            slots[item.getID()].qnt--;
            Armazenavel a = slots[item.getID()].arm;
            if (slots[item.getID()].qnt == 0) slots.Remove(a.getID());
            return a;
        }
        else if (!item.getEstacavel())
        {
            Armazenavel a = slots[item.getID()].arm;
            slots.Remove(a.getID());
            return a;
        }
        return null;
    }
    public Armazenavel Remove(uint itemID)
    {
        Armazenavel item = GetByID(itemID);
        if (item == null) return null;

        if (item.getEstacavel())
        {
            slots[item.getID()].qnt--;
            if (slots[item.getID()].qnt == 0) slots.Remove(item.getID());
            return item;
        }
        else if (!item.getEstacavel())
        {
            slots.Remove(item.getID());
            return item;
        }
        return null;
    }
    public Armazenavel GetByID(uint ID)
    {
        if (!slots.ContainsKey(ID)) return null;
        return slots[ID].arm;

    }
    public Armazenavel[] GetItensOfType(uint tipo)
    {
        var itens = from Armazenavel in slots.Values where (Armazenavel.arm.getTipo() & tipo) != 0 select Armazenavel.arm;
        return itens.ToArray();
    }
    public Armazenavel[] GetItensOfExactType(uint tipo)
    {
        var itens = from Armazenavel in slots.Values where Armazenavel.arm.getTipo() == tipo select Armazenavel.arm;
        return itens.ToArray();
    }
}


