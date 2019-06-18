using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using _3ReaisEngine.UI;
using Windows.UI;
using Windows.UI.Xaml.Media;

public class Combate : Game
{
    UPanel battleFooter, statusPlayer, statusEnemy, lifePlayer, lifeEnemy;
    UButton Attack, Run, Habilidade, Inventario;
    UImage battlePlayer, battleEnemy, effectEnemy, effectPlayer, playerImage;
    UText playerLP, enemyLP, combatLog;
    bool battleEnd = false;
    bool PlayerMove = false;
    bool PllayerAttack = false;
    int turno;
    float lastpf, playerLife = 120, playerFullLife = 120, lastef, enemyLife = 135, enemyFullLife = 135, danoPhase = 0;
    string Message;

    public Combate(UPanel scr) : base(scr)
    {
        const int cx = 270, cy = 175;
        battleFooter = new UPanel(new Vector2(30+cx, 130+cy), new Vector2(585, 80));
        battleFooter.SetBackGround("Src/Images/Games/Combat/combat.png");
        battleFooter.anchor = AnchorType.Exact;

        playerImage = new UImage("Src/Images/Players/"+Player.currentPlayer.skin+"/Face.png", new Vector2(278+cx, 130+cy), new Vector2(65, 65));
        playerImage.anchor = AnchorType.Exact;

        battleEnemy = new UImage("Src/Images/Games/Combat/Monsters/Slime.png", new Vector2(-200+cx, -5+cy), new Vector2(80, 120));
        battleEnemy.anchor = AnchorType.Exact;

        battlePlayer = new UImage("Src/Images/Games/Combat/Monsters/Slime.png", new Vector2(200+cx, -5+cy), new Vector2(80, 120));
        battlePlayer.anchor = AnchorType.Exact;

        effectEnemy = new UImage("Src/Images/Games/Combat/Animacoes/Pancada/Pancada.gif", new Vector2(-200+cx, -20+cy), new Vector2(80, 80));
        effectEnemy.anchor = AnchorType.Exact;

        effectPlayer = new UImage("Src/Images/Games/Combat/Animacoes/Pancada/Pancada.gif", new Vector2(200+cx, -20+cy), new Vector2(80, 80));
        effectPlayer.anchor = AnchorType.Exact;

        Attack = new UButton("", new Vector2(-190+cx, 135+cy), new Vector2(90, 40), battleAttack);
        Attack.setBackground("Src/Images/Games/Combat/UI/Atacar.png", Stretch.Fill);
        Attack.anchor = AnchorType.Exact;

        Habilidade = new UButton("", new Vector2(-85+cx, 135+cy), new Vector2(90, 40), battleHabilidade);
        Habilidade.setBackground("Src/Images/Games/Combat/UI/Habilidade.png", Stretch.Fill);
        Habilidade.anchor = AnchorType.Exact;

        Inventario = new UButton("", new Vector2(20+cx, 135+cy), new Vector2(90, 40), battleInventario);
        Inventario.setBackground("Src/Images/Games/Combat/UI/Inventario.png", Stretch.Fill);
        Inventario.anchor = AnchorType.Exact;

        Run = new UButton("", new Vector2(130+cx, 135+cy), new Vector2(90, 40), battleRun);
        Run.setBackground("Src/Images/Games/Combat/UI/Correr.png", Stretch.Fill);
        Run.anchor = AnchorType.Exact;

        statusPlayer = new UPanel(new Vector2(230+cx, -132+cy), new Vector2(150, 40));
        statusPlayer.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        statusPlayer.anchor = AnchorType.Exact;
        lifePlayer = new UPanel(new Vector2(230+cx, -142+cy), new Vector2(130, 5));
        lifePlayer.anchor = AnchorType.Exact;
        lifePlayer.Content(0, 255, 127, 255);
        playerLP = new UText(playerLife.ToString(), new Vector2(285+cx, -116+cy));
        playerLP.anchor = AnchorType.Exact;
        playerLP.fontSize = 10;

        statusEnemy = new UPanel(new Vector2(-170+cx, -132+cy), new Vector2(150, 40));
        statusEnemy.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        statusEnemy.anchor = AnchorType.Exact;
        lifeEnemy = new UPanel(new Vector2(-170+cx, -142+cy), new Vector2(130, 5));
        lifeEnemy.anchor = AnchorType.Exact;
        lifeEnemy.Content(255, 127, 127, 255);
        enemyLP = new UText(enemyLife.ToString(), new Vector2(-115+cx, -116+cy));
        enemyLP.anchor = AnchorType.Exact;
        enemyLP.fontSize = 10;

        combatLog = new UText("", new Vector2(25+cx, -132+cy), new Vector2(150, 40));
        combatLog.anchor = AnchorType.Exact;
        combatLog.fontSize = 22;
        combatLog.horizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
        combatLog.textAlignment = Windows.UI.Xaml.TextAlignment.Center;
        combatLog.SetColor(Colors.DarkRed);

    }

    public override void Render()
    {
        playerImage.Content = "Src/Images/Players/" + Player.currentPlayer.skin + "/Face.png";
        screen.SetBackGround("Src/Images/Games/Combat/BattleScenes/Grassland.png");
        screen.addChild(battleFooter);
        screen.addChild(playerImage);
        screen.addChild(Attack);
        screen.addChild(Habilidade);
        screen.addChild(Inventario);
        screen.addChild(Run);
        screen.addChild(battleEnemy);
        screen.addChild(battlePlayer);
        screen.addChild(effectEnemy);
        screen.addChild(effectPlayer);
        screen.addChild(statusEnemy);
        screen.addChild(statusPlayer);
        screen.addChild(lifePlayer);
        screen.addChild(lifeEnemy);
        screen.addChild(playerLP);
        screen.addChild(enemyLP);
        screen.addChild(combatLog);
        effectEnemy.zIndex = -1;
        effectPlayer.zIndex = -1;
    }

    public override void Start()
    {
        run = true;
       

        lastpf = playerLife;
        lastef = enemyLife;

        
        Random rdm = new Random();
        playerLife = 120; playerFullLife = playerLife;
        enemyLife = 130; enemyFullLife = enemyLife;
        battlePlayer.position = new Vector2( 470, 170);
        battleEnemy.position = new Vector2(70, 170);

        Task.Run(async () =>
        {
          
            turno = rdm.Next(6) % 2;
            while (run)
            {
                if (!battleEnd)
                {
                    if (turno == 1)
                    {
                        if (battleEnd) return;
                        Message = "Inimigo Ataca!";
                        PllayerAttack = false;
                        await Task.Delay(1500);
                        await AnimAtaqueFisico(battleEnemy, effectPlayer, -3.5f);
                        if (battleEnd) return;
                        turno = 0;
                        playerLife -= 15 + (rdm.Next(0, 5) * 5);
                    }
                    else
                    {
                        Message = "Sua Vez!";
                        if (PllayerAttack)
                        {

                            await AnimAtaqueFisico(battlePlayer, effectEnemy);
                            turno = 1;
                            PllayerAttack = false;
                            if (battleEnd) return;
                            enemyLife -= danoPhase;
                            
                        }

                    }
                }
                else return;
                
            }
        });
    }

    public override void Close()
    {
        screen.removeChild(battleFooter);
        screen.removeChild(playerImage);
        screen.removeChild(Attack);
        screen.removeChild(Habilidade);
        screen.removeChild(Inventario);
        screen.removeChild(Run);
        screen.removeChild(battleEnemy);
        screen.removeChild(battlePlayer);
        screen.removeChild(effectEnemy);
        screen.removeChild(effectPlayer);
        screen.removeChild(statusEnemy);
        screen.removeChild(statusPlayer);
        screen.removeChild(lifePlayer);
        screen.removeChild(lifeEnemy);
        screen.removeChild(playerLP);
        screen.removeChild(enemyLP);
        screen.removeChild(combatLog);
    }

    void wait(float s)
    {
        w(s);
    }
    async void w(float s)
    {
        await Task.Delay((int)(s * 1000));
    }

    public override void UpdateGame()
    {
        if (playerLife <= 0)
        {
            playerLife = 0;
            combatLog.fontSize = 20;
            Message = "Slime Venceu!";
            battleEnd = true;
        }
        if (enemyLife < 0)
        {
            enemyLife = 0;
            combatLog.fontSize = 20;
            Message = "Jogador Venceu!";
            battleEnemy.Content = "Src/Images/Games/Combat/Monsters/Morto.png";
            battleEnd = true;
        }

        combatLog.content = Message;
        enemyLP.content = enemyLife.ToString();
        playerLP.content = playerLife.ToString();
        lifePlayer.Resize(130 * (playerLife / playerFullLife), lifePlayer.size.y);
        lifeEnemy.Resize(130 * (enemyLife / enemyFullLife), lifeEnemy.size.y);
        if (lastpf != playerLife)
        {
            float dx = (130 * (lastpf - playerLife)) / playerFullLife;
            lifePlayer.position.x += dx / 2;
        }
        if (lastef != enemyLife)
        {
            float dx = (130 * (lastef - enemyLife)) / enemyFullLife;
            lifeEnemy.position.x += dx / 2;
        }

        lastpf = playerLife;
        lastef = enemyLife;
    }

    async Task AnimAtaqueFisico(UImage ent, UImage effect, float vel = 3.5f, float dist = 380.5f)
    {
        PlayerMove = true;
        PllayerAttack = false;
        await Task.Run(async () =>
        {
            float relVel = Math.Abs(vel);
            for (float i = 0; i <= dist; i += relVel)
            {
                if (battleEnd) return;
                ent.position.x -= (vel);
                PlayerMove = true;
                await Task.Delay(10);
            }
            if (battleEnd) return;
            effect.zIndex = 1010;          
            await Task.Delay(400);
            if (battleEnd) return;
            effect.zIndex = -1;

            for (float i = 0; i <= dist; i += relVel)
            {
                ent.position.x += vel;
                PlayerMove = true;
                if (battleEnd) return;
                await Task.Delay(10);
            }
            PlayerMove = false;

        });
    }

    private void battleRun(object sender)
    {

    }

    private void battleInventario(object sender)
    {

    }

    private void battleHabilidade(object sender)
    {
        if (PlayerMove) return;
        effectEnemy.Content = "Src/Images/Games/Combat/Animacoes/CorteFogo/CorteFogo.gif";
        danoPhase = 35;
        PllayerAttack = true;
    }

    private void battleAttack(object sender)
    {
        if (PlayerMove) return;
        effectEnemy.Content = "Src/Images/Games/Combat/Animacoes/Pancada/Pancada.gif";
        danoPhase = 20;
        PllayerAttack = true;

    }

}

