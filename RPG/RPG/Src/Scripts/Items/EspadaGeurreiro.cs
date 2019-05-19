public class EspadaGuerreiro : Item, Comercial, Atacavel, Equipavel
{

    public EspadaGuerreiro()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Espada de Aço";
        Preco = 500;
        Estacavel = false;
        Descricao = "Espada forjada por um habilidoso ferreiro";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do espadaguerreiro" + ID);
    }

    public void Equipar(Status e)
    {
        e.forca += 10;
        e.destreza += 5;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 50;
    }

    public int getPreco()
    {
        return Preco;
    }
}



