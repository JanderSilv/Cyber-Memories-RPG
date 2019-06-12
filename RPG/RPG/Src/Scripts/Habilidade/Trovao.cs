public class Trovao : Habilidade
{
    public void Atacar(Status e)
    {
        e.saude -= 15;
        e.estadoAtual |= Estado.Paralisado;
        _3ReaisEngine.Engine.Print("O oponente está paralisado");
    }
}