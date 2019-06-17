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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class ScreenPC
{

    //REDUZA A FONTE PARA LER



    //            _____                   _______                   _____                    _____                            _____                   _______                           _____                   _______                   _____          
    //           /\    \                 /::\    \                 /\    \                  /\    \                          /\    \                 /::\    \                         /\    \                 /::\    \                 /\    \         
    //          /::\____\               /::::\    \               /::\    \                /::\    \                        /::\    \               /::::\    \                       /::\    \               /::::\    \               /::\    \        
    //         /:::/    /              /::::::\    \             /::::\    \              /::::\    \                      /::::\    \             /::::::\    \                     /::::\    \             /::::::\    \             /::::\    \       
    //        /:::/    /              /::::::::\    \           /::::::\    \            /::::::\    \                    /::::::\    \           /::::::::\    \                   /::::::\    \           /::::::::\    \           /::::::\    \      
    //       /:::/    /              /:::/~~\:::\    \         /:::/\:::\    \          /:::/\:::\    \                  /:::/\:::\    \         /:::/~~\:::\    \                 /:::/\:::\    \         /:::/~~\:::\    \         /:::/\:::\    \     
    //      /:::/____/              /:::/    \:::\    \       /:::/__\:::\    \        /:::/__\:::\    \                /:::/  \:::\    \       /:::/    \:::\    \               /:::/__\:::\    \       /:::/    \:::\    \       /:::/  \:::\    \    
    //     /::::\    \             /:::/    / \:::\    \     /::::\   \:::\    \      /::::\   \:::\    \              /:::/    \:::\    \     /:::/    / \:::\    \             /::::\   \:::\    \     /:::/    / \:::\    \     /:::/    \:::\    \   
    //    /::::::\    \   _____   /:::/____/   \:::\____\   /::::::\   \:::\    \    /::::::\   \:::\    \            /:::/    / \:::\    \   /:::/____/   \:::\____\           /::::::\   \:::\    \   /:::/____/   \:::\____\   /:::/    / \:::\    \  
    //   /:::/\:::\    \ /\    \ |:::|    |     |:::|    | /:::/\:::\   \:::\____\  /:::/\:::\   \:::\    \          /:::/    /   \:::\ ___\ |:::|    |     |:::|    |         /:::/\:::\   \:::\____\ |:::|    |     |:::|    | /:::/    /   \:::\ ___\ 
    //  /:::/  \:::\    /::\____\|:::|____|     |:::|    |/:::/  \:::\   \:::|    |/:::/  \:::\   \:::\____\        /:::/____/     \:::|    ||:::|____|     |:::|    |        /:::/  \:::\   \:::|    ||:::|____|     |:::|    |/:::/____/  ___\:::|    |
    //  \::/    \:::\  /:::/    / \:::\    \   /:::/    / \::/   |::::\  /:::|____|\::/    \:::\  /:::/    /        \:::\    \     /:::|____| \:::\    \   /:::/    /         \::/    \:::\  /:::|____| \:::\    \   /:::/    / \:::\    \ /\  /:::|____|
    //   \/____/ \:::\/:::/    /   \:::\    \ /:::/    /   \/____|:::::\/:::/    /  \/____/ \:::\/:::/    /          \:::\    \   /:::/    /   \:::\    \ /:::/    /           \/_____/\:::\/:::/    /   \:::\    \ /:::/    /   \:::\    /::\ \::/    / 
    //            \::::::/    /     \:::\    /:::/    /          |:::::::::/    /            \::::::/    /            \:::\    \ /:::/    /     \:::\    /:::/    /                     \::::::/    /     \:::\    /:::/    /     \:::\   \:::\ \/____/  
    //             \::::/    /       \:::\__/:::/    /           |::|\::::/    /              \::::/    /              \:::\    /:::/    /       \:::\__/:::/    /                       \::::/    /       \:::\__/:::/    /       \:::\   \:::\____\    
    //             /:::/    /         \::::::::/    /            |::| \::/____/               /:::/    /                \:::\  /:::/    /         \::::::::/    /                         \::/____/         \::::::::/    /         \:::\  /:::/    /    
    //            /:::/    /           \::::::/    /             |::|  ~|                    /:::/    /                  \:::\/:::/    /           \::::::/    /                           ~~                \::::::/    /           \:::\/:::/    /     
    //           /:::/    /             \::::/    /              |::|   |                   /:::/    /                    \::::::/    /             \::::/    /                                               \::::/    /             \::::::/    /      
    //          /:::/    /               \::/____/               \::|   |                  /:::/    /                      \::::/    /               \::/____/                                                 \::/____/               \::::/    /       
    //          \::/    /                 ~~                      \:|   |                  \::/    /                        \::/____/                 ~~                                                        ~~                      \::/____/        
    //           \/____/                                           \|___|                   \/____/                          ~~                                                                                                                          
    //                                                                                                                                                                                                                                                   




    #region PC
    enum StateMachine
    {
        Desktop, Combate, Joli, Lap
    }
    StateMachine state = StateMachine.Desktop;
    UPanel screen;
    Input teclado;
    UButton cyberMem, joliMan, lapBird;
    bool interrupt = false;
    #endregion

    #region Combate
    UPanel battleFooter, statusPlayer, statusEnemy,lifePlayer,lifeEnemy;
    UButton Attack, Run, Habilidade, Inventario;
    UImage battlePlayer, battleEnemy, effectEnemy, effectPlayer, playerImage;
    UText playerLP, enemyLP,combatLog;
    bool PlayerMove = false;
    bool PllayerAttack = false;
    int turno;
    float lastpf,playerLife = 120,playerFullLife= 120,lastef, enemyLife = 135,enemyFullLife = 135,danoPhase=0;
    string Message;
    #endregion


    public ScreenPC()
    {
        screen = new UPanel(new Vector2(50, 50), new Vector2(600, 350));
        screen.anchor = AnchorType.Proporcional;
        screen.manipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
        screen.zIndex = 1000;
        teclado = new Input();

        #region Desktop
        cyberMem = new UButton("", new Vector2(-250, -150), new Vector2(30, 30), combatGame);
        joliMan = new UButton("", new Vector2(-250, -110), new Vector2(30, 30), JoliGame);
        lapBird = new UButton("", new Vector2(-250, -70), new Vector2(30, 30), LapGame);

        cyberMem.setBackground("Src/Images/Windows_XP/Jogos XP/Cyber Memories.png", Stretch.Uniform);
        joliMan.setBackground(" Src/Images/Windows_XP/Jogos XP/Joli Man.png", Stretch.Uniform);
        lapBird.setBackground(" Src/Images/Windows_XP/Jogos XP/Lap_Bird_icon.png", Stretch.Uniform);

        cyberMem.setOnHover("Src/Images/Windows_XP/Jogos XP/Cyber Memories Clicado.png");
        joliMan.setOnHover("Src/Images/Windows_XP/Jogos XP/Joli Man Clicado.png");
        lapBird.setOnHover("Src/Images/Windows_XP/Jogos XP/Lap_Bird_Clicado.png");

        cyberMem.anchor = AnchorType.Exact;
        joliMan.anchor = AnchorType.Exact;
        lapBird.anchor = AnchorType.Exact;
        #endregion

        #region Combate
        
        battleFooter = new UPanel(new Vector2(30, 130), new Vector2(585, 80));
        battleFooter.SetBackGround("Src/Images/Games/Combat/combat.png");
        battleFooter.anchor = AnchorType.Exact;

        playerImage = new UImage("Src/Images/Players/Homem Negro/Face.png", new Vector2(278, 130), new Vector2(65, 65));
        playerImage.anchor = AnchorType.Exact;

        battleEnemy = new UImage("Src/Images/Games/Combat/Monsters/Slime.png", new Vector2(-200, -5), new Vector2(80, 120));
        battleEnemy.anchor = AnchorType.Exact;

        battlePlayer = new UImage("Src/Images/Games/Combat/Monsters/Slime.png", new Vector2(200, -5), new Vector2(80, 120));
        battlePlayer.anchor = AnchorType.Exact;

        effectEnemy = new UImage("Src/Images/Games/Combat/Animacoes/Pancada/Pancada.gif", new Vector2(-200, -20), new Vector2(80, 80));
        effectEnemy.anchor = AnchorType.Exact;

        effectPlayer = new UImage("Src/Images/Games/Combat/Animacoes/Pancada/Pancada.gif", new Vector2(200, -20), new Vector2(80, 80));
        effectPlayer.anchor = AnchorType.Exact;

        Attack = new UButton("", new Vector2(-190, 135), new Vector2(90, 40), battleAttack);
        Attack.setBackground("Src/Images/Games/Combat/UI/Atacar.png", Stretch.Fill);
        Attack.anchor = AnchorType.Exact;

        Habilidade = new UButton("", new Vector2(-85, 135), new Vector2(90, 40), battleHabilidade);
        Habilidade.setBackground("Src/Images/Games/Combat/UI/Habilidade.png", Stretch.Fill);
        Habilidade.anchor = AnchorType.Exact;

        Inventario = new UButton("", new Vector2(20, 135), new Vector2(90, 40), battleInventario);
        Inventario.setBackground("Src/Images/Games/Combat/UI/Inventario.png", Stretch.Fill);
        Inventario.anchor = AnchorType.Exact;

        Run = new UButton("", new Vector2(130, 135), new Vector2(90, 40), battleRun);
        Run.setBackground("Src/Images/Games/Combat/UI/Correr.png", Stretch.Fill);
        Run.anchor = AnchorType.Exact;

        statusPlayer = new UPanel(new Vector2(230, -132), new Vector2(150, 40));
        statusPlayer.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        statusPlayer.anchor = AnchorType.Exact;
        lifePlayer = new UPanel(new Vector2(230, -142), new Vector2(130, 5));
        lifePlayer.anchor = AnchorType.Exact;
        lifePlayer.Content(0, 255, 127, 255);
        playerLP = new UText(playerLife.ToString(), new Vector2(285, -116));
        playerLP.anchor = AnchorType.Exact;
        playerLP.fontSize = 10;

        statusEnemy = new UPanel(new Vector2(-170, -132), new Vector2(150, 40));
        statusEnemy.SetBackGround("Src/Images/Games/Combat/UI/CombatBox.png");
        statusEnemy.anchor = AnchorType.Exact;
        lifeEnemy = new UPanel(new Vector2(-170, -142), new Vector2(130, 5));
        lifeEnemy.anchor = AnchorType.Exact;
        lifeEnemy.Content(255, 127, 127, 255);
        enemyLP = new UText(enemyLife.ToString(), new Vector2(-115, -116));
        enemyLP.anchor = AnchorType.Exact;
        enemyLP.fontSize = 10;

        combatLog = new UText("", new Vector2(25, -132), new Vector2(150, 40));
        combatLog.anchor = AnchorType.Exact;
        combatLog.fontSize = 22;
        combatLog.horizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
        combatLog.textAlignment = Windows.UI.Xaml.TextAlignment.Center;
        combatLog.SetColor(Colors.DarkRed);
        lastpf = playerLife;
        lastef = enemyLife;
        #endregion
    }

    internal void Update()
    {
        if(state == StateMachine.Combate)
        {
            if (playerLife < 0) playerLife = 0;
            if (enemyLife < 0) enemyLife = 0;
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
       
    }


    #region Combate_Funcs
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

    async Task AnimAtaqueFisico(UImage ent, UImage effect, float vel = 3.5f, float dist = 380.5f)
    {
        PlayerMove = true;
        PllayerAttack = false;
        await Task.Run(async () =>
        {
            float relVel = Math.Abs(vel);
            for (float i = 0; i <= dist; i += relVel)
            {
                if (interrupt) return;
                ent.position.x -= (vel);
                PlayerMove = true;
                await Task.Delay(10);
            }

            effect.zIndex = 1010;
            if (interrupt) return;
            await Task.Delay(400);
            effect.zIndex = -1;

            for (float i = 0; i <= dist; i += relVel)
            {
                if (interrupt) return;
                ent.position.x += vel;
                PlayerMove = true;
                await Task.Delay(10);
            }
            PlayerMove = false;

        });
    }

    private void combatGame(object sender)
    {
        state = StateMachine.Combate;

        Render();
        Random rdm = new Random();
        playerLife = 120;playerFullLife = playerLife;
        enemyLife = 130;enemyFullLife = enemyLife;
        battlePlayer.position.x = 200;
        battleEnemy.position.y = -200;
        Task.Run(async () =>
        {
            if (interrupt) return;
            turno =rdm.Next(6) % 2;
            while (state == StateMachine.Combate)
            {
                if (turno == 1)
                {
                    Message = "Inimigo Ataca!";
                    PllayerAttack = false;
                    await Task.Delay(1500);
                    await AnimAtaqueFisico(battleEnemy, effectPlayer, -3.5f);
                    turno = 0;
                    playerLife -= 15+(rdm.Next(0,5)*5);
                }
                else
                {
                    Message = "Sua Vez!";
                    if (PllayerAttack)
                    {
                        await AnimAtaqueFisico(battlePlayer, effectEnemy);
                        turno = 1;
                        PllayerAttack = false;
                        enemyLife -= danoPhase;
                    }

                }
            }
        });
    }

    #endregion



    private void LapGame(object sender)
    {
        state = StateMachine.Lap;
        Render();
    }

    private void JoliGame(object sender)
    {
        state = StateMachine.Joli;
        Render();
    }

   

    public void Show()
    {
        state = StateMachine.Desktop;
        AmbienteJogo.RegistrarEventoCallBack(PrioridadeEvento.Interface, PcKeyword);
        AmbienteJogo.RegistrarEventoCallBack(PrioridadeEvento.Interface, PcMouse);
        Render();

    }

    private bool PcMouse(MouseEvento e)
    {
        teclado.UpdateMouse(e);

        return true;
    }

    private bool PcKeyword(TecladoEvento e)
    {
        teclado.UpdateTeclado(e);

        if (teclado.TeclaPressionada(VirtualKey.Escape))
        {
            if (state != StateMachine.Desktop)
            {
                interrupt = true;
                state = StateMachine.Desktop;
                Engine.Print("Desktop");
                Render();
            }

        }

        return true;
    }

    public void Hide()
    {
        Clear();
        AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, PcKeyword);
        AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, PcMouse);
        AmbienteJogo.window.Remove(screen);
        state = StateMachine.Desktop;
    }

    public void Render()
    {
        Clear();
        Canvas.SetZIndex(screen.element, 1000);
        if (state == StateMachine.Desktop)
        {
            interrupt = false;
            screen.SetBackGround("Src/Images/Windows_XP/Windows XP.png");
            cyberMem.position = new Vector2(-250, -155);
            joliMan.position = new Vector2(-250, -115);
            lapBird.position = new Vector2(-250, -75);
            screen.addChild(cyberMem);
            screen.addChild(joliMan);
            screen.addChild(lapBird);
            AmbienteJogo.window.Add(screen, false);
        }
        else
        {
            if (state == StateMachine.Combate)
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
            else if (state == StateMachine.Joli)
            {

            }
            else if (state == StateMachine.Lap)
            {

            }
        }

        AmbienteJogo.window.Add(screen, false);
    }

    public void Clear()
    {
        screen.removeChild(cyberMem);
        screen.removeChild(joliMan);
        screen.removeChild(lapBird);
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
        screen.removeChild(statusPlayer);
        screen.removeChild(statusEnemy);
        screen.removeChild(lifeEnemy);
        screen.removeChild(lifePlayer);
        screen.removeChild(playerLP);
        screen.removeChild(enemyLP);
        screen.removeChild(combatLog);
    }

}

