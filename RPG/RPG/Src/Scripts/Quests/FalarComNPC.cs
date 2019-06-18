using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FalarComNPC : Quest
{
    public FalarComNPC()
    {

        Nome = "Estou perdido";
        Descricao = "Fale com a pessoa do laboratorio";
        Data.Add("Falou", false);
    }
    public override bool Validate()
    {
        return Data["Falou"];
    }

    public override void OnFinish()
    {
        ChatBar.ShowChat("", "Quest completa: \n" + Nome + "\n" + Descricao+ "\nQuest liberada: Curiosidade so mata gato");
        Desbloq.Add(new OlheAoRedor());
        
    }
}

public class OlheAoRedor : Quest
{
    public OlheAoRedor()
    {
        Requeriments.Add(new FalarComNPC());
        Nome = "Curiosidade so mata gato";
        Descricao = "Aproveite o tempo para olhar o laboratorio";
        Data.Add("Feito", 0);
    }
    public override bool Validate()
    {
        return Data["Feito"] == 3;
    }
    public override void OnFinish()
    {
        ChatBar.ShowChat("", "Quest completa: \n" + Nome + "\n" + Descricao);
    }
}
