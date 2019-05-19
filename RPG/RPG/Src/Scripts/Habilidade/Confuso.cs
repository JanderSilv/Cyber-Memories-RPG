
public class Confuso : Habilidade
{
    public void Atacar(Status e)
    {
        e.estadoAtual |= Estado.Confuso;
        e.saude -= 5;
        _3ReaisEngine.Engine.Debug("O oponente está confuso");
    }
}