
public class Envenenamento : Habilidade
{
    public void Atacar(Status e)
    {
        e.estadoAtual |= Estado.Envenenado;
        _3ReaisEngine.Engine.Debug("O oponente está envenenado");
    }
}