using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player : Entidade
{
    public static Player currentPlayer;

    public Animacao anim;
    public Inventario inv;
    public QuestSystem quest;

    Body body;
    Render render;
    Colisao col;  
    Combate stat;
    public InventarioPopUpPlayer inventoryUI;


    public string skin = "Homem Negro";
    public bool Lab = true;

    bool inventoryOpen = false;


    public Player()
    {
        currentPlayer = this;
        anim = AddComponente<Animacao>();
        body = AddComponente<Body>();
        inv = AddComponente<Inventario>();
        quest = AddComponente<QuestSystem>();
        stat = AddComponente<Combate>();
        col = GetComponente<Colisao>();
        render = GetComponente<Render>();
        
        inventoryUI = new InventarioPopUpPlayer();
        quest.AddQuest(new FalarComNPC());
        col.tamanho.x = 50;
        col.tamanho.y = 20;
        col.tipo = TipoColisao.Dinamica;
        inv.Init();
        render.img.Width = 50;
        render.img.Height = 50;
        inv.Add(new CajadoMaderia());
        inv.Add(new EspadaAco());
        inv.Add(new ArcoMadeira());
        inv.Add(new AdagaAco());

        inventoryUI.inv = inv;
        LoadSkin(skin);

    }

    public void LoadSkin(string skinFolder)
    {
        skin = skinFolder;
        if (Lab)
        {
            anim.AddAnimation("Move_Left", "Src/Images/Players/" + skin + "/Lab/anim/Lab_Esquerda.gif");
            anim.AddAnimation("Move_Right", "Src/Images/Players/" + skin + "/Lab/anim/Lab_Direita.gif");
            anim.AddAnimation("Move_Down", "Src/Images/Players/" + skin + "/Lab/anim/Lab_Frente.gif");
            anim.AddAnimation("Move_Up", "Src/Images/Players/" + skin + "/Lab/anim/Lab_Fundo.gif");

            anim.AddAnimation("Stop_Left", "Src/Images/Players/" + skin + "/Lab/Esquerda_Parado.png");
            anim.AddAnimation("Stop_Right", "Src/Images/Players/" + skin + "/Lab/Direita_Parado.png");
            anim.AddAnimation("Stop_Up", "Src/Images/Players/" + skin + "/Lab/Fundo_Parado.png");
            anim.AddAnimation("Stop_Down", "Src/Images/Players/" + skin + "/Lab/Frente_Parado.png");
        }
        else
        {
            anim.AddAnimation("Move_Left", "Src/Images/Players/" + skin + "/anim/Esquerda.gif");
            anim.AddAnimation("Move_Right", "Src/Images/Players/" + skin + "/anim/Direita.gif");
            anim.AddAnimation("Move_Down", "Src/Images/Players/" + skin + "/anim/Frente.gif");
            anim.AddAnimation("Move_Up", "Src/Images/Players/" + skin + "/anim/Fundo.gif");

            anim.AddAnimation("Stop_Left", "Src/Images/Players/" + skin + "/Esquerda_Parado.png");
            anim.AddAnimation("Stop_Right", "Src/Images/Players/" + skin + "/Direita_Parado.png");
            anim.AddAnimation("Stop_Up", "Src/Images/Players/" + skin + "/Fundo_Parado.png");
            anim.AddAnimation("Stop_Down", "Src/Images/Players/" + skin + "/Frente_Parado.png");

            anim.AddAnimation("Hit", "Src/Images/Players/" + skin + "/Dano.png");
            anim.AddAnimation("Lying", "Src/Images/Players/" + skin + "/Deitado.png");
            anim.AddAnimation("Fight", "Src/Images/Players/" + skin + "/anim/Combate.gif");
        }

        anim.Play("Stop_Down");

    }


    public override void Update()
    {
        
        quest.UpdateQuest();

        
        if (AmbienteJogo.Input.Tecla(Windows.System.VirtualKey.W))
        {
            body.velocity.y = -5;
            anim.Play("Move_Up");
        }
        if (AmbienteJogo.Input.Tecla(Windows.System.VirtualKey.S))
        {
            body.velocity.y = 5;
            anim.Play("Move_Down");
        }
        if (AmbienteJogo.Input.Tecla(Windows.System.VirtualKey.A))
        {
            body.velocity.x = -5;
            anim.Play("Move_Left");
        }
        if (AmbienteJogo.Input.Tecla(Windows.System.VirtualKey.D))
        {
            body.velocity.x = 5;
            anim.Play("Move_Right");
        }
        if (AmbienteJogo.Input.TeclaPressionada(Windows.System.VirtualKey.E))
        {
            if (inventoryOpen)
            {
                inventoryUI.HideInventory();
                inventoryOpen = false;
            }
            else
            {
                inventoryUI.ShowInventory();
                inventoryOpen = true;
            }
        }

        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.W))
        {
            anim.Play("Stop_Up");
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.A))
        {
            anim.Play("Stop_Left");
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.S))
        {
            anim.Play("Stop_Down");
        }
        if (AmbienteJogo.Input.TeclaSolta(Windows.System.VirtualKey.D))
        {
            anim.Play("Stop_Right");
        }

       
    }
}

