public static class ItemManager
{
    static ushort qntArmadura = 0;
    static ushort qntArma = 0;
    static ushort qntConsumivel = 0;
    static ushort qntEncantavel = 0;
    /// <summary>
    /// Se estacavel for setado como true, suggested_id será utilizado para fazer o id, e este id resultante será igual para todos os objetos instanciados do mesma classe
    /// </summary>
    /// <param name="item"></param>
    /// <param name="suggested_id"></param>
    public static void GenID(Item item,ushort suggested_id=1)
    {

        uint t = (ushort)item.TipoItem;
        uint id = 0;
        uint low = (uint)0x0000FFFF;
        t = (t << 16);

        item.ID = (t & 0xFFFF0000);


        if (!item.Estacavel)
        {
            if (item.TipoItem == (ushort)tipoItem.Armadura)
            {
                qntArmadura++;
                id = qntArmadura & low;
            }
            if (item.TipoItem == (ushort)tipoItem.Arma)
            {
                qntArma++;
                id = qntArma & low;
            }
            if (item.TipoItem == (ushort)tipoItem.Consumivel)
            {
                qntConsumivel++;
                id = qntConsumivel & low;
            }
            if (item.TipoItem == (ushort)tipoItem.Encantavel)
            {
                qntEncantavel++;
                id = qntEncantavel & low;
            }
        }
        else
        {
            id = suggested_id & low;
        }
      
        item.ID |= id;

    }
}

