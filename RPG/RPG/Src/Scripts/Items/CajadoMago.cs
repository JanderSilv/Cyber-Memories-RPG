public class CajadoMago : Item, Comercial, Atacavel, Equipavel
{

    public CajadoMago()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Cajado do Mago";
        Preco = 500;
        Estacavel = false;
        Descricao = "Cajado de carvalho forjado com uma gema mágica";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID do cajadomago " + ID);
    }

    public void Equipar(Status e)
    {
        e.inteligencia += 48;
        e.destreza += 5;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 34;
    }

    public int getPreco()
    {
        return Preco;
    }
}



