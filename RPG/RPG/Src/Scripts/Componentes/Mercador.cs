using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;

public enum CambioResult
{
    Sucesso,
    DinheiroInsuficiente,
    InventarioCheio,
    ForaDeEstoque
}

/*
 *  Componente que permite duas entidades realizarem compra e venda de items,
 *  é necessario que a entidade tenha um inventario
 */
[RequerComponente(typeof(Inventario))]
class Mercador : Componente<Mercador>
{
    public int dinheiro = 0; //dinheiro usado nas compras
    private Inventario inventario; //local onde o mercador vai armazenar e remover os items

    public override void Init()
    {
        GetInventario();
    }

    Inventario GetInventario() //retorna o inventario do Mercador
    {
        if (inventario == null) inventario = entidade.GetComponente<Inventario>();
        return inventario;
    }

    public CambioResult Comprar(Mercador vendedor, uint itemID) //Ester mercador quer comprar de outro mercador
    {
        Comercial item = inventario.GetByID(itemID) as Comercial; //verifica se o vendedor tem o item
        if (item == null) return CambioResult.ForaDeEstoque;//caso o vendedor n tenha o item

        int preco = item.getPreco();//pega o preco do item

        if (preco > dinheiro) return CambioResult.DinheiroInsuficiente;//verifica se tem dinheiro pra pagar
        if (GetInventario().limite <= GetInventario().slots.Count) return CambioResult.InventarioCheio;//verifica se tem onde botar o item

        vendedor.dinheiro += preco;//da o dinheiro ao vendedor
        inventario.Remove(itemID);//pega o item do vendedor
        inventario.Add(item);//guarda o item

        return CambioResult.Sucesso;
    }

    public CambioResult Vender(Mercador comprador, uint itemID) //Este mercador quer vender a outro mercador
    {
        Comercial item = inventario.GetByID(itemID) as Comercial; //verifica se tem item para vender
        if (item == null) return CambioResult.ForaDeEstoque;//caso nao tenha
        int preco = item.getPreco();//verifica o preco do item

        if (preco > comprador.dinheiro) return CambioResult.DinheiroInsuficiente;//se o comprador nao tem dinheiro nao vende
        if (comprador.GetInventario().limite <= comprador.GetInventario().slots.Count) return CambioResult.InventarioCheio; //verifica se o comprador tem onde botar o item

        dinheiro += preco;//recebe dinheiro do comprador
        Armazenavel arm = inventario.Remove(item); //tira o item do inventario
        inventario.Add(arm);//da o item ao comprador
        return CambioResult.Sucesso;
    }
}

