using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

public class SelPersonagem : Window
    {

        private string[] ImagePath = new string[4];
        private string[] ImagePath2 = new string[4];
        UImage charSelector;
        UImage charSelector2;
        private int i = 0;
    public SelPersonagem(Page root) : base(root,800,640)
        {
            ImagePath[0] = "Src/Images/Menu/Selecao_Personagem/Homem-Branco-Combate.png";
            ImagePath[1] = "Src/Images/Menu/Selecao_Personagem/Homem-Negro-Combate.png";
            ImagePath[2] = "Src/Images/Menu/Selecao_Personagem/Mulher-Branco-Combate.png";
            ImagePath[3] = "Src/Images/Menu/Selecao_Personagem/Mulher-Negro-Combate.png";

            ImagePath2[0] = "Src/Images/Menu/Selecao_Personagem/Homem-Branco-Combate.png";
            ImagePath2[1] = "Src/Images/Menu/Selecao_Personagem/Homem-Negro-Combate.png";
            ImagePath2[2] = "Src/Images/Menu/Selecao_Personagem/Mulher-Branco-Combate.png";
            ImagePath2[3] = "Src/Images/Menu/Selecao_Personagem/Mulher-Negro-Combate.png";

           

            UImage title = new UImage("Src/Images/Menu/Selecao_Personagem/Escolha_Personagem.png", new Vector2(50, 10), new Vector2(500, 100));
            UImage border = new UImage("Src/Images/Menu/Selecao_Personagem/Contorno.png", new Vector2(53, 45), new Vector2(300, 250));
            charSelector = new UImage(ImagePath[i], new Vector2(52.5f, 38f), new Vector2(100, 100));
            charSelector2 = new UImage(ImagePath2[i], new Vector2(52.5f, 56), new Vector2(50, 50));


            UButton man = new UButton("", new Vector2(23, 39), new Vector2(206, 78), Man);
            UButton woman = new UButton("", new Vector2(23, 54), new Vector2(206, 78), Woman);
            UButton rightSelector = new UButton("", new Vector2(58, 73), new Vector2(45, 41), RightSelector);
            UButton leftSelector = new UButton("", new Vector2(43, 73), new Vector2(45, 41), LeftSelector);
            UButton ready = new UButton("", new Vector2(52, 90), new Vector2(188, 49), Ready);


            Add(title);
            Add(border);
            Add(charSelector);
            Add(charSelector2);
            Add(man);
            Add(woman);
            Add(rightSelector);
            Add(leftSelector);
            Add(ready);


            man.setBackground("Src/Images/Menu/Selecao_Personagem/Homem.png",Stretch.Uniform);
            man.setOnHover("Src/Images/Menu/Selecao_Personagem/Homem_Selecionado.png");
            woman.setBackground("Src/Images/Menu/Selecao_Personagem/Mulher.png", Stretch.Uniform);
            woman.setOnHover("Src/Images/Menu/Selecao_Personagem/Mulher Selecionado.png");

            rightSelector.setBackground("Src/Images/Menu/Selecao_Personagem/Seta Direita.png", Stretch.Uniform);
            rightSelector.setOnHover("Src/Images/Menu/Selecao_Personagem/Seta Direita Selecionado.png");
            leftSelector.setBackground("Src/Images/Menu/Selecao_Personagem/Seta Esquerda.png", Stretch.Uniform);
            leftSelector.setOnHover("Src/Images/Menu/Selecao_Personagem/Seta Esquerda Selecionado.png");

            ready.setBackground("Src/Images/Menu/Selecao_Personagem/Pronto.png", Stretch.Uniform);
            ready.setOnHover("Src/Images/Menu/Selecao_Personagem/Pronto_Selecionado.png");
    }

   
    private void Ready(object sender)
    {
        //window.SetCurrent();
    }

    private void LeftSelector(object sender)
    {
        i--;
        if (i < 0) i = 3;
        charSelector.Content = ImagePath[i];
        charSelector2.Content = ImagePath2[i];
    }

    private void RightSelector(object sender)
    {
        i++;
        i %= ImagePath.Length;
        charSelector.Content = ImagePath[i];
        charSelector2.Content = ImagePath2[i];
    }

    private void Woman(object sender)
    {
        i = 2;
        charSelector.Content = ImagePath[i];
        charSelector2.Content = ImagePath2[i];
    }

    private void Man(object sender)
    {
        i = 0;
        charSelector.Content = ImagePath[i];
        charSelector2.Content = ImagePath2[i];
    }

}

