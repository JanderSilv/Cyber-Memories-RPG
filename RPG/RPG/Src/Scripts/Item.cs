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

public class Item : Armazenavel
{
    public uint ID;
    public string Descricao;
    public string Nome;
    public int Preco;
    public bool Estacavel;
    public ushort TipoItem;



    public bool getEstacavel()
    {
        return Estacavel;
    }

    public uint getID()
    {
        return ID;
    }

    public ushort getTipo()
    {
        return TipoItem;
    }
}

public class Arco : Item, Comercial
{
    public Arco()
    {
        this.TipoItem = (ushort)tipoItem.Arma;
        this.ID = 01;
        this.Nome = "ArcoRuan";
        this.Preco = 55;
        this.Estacavel = false;
        this.Descricao = "Arco de Ruan que Yasmim roubou";
    }

    public int getPreco()
    {
        return Preco;
    }
}

