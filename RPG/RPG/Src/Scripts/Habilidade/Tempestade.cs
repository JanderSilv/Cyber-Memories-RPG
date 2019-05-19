public class Tempestade : Habilidade
{
    public void Atacar(Status e)
    {
        e.saude -= 40;
        e.estadoAtual |= Estado.Paralisado;
        _3ReaisEngine.Engine.Debug("O oponente está paralisado");
    }
}