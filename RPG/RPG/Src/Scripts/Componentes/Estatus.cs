using _3ReaisEngine.Core;

public enum Estado
{

    Normal = 1, Envenenado = 2, Paralisado = 4, Confuso = 8, Dormindo = 16
}

public class Status : Componente<Status>
{
    public int forca, inteligencia, resistencia, sorte, saude, destreza;
    public float velocidade;
    public Estado estadoAtual;
}

