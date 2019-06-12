
public class Envenenamento : Habilidade
{
    public void Atacar(Status e)
    {
        e.estadoAtual |= Estado.Envenenado;
        _3ReaisEngine.Engine.Print("O oponente está envenenado");
    }
}