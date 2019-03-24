using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum tipoItem:Int16
{
    Armadura=1,
    Arma=2,
    Consumivel=4,
    Encantavel=8
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

    public Int16 getTipo()
    {
        return (Int16)tipo;
    }
}

