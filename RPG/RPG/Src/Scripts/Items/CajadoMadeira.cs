public class CajadoMadeira : Item, Comercial, Atacavel, Equipavel
{
    
    public CajadoMadeira()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Cajado de Madeira";
        Preco = 0;
        Estacavel = false;
        Descricao = "Cajado maciço feito de carvalho";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do cajadomadeira " + ID);
    }

    public void Equipar(Status e)
    {
        e.inteligencia += 30;
        e.destreza += 2;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 18;
    }

    public int getPreco()
    {
        return Preco;
    }
}



