using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using RPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class PlayerBatt : Entidade
{
    public Render render;
    public Animacao anim;
    public Inventario inv;
    public InventarioPopUpPlayer inventoryUI;
    public Combate stat;
    public bool atacou;
    public PlayerBatt()
    {

    }
    public void Init()
    {
        render = GetComponente<Render>();
        anim = GetComponente<Animacao>();
        inv = GetComponente<Inventario>();
        stat = GetComponente<Combate>();
    }
}

public class EnemyBatt : Entidade
{
    public Render render;
    public Combate stat;
    public bool atacou;
    public EnemyBatt()
    {
        render = AddComponente<Render>();
        stat = AddComponente<Combate>();
        stat.saude = 320;
        stat.saudeMax = 320;
        stat.resistencia = 5;
        stat.destreza = 2;
        stat.forca = 5;
        render.LoadImage("Src/Images/Games/Combat/Monsters/Slime.png");
    }
  

}

public class Batlle : Entidade
{
    public Func battle;
    public override void Update()
    {
        battle?.Invoke();
    }
}
public class GameWin : Window
{

    public int turno;
    public bool turnoCompleto;

    public Player player;
    public UPanel battleFooter, statusPlayer, statusEnemy, lifePlayer, lifeEnemy;
    public UImage playerImage;
    UText playerLP, enemyLP, combatLog;

    PlayerBatt playerBatt;
    EnemyBatt enemyBatt;
    UButton Attack, Run, Habilidade, Inventario;
    private bool inventoryOpen;
    Batlle batlle;
    bool battleEnd;
    bool PlayerAtaque;
    bool PlayerAtaqueEspel;
    public GameWin(Page root) : base(root)
    {
        #region UI

        battleFooter = new UPanel(new Vector2(50, 90), new Vector2(825, 120));
        battleFooter.SetBackGround("Src/Images/Games/Combat/combat.png");
        Add(battleFooter);

        Attack = new UButton("", new Vector2(11, 90), new Vector2(150, 60), battleAttack);
        Attack.setBackground("Src/Images/Games/Combat/UI/Atacar.png", Stretch.Fill);
        Add(Attack);

        Habilidade = new UButton("", new Vector2(31, 90), new Vector2(150, 60), battleHabilidade);
        Habilidade.setBackground("Src/Images/Games/Combat/UI/Habilidade.png", Stretch.Fill);
        Add(Habilidade);

        Inventario = new UButton("", new Vector2(51, 90), new Vector2(150, 60), battleInventario);
        Inventario.setBackground("Src/Images/Games/Combat/UI/Inventario.png", Stretch.Fill);
        Add(Inventario);

        Run = new UButton("", new Vector2(71, 90), new Vector2(150, 60), battleRun);
        Run.setBackground("Src/Images/Games/Combat/UI/Correr.png", Stretch.Fill);
        Add(Run);

        enemyBatt = new EnemyBatt();
        enemyBatt.EntPos = new Vector2(60, Height / 4);
        Add(enemyBatt);

        statusPlayer = new UPanel(new Vector2(90, 10), new Vector2(150, 40));
        statusPlayer.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        lifePlayer = new UPanel(new Vector2(90, 10.5f), new Vector2(130, 5));
        lifePlayer.Content(0, 255, 127, 255);
        playerLP = new UText("", new Vector2(90, 10.5f));
        playerLP.fontSize = 10;
        Add(statusPlayer);
        Add(lifePlayer);
        Add(playerLP);

        statusEnemy = new UPanel(new Vector2(10, 10), new Vector2(150, 40));
        statusEnemy.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        lifeEnemy = new UPanel(new Vector2(10, 10.5f), new Vector2(130, 5));
        lifeEnemy.Content(255, 127, 127, 255);
        enemyLP = new UText("", new Vector2(10, 10.5f));
        enemyLP.fontSize = 10;
        Add(statusEnemy);
        Add(lifeEnemy);
        Add(enemyLP);

        combatLog = new UText("", new Vector2(50,10), new Vector2(200, 60));
        combatLog.fontSize = 22;
        combatLog.horizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
        combatLog.textAlignment = Windows.UI.Xaml.TextAlignment.Center;
        combatLog.SetColor(Colors.DarkRed);
        Add(combatLog);

        #endregion
        turno = new Random().Next(6) % 2;
        enemyBatt.stat.arma = new ArcoMadeira();
    }

    private void Update()
    {
        if (!battleEnd)
        {
            if (playerBatt.stat.saude <= 0)
            {
                playerBatt.stat.saude = 0;
            }
            if (enemyBatt.stat.saude <= 0)
            {
                enemyBatt.stat.saude = 0;
            }

            lifePlayer.Resize(130 * ((float)playerBatt.stat.saude / (float)playerBatt.stat.saudeMax), lifePlayer.size.y);
            lifeEnemy.Resize(130 * ((float)enemyBatt.stat.saude / (float)enemyBatt.stat.saudeMax), lifeEnemy.size.y);

            playerLP.content = (playerBatt.stat.saude).ToString();
            enemyLP.content = (enemyBatt.stat.saude).ToString();

            turno %= 2;
            if (turno == 1)
            {
               
                if (enemyBatt.EntPos.x < 610 && enemyBatt.atacou == false)
                {
                    combatLog.content = "Turno Oponente";
                    enemyBatt.EntPos.x += 6;
                }
                if (enemyBatt.EntPos.x >= 610 && enemyBatt.atacou == false)
                {
                    int pv = playerBatt.stat.saude;
                    enemyBatt.stat.Ataque(playerBatt.stat);
                    enemyBatt.atacou = true;
                    if (pv == playerBatt.stat.saude) combatLog.content = "Errou!";
                }
                if (enemyBatt.atacou && enemyBatt.EntPos.x > 60)
                {
                    enemyBatt.EntPos.x -= 6;
                }
                if (enemyBatt.atacou && enemyBatt.EntPos.x <= 60)
                {
                    enemyBatt.atacou = false;
                    turnoCompleto = true;
                    Engine.Print("Enemy: " + enemyBatt.stat.saude + "\nPlayer: " + playerBatt.stat.saude);
                }
            }
            else
            {
              
                if (PlayerAtaque)
                {
                    if (playerBatt.EntPos.x > 80 && playerBatt.atacou == false)
                    {
                        combatLog.content = "Seu Turno";
                        playerBatt.EntPos.x -= 6;
                        playerBatt.anim.Play("Move_Left");
                    }
                    if (playerBatt.EntPos.x <= 80 && playerBatt.atacou == false)
                    {
                        int ev =enemyBatt.stat.saude;
                        playerBatt.atacou = true;
                        if (PlayerAtaqueEspel) playerBatt.stat.AtaqueEspel(enemyBatt.stat);
                        else playerBatt.stat.Ataque(enemyBatt.stat);
                       
                        if(ev == enemyBatt.stat.saude) combatLog.content = "Errou!";
                    }
                    if (playerBatt.atacou && playerBatt.EntPos.x < 640)
                    {
                        playerBatt.EntPos.x += 6;
                        playerBatt.anim.Play("Move_Right");
                    }
                    if (playerBatt.atacou && playerBatt.EntPos.x >= 640)
                    {
                        playerBatt.atacou = false;
                        turnoCompleto = true;
                        PlayerAtaque = false;
                        PlayerAtaqueEspel = false;
                        playerBatt.anim.Play("Stop_Left");
                    }
                }
            }



            if (turnoCompleto)
            {
                if (playerBatt.stat.saude <= 0)
                {
                    playerBatt.stat.saude = 0;
                    combatLog.content = "Inimigo Ganhou";
                    battleEnd = true;
                    return;
                }
                if (enemyBatt.stat.saude <= 0)
                {
                    enemyBatt.stat.saude = 0;
                    combatLog.content = "Player Ganhou";
                    battleEnd = true;
                    return;

                }
                turno++;
                turnoCompleto = false;
            }

        }
        else
        {
            if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.Escape))
            {
                MainPage.lab.SetCurrent();
            }
        }
       
       

    }

    private void battleRun(object sender)
    {
        if (turno == 0)
        {
            if (new Random().Next(0, 100) < 10 + playerBatt.stat.sorte + playerBatt.stat.destreza)
            {
                MainPage.lab.SetCurrent();
            }
            turnoCompleto = true;
        }
    }

    private void battleInventario(object sender)
    {
        if(turno == 0)
        {
            if (inventoryOpen)
            {
                playerBatt.inventoryUI.HideInventory();
                inventoryOpen = false;
                
            }
            else
            {
                playerBatt.inventoryUI.ShowInventory();
                inventoryOpen = true;
            }
        }
      
    }

    private void battleHabilidade(object sender)
    {
        if (turno == 0)
        {
          
            PlayerAtaque = true;
            PlayerAtaqueEspel = true;
        }
    }

    private void battleAttack(object sender)
    {
        if(turno == 0)
        {
           
            PlayerAtaque = true;
        }
        
    }

    public override void OnActive()
    {
        playerBatt = new PlayerBatt();
        playerBatt.EntPos = new Vector2(Widht / 1.25f, Height / 4 +20);

        playerBatt.AddComponente(player.render);
        playerBatt.AddComponente(player.anim);
        playerBatt.AddComponente(player.inv);
        playerBatt.inventoryUI = player.inventoryUI;
        playerBatt.AddComponente(player.stat);
        playerBatt.Init();
        Add(playerBatt);

        playerImage = new UImage("Src/Images/Players/" + player.skin + "/Face.png", new Vector2(90, 90), new Vector2(85, 85));
        Add(playerImage);
        SetBackground("Src/Images/Games/Combat/BattleScenes/Grassland.png");
       
        batlle = new Batlle();
        batlle.battle = Update;
        Add(batlle);
        playerBatt.anim.Play("Stop_Left");
    }

}

