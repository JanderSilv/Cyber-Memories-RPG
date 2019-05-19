using _3ReaisEngine.Core;

public enum Estado
{

    Normal = 1, Envenenado = 2, Paralisado = 4, Confuso = 8, Dormindo = 16
}

public class Status : Componente<Status>
{
    public int forca, inteligencia, resistencia, sorte, saude, destreza,level;
    public float velocidade;
    public double  xpMax, xpRecebido, xpAtual;
    public Estado estadoAtual;


    public bool upLevel(Status e)
    {
        if (e.xpAtual == e.xpMax)
        {
            e.xpMax = e.xpMax * 1.50;
            e.level += 1;
            e.xpAtual = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
