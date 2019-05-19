public class Excalibur : Item, Comercial, Atacavel, Equipavel
{
    AtaqueForte af;
    CorteFogo cf;

    public Excalibur()
    {
        TipoItem = (ushort)tipoItem.Arma;
        Nome = "Excalibur";
        Preco = 3000;
        Estacavel = false;
        Descricao = "Lendária espada do Rei Artur";

        cf = new CorteFogo();
        af = new AtaqueForte();

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do excalibur" + ID);
    }

    public void Equipar(Status e)
    {
        e.forca += 15;
        e.destreza += 7;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 100;
        //Efeito Ataque Forte
        af.Atacar(e);
        //Efeito Corte de Fogo
        cf.Atacar(e);
    }

    public int getPreco()
    {
        return Preco;
    }
}



