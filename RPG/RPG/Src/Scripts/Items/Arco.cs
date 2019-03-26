public class Arco : Item, Comercial,Atacavel,Equipavel
{
    Envenenamento env;
    Trovao trov;

    public Arco()
    {
        this.TipoItem = (ushort)tipoItem.Arma;
        this.Nome = "ArcoRuan";
        this.Preco = 55;
        this.Estacavel = false;
        this.Descricao = "Arco de Ruan que Yasmim roubou";
        env = new Envenenamento();
        trov = new Trovao(); 
        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do arco " + ID);
    }

    public void Equipar(Status e)
    {
        e.velocidade += 0.5f;
    }

    public void Atacar(Status e)
    {
        //Ação comum
        e.saude -= 5;
        //Efeito de trovao
        trov.Atacar(e);
        //Envenamento
        env.Atacar(e);
    }
    
    public int getPreco()
    {
        return Preco;
    }
}



