public enum tipoItem : ushort
{
    Armadura = 1,
    Arma = 2,
    Consumivel = 3,
    Encantavel = 4
}

public class Item : Armazenavel
{
    public uint ID;
    public string Descricao;
    public string Nome;
    public int Preco;
    public bool Estacavel;
    public ushort TipoItem;
    public string Icone;

    public bool getEstacavel()
    {
        return Estacavel;
    }

    public uint getID()
    {
        return ID;
    }

    public string getImagem()
    {
        return Icone;
    }

    public T getItem<T>()
    {
        return (T)((object)this);
    }

    public ushort getTipo()
    {
        return TipoItem;
    }

 
}

