public class CorteFogo : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude -= 25;
    }
}
public class CortesMultiplos : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude -= 40;
    }
}
public class Trovao : Habilidade
{
    public void Atacar(Combate e)
    {
        e.estadoAtual = Estado.Paralisado;
    }
}
public class FlechaGelo : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude = 20;
    }
}