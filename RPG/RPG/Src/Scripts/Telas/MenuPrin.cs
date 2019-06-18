using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class MenuPrin : Window
{
    public Window next;
    public Window about;
    public MenuPrin(Page root) : base(root)
    {
                    /* Algoritmo do Menu */

        UImage logo = new UImage("Src/Images/Menu/Logo2.png", new Vector2(50, 22), new Vector2(570, 185));

        UButton btn_Jogar = new UButton("", new Vector2(50, 48), new Vector2(229, 86), Play);
        UButton btn_Conf  = new UButton("", new Vector2(50, 67), new Vector2(229, 86));
        UButton btn_Sair  = new UButton("", new Vector2(50, 86), new Vector2(229, 86), Exit);
        //UButton btn_Sobre = new UButton("", new Vector2(92, 92), new Vector2(103, 35), About);

        btn_Jogar.setBackground("Src/Images/Menu/Botões/Iniciar.png", Stretch.Uniform);
        btn_Conf .setBackground("Src/Images/Menu/Botões/Configurações.png", Stretch.Uniform);
        btn_Sair .setBackground("Src/Images/Menu/Botões/Sair.png", Stretch.Uniform);

        btn_Jogar.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png");
        btn_Conf.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");
        btn_Sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");

        Add(logo);
        //Add(btn_Sobre);
        Add(btn_Jogar);
        Add(btn_Conf);
        Add(btn_Sair);

        /* Algoritmo da aba Sobre */

    //    UButton btn_Voltar = new UButton("", new Vector2(11, 7), new Vector2(145, 37), Voltar);

    //    btn_Voltar.setBackground("Src/Images/Menu/Botões/Voltar.png");
    //    btn_Voltar.setOnHover("Src/Images/Menu/Botões/Voltar_Selecionado.png");

    //    about.Add(btn_Voltar);
    }

    //private void Voltar(object sender)
    //{
    //    //
    //}

    private void Exit(object sender)
    {
        Environment.Exit(0);
    }

    private void Play(object sender)
    {
        next.SetCurrent(); 
    }


}
