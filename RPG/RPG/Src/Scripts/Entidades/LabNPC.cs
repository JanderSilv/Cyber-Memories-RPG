using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RPG.Src.Scripts.Entidades
{
    class LabNPC:Entidade
    {
        Render render;
        Animacao anim;
        Colisao col;
        Body body;
        Chat chat;
        Chat chat2;
        Movel movel;

        bool Chat1 = false;
        public LabNPC()
        {
            render = AddComponente<Render>();
            anim = AddComponente<Animacao>();
            col = AddComponente<Colisao>();
            body = AddComponente<Body>();
            movel = AddComponente<Movel>();
            body.Init();
            movel.Init();
            col.tamanho.x = 50;
            col.tamanho.y = 20;
            col.tipo = TipoColisao.Dinamica;

            render.img.Width = 50;
            render.img.Height = 50;
            
            body.drag = 4;

            anim.AddAnimation("Move_Left", "Src/Images/Players/Mulher Negro/Lab/anim/Lab_Esquerda.gif");
            anim.AddAnimation("Move_Right", "Src/Images/Players/Mulher Negro/Lab/anim/Lab_Direita.gif");
            anim.AddAnimation("Move_Down", "Src/Images/Players/Mulher Negro/Lab/anim/Lab_Frente.gif");
            anim.AddAnimation("Move_Up", "Src/Images/Players/Mulher Negro/Lab/anim/Lab_Fundo.gif");

            anim.AddAnimation("Stop_Left", "Src/Images/Players/Mulher Negro/Lab/Esquerda_Parado.png");
            anim.AddAnimation("Stop_Right", "Src/Images/Players/Mulher Negro/Lab/Direita_Parado.png");
            anim.AddAnimation("Stop_Up", "Src/Images/Players/Mulher Negro/Lab/Fundo_Parado.png");
            anim.AddAnimation("Stop_Down", "Src/Images/Players/Mulher Negro/Lab/Frente_Parado.png");
            anim.Play("Stop_Up");

            chat = new Chat();
            chat.SenderImage = "Src/Images/Players/Mulher Negro/Face.png";
            chat.ReceiverImage = "Src/Images/Players/" + Player.currentPlayer.skin + "/Face.png";
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Aí esta voce!"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Achava ninguém viria novamente..."));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Bom, no relatório constava ser a pista mais concreta até agora"));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Os superiores decidiram permitir"));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Entao... \n O que temos desta vez?"));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Um salto cyber punk?"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Não"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Por mais inacreditável que possa parecer, todos os scanners temporais indicam um periodo de tempo antes da corrida infinita"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Mais especificamente Idade Média"));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Isso é muito estranho mesmo até para ele"));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "O que estaria fazendo tao longe no tempo?"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Espero que n precisemos saber"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Porém devido a vários outros trabalhos não pudemos terminar seu salto ainda"));
            chat.messages.Add(new Chat.Message(Chat.who.sender, "Fique à vontade enquanto faço os ajustes necessários "));
            chat.messages.Add(new Chat.Message(Chat.who.receiver, "Ok"));
            chat2 = new Chat();
            chat2.SenderImage = "Src/Images/Players/Mulher Negro/Face.png";
            chat2.ReceiverImage = "Src/Images/Players/" + Player.currentPlayer.skin + "/Face.png";
            chat2.messages.Add(new Chat.Message(Chat.who.sender, "Ainda não terminei"));
        }

        public override void Update()
        {
           
        }
        public override void OnClick(MouseEvento e)
        {
            if (e.Tipo == Modificador.ButtonUp && Engine.Distance(this.EntPos, Player.currentPlayer.EntPos) < 100)
            {
               
                    Quest q = Player.currentPlayer.quest.GetQuestAtiva(new FalarComNPC().Nome);
                    if (q != null) q.Data["Falou"] = true;
                    else Engine.Print("N tem missao");
              
                    anim.Play("Stop_Down");
                if (Chat1 == false)
                {
                    ChatBar.ShowChat(chat);
                    Chat1 = true;
                }
                else
                {
                    ChatBar.ShowChat(chat2);
                }
                 

            }
        }
    }
}
