using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RPG.Src.Scripts.Telas
{
    public class GameWin : Window
    {
        public string PlayerImageFolder;
        Player player;
        public GameWin(Page root) : base(root)
        {
           
            
        }
        public override void OnActive()
        {
            player = new Player();
            player.EntPos = new Vector2(Widht / 2, Height / 2);
            player.anim.AddAnimation("Move_Left", "Src/Images/Players/" + PlayerImageFolder + "/Sprites/Lab_Esquerda.gif");
            player.anim.AddAnimation("Move_Right", "Src/Images/Players/" + PlayerImageFolder + "/Sprites/Lab_Direita.gif");
            player.anim.AddAnimation("Move_Down", "Src/Images/Players/" + PlayerImageFolder + "/Sprites/Lab_Frente.gif");
            player.anim.AddAnimation("Move_Up", "Src/Images/Players/" + PlayerImageFolder + "/Sprites/Lab_Fundo.gif");
            Add(player);
        }
       
    }
}
