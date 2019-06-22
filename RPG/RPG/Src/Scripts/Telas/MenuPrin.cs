using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Components;
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
    public UPanel about;
    static public Audio musicaDeFundo = new Audio();
    public MenuPrin(Page root) : base(root)
    {
                    /* Algoritmo do Menu */

        
        AudioSource As = new AudioSource();
        As.Name = "Funkaholic.mp3";
        As.Loop = true;
        As.Volume = 0.1f;
        musicaDeFundo.Init();
        musicaDeFundo.Audios.Add("Musica", As);
        musicaDeFundo.Play("Musica");


        UImage logo = new UImage("Src/Images/Menu/Logo2.png", new Vector2(50, 22), new Vector2(570, 185));
        UImage background = new UImage("Src/Images/Menu/Botões/Mountains1.png", new Vector2(50, 50), new Vector2(1000,1000));

        UButton btn_Jogar = new UButton("", new Vector2(50, 48), new Vector2(229, 86), Play);
        UButton btn_Conf  = new UButton("", new Vector2(50, 67), new Vector2(229, 86));
        UButton btn_Sair  = new UButton("", new Vector2(50, 86), new Vector2(229, 86), Exit);
        UButton btn_Sobre = new UButton("", new Vector2(92, 92), new Vector2(103, 35), About);

        btn_Jogar.setBackground("Src/Images/Menu/Botões/Iniciar.png", Stretch.Uniform);
        btn_Conf.setBackground("Src/Images/Menu/Botões/Configurações.png", Stretch.Uniform);
        btn_Sair.setBackground("Src/Images/Menu/Botões/Sair.png", Stretch.Uniform);
        btn_Sobre.setBackground("Src/Images/Menu/Botões/Sobre.png");

        btn_Jogar.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png");
        btn_Conf.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");
        btn_Sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");
        btn_Sobre.setOnHover("Src/Images/Menu/Botões/Sobre_Selecionado.png");

        Add(background);
        Add(logo);
        Add(btn_Sobre);
        Add(btn_Jogar);
        Add(btn_Conf);
        Add(btn_Sair);

        /* Algoritmo da aba Sobre */

        about = new UPanel(new Vector2(50, 50), new Vector2(800, 640));

        UButton btn_Voltar = new UButton("", new Vector2(11, 7), new Vector2(145, 37), Voltar);
        
        btn_Voltar.setBackground("Src/Images/Menu/Botões/Voltar.png");
        btn_Voltar.setOnHover("Src/Images/Menu/Botões/Voltar_Selecionado.png");

        about.SetBackGround("Src/Images/Menu/Botões/Sobre.jpg");
        about.addChild(btn_Voltar);
    }


    private void About(object sender)
    {
        Add(about);
    }

    private void Voltar(object sender)
    {
        Remove(about);
    }

    private void Exit(object sender)
    {
        Environment.Exit(0);
    }

    private void Play(object sender)
    {
        
        next.SetCurrent(); 
    }


}
