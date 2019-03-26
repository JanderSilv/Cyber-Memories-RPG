
public class Arco : Item, Comercial,Atacavel,Equipavel
{
    public Arco()
    {
        this.TipoItem = (ushort)tipoItem.Arma;
        this.Nome = "ArcoRuan";
        this.Preco = 55;
        this.Estacavel = false;
        this.Descricao = "Arco de Ruan que Yasmim roubou";
        
        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Debug("ID do arco " + ID);
    }

    public void Equipar(Status e)
    {
        e.velocidade += 0.5f;
    }

    public void Atacar(Status e)
    {
        e.saude -= 5;           
    }
    
    public int getPreco()
    {
        return Preco;
    }
}



