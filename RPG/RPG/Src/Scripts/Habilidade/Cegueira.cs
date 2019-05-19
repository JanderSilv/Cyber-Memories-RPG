
public class Cegueira : Habilidade
{
    public void Atacar(Status e)
    {
        e.estadoAtual |= Estado.Cego;
        _3ReaisEngine.Engine.Debug("O oponente está cego");
    }
}