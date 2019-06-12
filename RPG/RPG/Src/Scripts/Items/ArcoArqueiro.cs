public class ArcoArqueiro : Item, Comercial, Atacavel, Equipavel
{

    public ArcoArqueiro()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Arco do Arqueiro";
        Preco = 500;
        Estacavel = false;
        Descricao = "Arco longo de combate melhorado";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID do arcoarqueiro " + ID);
    }

    public void Equipar(Status e)
    {
         e.destreza += 15;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 48;
    }

    public int getPreco()
    {
        return Preco;
    }
}



