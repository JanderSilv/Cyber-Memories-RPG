using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
  
        Window selecao;

        private string[] ImagePath = new string[4];
        private string[] ImagePath2 = new string[4];
        private int i = 0;

        UImage charSelector;
        UImage charSelector2;

        public MainPage()
        {       
            InitializeComponent();

            #region Preenchimento do vetor de imagens
            ImagePath[0] = "Src/Images/Menu/Selecao_Personagem/Homem-Branco-Face.png";
            ImagePath[1] = "Src/Images/Menu/Selecao_Personagem/Homem-Negro-Face.png";
            ImagePath[2] = "Src/Images/Menu/Selecao_Personagem/Mulher-Branco-Face.png";
            ImagePath[3] = "Src/Images/Menu/Selecao_Personagem/Mulher-Negro-Face.png";

            ImagePath2[0] = "Src/Images/Menu/Selecao_Personagem/Homem-Branco-Combate.png";
            ImagePath2[1] = "Src/Images/Menu/Selecao_Personagem/Homem-Negro-Combate.png";
            ImagePath2[2] = "Src/Images/Menu/Selecao_Personagem/Mulher-Branco-Combate.png";
            ImagePath2[3] = "Src/Images/Menu/Selecao_Personagem/Mulher-Negro-Combate.png";
            #endregion

       
            selecao = new Window(this, 840, 620);

            UPanel panel = new UPanel(new Vector2(50, 50), new Vector2(200, 300));

            UButton play = new UButton("", new Vector2(50, 30), new Vector2(100, 50));
            UButton conf = new UButton("", new Vector2(50, 55), new Vector2(100, 50));
            UButton sair = new UButton("", new Vector2(50, 80), new Vector2(100, 50));

            play.setBackground("Src/Images/Menu/Botões/Iniciar.png");
            play.setOnHover("Src/Images/Menu/Botões/Jogar_Selecionado.png");
            conf.setBackground("Src/Images/Menu/Botões/Configurações.png");
            conf.setOnHover("Src/Images/Menu/Botões/Configurações_Selecionado.png");
            sair.setBackground("Src/Images/Menu/Botões/Sair.png");
            sair.setOnHover("Src/Images/Menu/Botões/Sair_Selecionado.png");

            // panel.addChild(play);
            panel.addChild(conf);
            panel.addChild(sair);
            panel.manipulationMode = ManipulationModes.All;

            selecao.Add(play);

            selecao.SetCurrent();
            SelecaoDePersonagem();


           
        }

        void SelecaoDePersonagem() {

            UImage title = new UImage("Src/Images/Menu/Selecao_Personagem/Escolha_Personagem.png", new Vector2(26, 10), new Vector2(100, 100));
            UImage border = new UImage("Src/Images/Menu/Selecao_Personagem/Contorno.png", new Vector2(45, 30), new Vector2(100,100));
            charSelector = new UImage(ImagePath[i], new Vector2(48, 31), new Vector2(100,100));
            charSelector2 = new UImage(ImagePath2[i], new Vector2(54, 56), new Vector2(100, 100));


            UButton man = new UButton("", new Vector2(23, 39), new Vector2(206, 78), Man);
            UButton woman = new UButton("", new Vector2(23, 54), new Vector2(206, 78), Woman);
            UButton rightSelector = new UButton("", new Vector2(58, 73), new Vector2(45, 41), RightSelector);
            UButton leftSelector = new UButton("", new Vector2(43, 73), new Vector2(45, 41), LeftSelector);
            UButton ready = new UButton("", new Vector2(52,90), new Vector2(188,49), Ready);


            selecao.Add(title);
            selecao.Add(border);
            selecao.Add(charSelector);
            selecao.Add(charSelector2);
            selecao.Add(man);
            selecao.Add(woman);
            selecao.Add(rightSelector);
            selecao.Add(leftSelector);
            selecao.Add(ready);


            man.setBackground("Src/Images/Menu/Selecao_Personagem/Homem.png");
            man.setOnHover("Src/Images/Menu/Selecao_Personagem/Homem_Selecionado.png");
            woman.setBackground("Src/Images/Menu/Selecao_Personagem/Mulher.png");
            woman.setOnHover("Src/Images/Menu/Selecao_Personagem/Mulher Selecionado.png");
            rightSelector.setBackground("Src/Images/Menu/Selecao_Personagem/Seta Direita.png");
            rightSelector.setOnHover("Src/Images/Menu/Selecao_Personagem/Seta Direita Selecionado.png");
            leftSelector.setBackground("Src/Images/Menu/Selecao_Personagem/Seta Esquerda.png");
            leftSelector.setOnHover("Src/Images/Menu/Selecao_Personagem/Seta Esquerda Selecionado.png");
            ready.setBackground("Src/Images/Menu/Selecao_Personagem/Pronto.png");
            ready.setOnHover("Src/Images/Menu/Selecao_Personagem/Pronto_Selecionado.png");
        }
        #region Metodos dos botões
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
        #endregion

    }
}