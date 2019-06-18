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



    enum StateMachine
    {
        Desktop, Combate, Joli, Lap,None
    }

   
    StateMachine state = StateMachine.Desktop;
    UPanel screen;
    Input teclado;
    UButton cyberMem, joliMan, lapBird;
    
    Game currentGame;
    Combate combate;

    public ScreenPC()
    {
        screen = new UPanel(new Vector2(50, 50), new Vector2(600, 350));
        screen.anchor = AnchorType.Proporcional;
        screen.manipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
        screen.zIndex = 1000;
        teclado = new Input();

        cyberMem = new UButton("", new Vector2(10, 10), new Vector2(30, 30), combatGame);
        joliMan = new UButton("", new Vector2(10, 20), new Vector2(30, 30), JoliGame);
        lapBird = new UButton("", new Vector2(10, 30), new Vector2(30, 30), LapGame);

        cyberMem.setBackground("Src/Images/Windows_XP/Jogos XP/Cyber Memories.png", Stretch.Uniform);
        joliMan.setBackground(" Src/Images/Windows_XP/Jogos XP/Joli Man.png", Stretch.Uniform);
        lapBird.setBackground(" Src/Images/Windows_XP/Jogos XP/Lap_Bird_icon.png", Stretch.Uniform);

        cyberMem.setOnHover("Src/Images/Windows_XP/Jogos XP/Cyber Memories Clicado.png");
        joliMan.setOnHover("Src/Images/Windows_XP/Jogos XP/Joli Man Clicado.png");
        lapBird.setOnHover("Src/Images/Windows_XP/Jogos XP/Lap_Bird_Clicado.png");

        RenderDesktop();

        
    }

    internal void Update()
    {
        if(state!= StateMachine.Desktop)
        {
            currentGame?.UpdateGame();
        }
        
    }

    private void combatGame(object sender)
    {
        state = StateMachine.Combate;
        currentGame = new Combate(screen);
        currentGame.Start();
        
        Render();
    }

    private void LapGame(object sender)
    {
        state = StateMachine.Lap;
        currentGame = new LapBird(screen);
        currentGame.teclado = teclado;
        currentGame.Start();
        Render();
    }

    private void JoliGame(object sender)
    {
        state = StateMachine.Joli;
        currentGame = null;
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
        currentGame?.KeyBoardUpdate();
        if (teclado.TeclaPressionada(VirtualKey.Escape))
        {
            
                state = StateMachine.Desktop;
                Render();
           
        }
        if (teclado.TeclaPressionada(VirtualKey.P))
        {
           
            Hide();
        }
        return true;
    }

    public void Hide()
    {
        Clear();
        AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, PcKeyword);
        AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, PcMouse);
        AmbienteJogo.window.Remove(screen);
        state = StateMachine.None;
    }

    public void Render()
    {
        Clear();
        Canvas.SetZIndex(screen.element, 1000);

        if (state == StateMachine.Desktop)
        {    
            RenderDesktop();
        }
        else
        {
            currentGame?.Render();
        }

        AmbienteJogo.window.Add(screen);
    }

    public void RenderDesktop()
    {
        screen.SetBackGround("Src/Images/Windows_XP/Windows XP.png");
        cyberMem.anchor = AnchorType.Proporcional;
        joliMan.anchor = AnchorType.Proporcional;
        lapBird.anchor = AnchorType.Proporcional;

        cyberMem.position = new Vector2(5, 10);
        joliMan.position = new Vector2(5, 20);
        lapBird.position = new Vector2(5, 30);

        screen.addChild(cyberMem);
        //screen.addChild(joliMan);
        screen.addChild(lapBird);
    }

    public void Clear()
    {
        currentGame?.Close();
        screen.removeChild(cyberMem);
        screen.removeChild(joliMan);
        screen.removeChild(lapBird);
    }

}

