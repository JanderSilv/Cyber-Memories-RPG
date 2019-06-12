public class ArcoMadeira : Item, Comercial, Atacavel, Equipavel
{

    public ArcoMadeira()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Arco de Madeira";
        Preco = 0;
        Estacavel = false;
        Descricao = "Arco feito para a caça";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID do arcomadeira " + ID);
    }

    public void Equipar(Status e)
    {
        e.destreza += 10;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 21;
    }

    public int getPreco()
    {
        return Preco;
    }
}



