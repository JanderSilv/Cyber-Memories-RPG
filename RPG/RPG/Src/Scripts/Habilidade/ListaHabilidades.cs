using System;

public class CorteFogo : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude -= 25 / (1 + e.resistencia / 100);
    }
}
public class CortesMultiplos : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude -= 40 / (1 + e.resistencia / 100);
    }
}
public class Trovao : Habilidade
{
    public void Atacar(Combate e)
    {
     if(new Random().Next(0,100)<80-e.sorte) e.estadoAtual = Estado.Paralisado;
    }
}
public class FlechaGelo : Habilidade
{
    public void Atacar(Combate e)
    {
        e.saude = 20 / (1 + e.resistencia / 100);
    }
}