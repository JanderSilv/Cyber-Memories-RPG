using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum tipoItem:ushort
{
    Armadura=1,
    Arma=2,
    Consumivel=3,
    Encantavel=4
}



public static class ItemManager
{
    static uint qntArmadura = 0;

    public static void GenID(Item item)
    {
        /*
        uint t = (ushort)item.tipo;
        uint id = 0;
        t  = (t << 16);

        item.id = (t & 0xFFFF0000);

        if (item.tipo == tipoItem.Armadura)
        {
            qntArmadura++;
            id = qntArmadura & 0x0000FFFF;     
        }
        item.id |= id; */
    }
}

public class Item :Armazenavel
{
    public tipoItem tipo;
    public bool estacavel;
    public uint id;


    public bool getEstacavel()
    {
        return estacavel;
    }

    public uint getID()
    {
        return id;
    }

    public ushort getTipo()
    {
        return (ushort)tipo;
    }
}

public class Machado : Item
{
    public Machado()
    {
        tipo = tipoItem.Arma;
        estacavel = false;
        id = 567;
    }
}

