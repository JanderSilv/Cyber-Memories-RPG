public class EspadaAco : Item, Comercial, Atacavel, Equipavel
{

    public EspadaAco()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Espada de Aço";
        Preco = 0;
        Estacavel = false;
        Descricao = "Espada forjada em aço";
        Icone = "Src/Images/Itens/Arma/Espada.png";
        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID do espadaaco" + ID);
    }

    public void Equipar(Status e)
    {
        e.forca += 5;
        e.destreza += 2;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 27;
    }

    public int getPreco()
    {
        return Preco;
    }
}



