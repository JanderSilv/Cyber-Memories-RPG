using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MessageBox 
    {
    public UPanel panel ;

    bool response;
    Execute act1 = null, act2 = null;
    Window win;
    public MessageBox(string Titulo, string Descricao, Vector2 pos, object contentBtn1, object contentBtn2,Execute act1,Execute act2,Window win)
    {
        panel = new UPanel(pos, new Vector2(300, 200));
        panel.manipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;

       
        UText title = new UText(Titulo, new Vector2(50, 50));
        panel.addChild(title);

       

        UButton sim = new UButton(contentBtn1 ?? "Sim", new Vector2(25, 80), new Vector2(100, 50));
        sim.setBackground("Src/Images/Menu/Botões/Iniciar.png");
        sim.Action = onSim;
        panel.addChild(sim);

        UButton nao = new UButton(contentBtn2 ?? "Nao", new Vector2(75, 80), new Vector2(100, 50));
        nao.setBackground("Src/Images/Menu/Botões/Sair.png");
        nao.Action = onNao;
        panel.addChild(nao);

        this.act1 = act1;
        this.act2 = act2;
        this.win = win;
    }

    private void onNao(object sender)
    {
        response = false;
        act2?.Invoke(sender);
        Del();
    }

    private void onSim(object sender)
    {
        response = true;
        act1?.Invoke(sender);
        Del();
    }


    private void Del()
    {
        win.Remove(panel);
    }
    public bool GetResponse() => response;
}

