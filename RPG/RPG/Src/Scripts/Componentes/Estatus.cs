using _3ReaisEngine.Core;
using System.Collections.Generic;

 
    public enum Estado
    {
        Normal,Envenenado,Paralisado,Confuso,Dormindo
    }

    public class Status:Componente<Status>
    {
    public int forca,inteligencia,resistencia,sorte,saude,destreza;
    public float velocidade;
    public Estado estadoAtual;
    public List<Atacavel> efeitos = new List<Atacavel>();
    }

