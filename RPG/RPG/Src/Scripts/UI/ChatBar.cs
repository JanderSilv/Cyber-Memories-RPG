using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI;


public class Chat
{
    public enum who
    {
        sender,receiver
    };
    public struct Message
    {
        public who who;
        public string message;
        public Message(who who,string message)
        {
            this.who = who;
            this.message = message;
        }
    }

   public List<Message> messages = new List<Message>();
    public bool done=false;
   public string SenderImage;
   public string ReceiverImage;
}

public static class ChatBar
    {
        static UPanel chat = new UPanel(new Vector2(50,50),new Vector2(880,180));
        static UImage Image = new UImage("Src/Images/Players/Homem Negro/Face.png",new Vector2(85,45),new Vector2(120,120));
        static UText Text = new UText("",new Vector2(37,60),new Vector2(500,170));
        static bool alreadyOpen;
        static bool exit = false;
        static bool next = false;
     
        public static void Init()
        {
        chat.SetBackGround("Src/Images/Menu/Chat.png");
        chat.addChild(Image);
        chat.addChild(Text);
        Text.horizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
        Text.textAlignment = Windows.UI.Xaml.TextAlignment.Left;
        Text.verticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
        Text.fontSize = 18;
        Text.SetColor(Colors.Gold);
        }

        private static void weakup() {

            exit = true;
            AmbienteJogo.RegistrarEventoCallBack(PrioridadeEvento.Interface, UpdateTeclado);
            AmbienteJogo.window.Add(chat);
            chat.position.y = 108;
            chat.size.x = AmbienteJogo.window.Widht;
            Anim();
            alreadyOpen = true;
            exit = false;
        }
        public static void ShowChat(string image,string txt)
        {
            if (alreadyOpen) return;
            weakup();
            Image.Content = image;
            Text.content = txt;
            
       
        }

        public static async void ShowChat(Chat c)
        {
        if (alreadyOpen) return;
        weakup();

        foreach (var m in c.messages)
        {
            next = false;
            if (exit) return;
            if (m.who == Chat.who.receiver) Image.Content = c.ReceiverImage;
            else Image.Content = c.SenderImage;          
            Text.content = m.message;

             await Task.Run(() => { while (!next && !exit) ; }); 
        }
        c.done = true;
        HideChat();
      
        }

      
        public static bool UpdateTeclado(TecladoEvento e)
        {
            if(e.Tecla == (int)VirtualKey.Enter)
            {

            next = true;
            }
            if (e.Tecla == (int)VirtualKey.Escape)
            {
           
            HideChat();
            }
            return true;
        }

        async static Task Anim()
        {
        for (int i = 0; i < 17; i++)
        {
            chat.position.y -=1.0f;
            await Task.Delay(10);
        }
       
        }

        public static void HideChat()
        {
        exit = true;
        AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, UpdateTeclado);
        alreadyOpen = false;
        Text.content = "";
        AmbienteJogo.window.Remove(chat);
        }
      

    }

