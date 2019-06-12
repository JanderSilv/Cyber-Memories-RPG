
public class Cegueira : Habilidade
{
    public void Atacar(Status e)
    {
        e.estadoAtual |= Estado.Cego;
        _3ReaisEngine.Engine.Print("O oponente está cego");
    }
}