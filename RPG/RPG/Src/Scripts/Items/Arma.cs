public class Arma : Item, Comercial, Atacavel, Equipavel
{
    public Habilidade habilidade;
    public int danoBasico;

    public Arma()
    {
        TipoItem = (ushort)tipoItem.Arma;
        ItemManager.GenID(this);
    }

    public void Atacar(Combate e)
    {
        e.saude -= danoBasico;
    }

    public virtual void Desequipar(Combate e)
    {
       
    }

    public virtual void Equipar(Combate e)
    {
        
    }

    public int getPreco()
    {
        return Preco;
    }
}

