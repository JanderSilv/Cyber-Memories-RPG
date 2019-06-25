public class CajadoMaderia : Arma
{
    public CajadoMaderia()
    {
        Nome = "Cajado de Madeira";
        danoBasico = 18;
        Preco = 50;
        habilidade = new Trovao();
        Icone = "Src/Images/Itens/Arma/Cajado.png";
    }

    public override void Equipar(Combate e)
    {
        e.inteligencia += 30;
    }

    public override void Desequipar(Combate e)
    {
        e.inteligencia -= 30;
    }
}
public class EspadaAco : Arma
{
    public EspadaAco()
    {
        Nome = "Espada de Aço";
        danoBasico = 35;
        Preco = 50;
        habilidade = new CorteFogo();
        Icone = "Src/Images/Itens/Arma/Espada.png";
    }

    public override void Equipar(Combate e)
    {
        e.forca += 5;
    }

    public override void Desequipar(Combate e)
    {
        e.forca -= 5;
    }
}
public class ArcoMadeira : Arma
{
    public ArcoMadeira()
    {
        Nome = "Arco de Madeira";
        danoBasico = 29;
        Preco = 50;
        habilidade = new FlechaGelo();
        Icone = "Src/Images/Itens/Arma/Arco.png";
    }

    public override void Equipar(Combate e)
    {
        e.destreza += 10;
    }

    public override void Desequipar(Combate e)
    {
        e.destreza -= 10;
    }
}
public class AdagaAco : Arma
{
    public AdagaAco()
    {
        Nome = "Adaga de Aço";
        danoBasico = 15;
        Preco = 50;
        habilidade = new CortesMultiplos();
        Icone = "Src/Images/Itens/Arma/Adaga.png";
    }

    public override void Equipar(Combate e)
    {
        e.destreza += 15;
    }

    public override void Desequipar(Combate e)
    {
        e.destreza -= 15;
    }
}