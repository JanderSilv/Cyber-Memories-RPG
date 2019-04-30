using System;
using System.Threading.Tasks;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using RPG.Src.Scripts;
using Windows.UI.Xaml.Controls;

namespace RPG
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            //cria a janela e seta ela como a atual
            //                                           v~~ altura da janela  
            AmbienteJogo.window = new Window(this, 840, 620); 
            //                                      ^~~ largura da janela

            //adiciona botao na janela (posição dada em %)
            AmbienteJogo.window.AddUI(new UButton("Jander", new Vector2(50, 50), new Vector2(100, 50))); 
            //                                                   ^~~ posicao na janela       ^~~ tamanho do botao

            //instancia jogador
            Player p = new Player(new Vector2(0, 0)); 

            //adiciona jogador ao jogo
            AmbienteJogo.AdcionarEntidade(p); 

            //seta jogador pra ser seguido pela camera
            AmbienteJogo.currentCamera.setSeek(p);
            //            ^~~ pode ser simplificado com AmbienteJogo.currentCamera.setSeek(AmbienteJogo.AdcionarEntidade(p)); visto q AdicionarEntidade retorna a entidade adicionada

            //cria caixa ("opera") e adiciona ao jogo
            AmbienteJogo.AdcionarEntidade(new Caixa(new Vector2(-200, 0))); 
        }
    }
}
