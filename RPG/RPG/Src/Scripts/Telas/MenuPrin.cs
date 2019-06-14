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
    public MenuPrin(Page root) : base(root)
    {
        UButton btn_Jogar = new UButton("", new Vector2(50, 40), new Vector2(150, 75), play);
        UButton btn_Conf  = new UButton("", new Vector2(50, 50), new Vector2(150, 75));
        UButton btn_Sair  = new UButton("", new Vector2(50, 60), new Vector2(150, 75));

        btn_Jogar.setBackground("Src/Images/Menu/Botões/Iniciar.png", Stretch.Uniform);
        btn_Conf .setBackground("Src/Images/Menu/Botões/Configurações.png", Stretch.Uniform);
        btn_Sair .setBackground("Src/Images/Menu/Botões/Sair.png", Stretch.Uniform);

        btn_Jogar.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png");
        btn_Conf.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");
        btn_Sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");

        Add(btn_Jogar);
        Add(btn_Conf);
        Add(btn_Sair);
    }

    private void play(object sender)
    {
        next.SetCurrent(); 
    }
}
