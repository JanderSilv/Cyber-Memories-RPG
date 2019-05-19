public class CajadoMerlim : Item, Comercial, Atacavel, Equipavel
{
    Tempestade temp;
    Trovao trov;

    public CajadoMerlim()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Cajado de Merlim";
        Preco = 3000;
        Estacavel = false;
        Descricao = "Cajado forjado pelo mago mais poderoso da terra";

        temp = new Tempestade();
        trov = new Trovao();

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do cajadomerlim " + ID);
    }

    public void Equipar(Status e)
    {
        e.inteligencia += 65;
        e.destreza += 8;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 60;
        //Efeito Trovão
        trov.Atacar(e);
        //Efeito Tempestade
        temp.Atacar(e);
    }

    public int getPreco()
    {
        return Preco;
    }
}



