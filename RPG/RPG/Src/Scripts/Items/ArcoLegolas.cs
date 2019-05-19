public class ArcoLegolas : Item, Comercial, Atacavel, Equipavel
{
    Nevasca nev;
    FlechaGelo gelo;

    public ArcoLegolas()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Arco do Légolas";
        Preco = 3000;
        Estacavel = false;
        Descricao = "Arco do grandioso elfo Sindar Légolas";

        gelo = new FlechaGelo();
        nev = new Nevasca();

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do arcolegolas " + ID);
    }

    public void Equipar(Status e)
    {
        e.destreza += 20;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 98;
        //Efeito Nevasca
        nev.Atacar(e);
        //Efeito FlechaGelo
        gelo.Atacar(e);
    }

    public int getPreco()
    {
        return Preco;
    }
}



