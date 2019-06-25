public class Armadura : Item, Comercial, Equipavel
{
    public Armadura()
    {
        TipoItem = (ushort)tipoItem.Armadura;
        Estacavel = false;
        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID da armadura " + ID);
    }

    public void Atacar(Combate e)
    {

    }

    public void Desequipar(Combate e)
    {
       
    }

    public void Equipar(Combate e)
    {

    }

    public int getPreco()
    {
        return Preco;
    }
}

public class Elmo : Armadura
{

}
public class Peitoral: Armadura
{

}
public class Calca: Armadura
{

}
public class Bota: Armadura
{

}
