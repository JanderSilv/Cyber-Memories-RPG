using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.UI;
using Windows.System;
using Windows.UI;

public class LapBird : Game
    {
        UImage Lapa;
        UImage[] obstaculos;
    UImage pontos;
        float impulso;
        float queda = 1f;
        UText msg,score;
    float pontuacao = 0;
        Random rdm = new Random();
    bool perdeu=false;
        public LapBird(UPanel scr) : base(scr)
        {
        pontos = new UImage("Src/Images/Games/Lap Bird/bigbig.png", new Vector2(5, 5), new Vector2(40, 40));
            Lapa = new UImage("Src/Images/Games/Lap Bird/Lapa_Bird.png", new Vector2(50, 50), new Vector2(25, 25));
        score = new UText("0", new Vector2(10, 5), new Vector2(60, 30));
        score.fontSize = 24;
        score.SetColor(Colors.Green);
            obstaculos = new UImage[10];
        msg = new UText("", new Vector2(50, 50), new Vector2(300, 200));
        msg.fontSize = 50;
        msg.horizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
        msg.textAlignment = Windows.UI.Xaml.TextAlignment.Center;
        msg.zIndex = -1;
        msg.SetColor(Colors.Red);
       
        for(int i = 0; i < 10; i++)
        {
           
            obstaculos[i] = new UImage("Src/Images/Games/Lap Bird/js.png", new Vector2(i*110,155+ 45*rdm.Next(-3,3)), new Vector2(20, 60));
            obstaculos[i].anchor = AnchorType.Exact;

        }
        }

        public override void Render()
        {
        screen.Content(Colors.LightSkyBlue);
            screen.addChild(Lapa);
            for (int i = 0; i < 10; i++)
            {
            screen.addChild(obstaculos[i]);
            }
        screen.addChild(msg);
        screen.addChild(pontos);
        screen.addChild(score);
    }

        public override void Close()
        {
            screen.removeChild(Lapa);
        for (int i = 0; i < 10; i++)
        {
            screen.removeChild(obstaculos[i]);
        }
        screen.removeChild(msg);
        screen.removeChild(pontos);
        screen.removeChild(score);
    }

        public override void Start()
        {
       
        }
        public override void UpdateGame()
        {

           
            if((Lapa.position.y>5 && Lapa.position.y < 90) && perdeu == false)
            {
            pontuacao += 0.02f;
            score.content = ((int)pontuacao).ToString();
            float lx =(float)screen.transform.X+ 2 * (((Lapa.position.x / 2.0f) / 100.0f) * screen.size.x) - 12.5f;
            float ly = (float)screen.transform.Y + 2 * (((Lapa.position.y / 2.0f) / 100.0f) * screen.size.y) - 12.5f;

           

            rdm = new Random();
                for (int i = 0; i < 10; i++)
                {
                    obstaculos[i].position.x -= 3.5f;
                    if (obstaculos[i].position.x < Lapa.position.x - 45)
                    {
                        obstaculos[i].position.x = obstaculos[i > 0 ? i - 1 : 9].position.x + 110;
                        obstaculos[i].position.y = 155 + 45 * rdm.Next(-3, 3);
                    }
                    if (obstaculos[i].position.x > Lapa.position.x + 500)
                    {
                        obstaculos[i].Content = "";
                    }
                    else
                    {
                        obstaculos[i].Content = "Src/Images/Games/Lap Bird/js.png";
                    }
                float d = Engine.Distance(new Vector2((float)obstaculos[i].transform.X,(float)obstaculos[i].transform.Y), new Vector2((float)Lapa.transform.X, (float)Lapa.transform.Y));
                    if (d < 25)
                    {
                    perdeu = true;
                    }
              

            }
            if (impulso > 0)
                {
                    Lapa.position.y -= 1f;
                    impulso -= 1f;
                }
                else
                {
                    Lapa.position.y += 0.5f * (queda * queda);
                }
                queda += 0.025f;
            
        }
        else
        {
            msg.content = "PERDEU";
        }

          
        }
        public override void KeyBoardUpdate()
        {
            if (teclado.TeclaPressionada(VirtualKey.Space))
            {
            if (impulso <= 0) { impulso = 20;queda = 1; }
            }
        }   
}
