using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


public class InventarioPopUp
{
  
    static int sizeX = 7, sizeY = 7;
    public UPanel inventory = new UPanel(new Vector2(50, 50), new Vector2(700, 330 * 1.25f));
    public Inventario inv;
    UImage[,] slots = new UImage[sizeX, sizeY];
    UImage[,] itemSlot = new UImage[sizeX, sizeY];
    UImage owner;
    Slot currentItem;


    UButton btn_usar;  
    UButton btn_largar;
    UButton btn_pegar;                   
    UButton btn_info;

    public InventarioPopUp()
    {
        inventory.element.PointerPressed += Element_PointerPressed;
        inventory.manipulationMode = ManipulationModes.All;
        inventory.SetBackGround("Src/Images/Menu/Inventário/Contorno.png");

         btn_usar = new UButton("Src/Images/Menu/usar.png", new Vector2(0, 0), new Vector2(85, 30), usar_act);

         btn_largar = new UButton("Src/Images/Menu/largar.png", new Vector2(0, 0), new Vector2(85, 30), largar_act);

         btn_pegar = new UButton("Src/Images/Menu/pegar.png", new Vector2(0, 0), new Vector2(85, 30), pegar_act);

         btn_info = new UButton("", new Vector2(0, 0), new Vector2(85, 30), info_act);

        UImage coin = new UImage("Src/Images/Menu/Inventário/Moeda.png", new Vector2(92.75f, 12.5f), new Vector2(24, 26));

        UImage atrbBorder = new UImage("Src/Images/Menu/Inventário/Contorno_Inventario.png", new Vector2(75, 55), new Vector2(180, 320));
        UImage invText = new UImage("Src/Images/Menu/Inventário/Inventário_1.png", new Vector2(25, 10), new Vector2(184, 33));
        UImage persText = new UImage("Src/Images/Menu/Inventário/Personagem.png", new Vector2(70, 10), new Vector2(166, 23));


        UButton weapon = new UButton("", new Vector2(107, 30), new Vector2(56, 51), Weapon);
        UButton armor = new UButton("", new Vector2(107, 50), new Vector2(56, 51), Armor);
        UButton attribute = new UButton("", new Vector2(107, 70), new Vector2(56, 51), Attribute);

        weapon.setBackground("Src/Images/Menu/Inventário/Armas.png");
        weapon.setOnHover("Src/Images/Menu/Inventário/Armas_Selecionados.png");
        armor.setBackground("Src/Images/Menu/Inventário/Armadura.png");
        armor.setOnHover("Src/Images/Menu/Inventário/Armadura_Selecionado.png");
        attribute.setBackground("Src/Images/Menu/Inventário/Atributos.png");
        attribute.setOnHover("Src/Images/Menu/Inventário/Atributos_Selecionado.png");

        btn_info.setBackground("Src/Images/Menu/info.png");
        btn_largar.setBackground("Src/Images/Menu/largar.png");
        btn_pegar.setBackground("Src/Images/Menu/pegar.png");
        btn_usar.setBackground("Src/Images/Menu/usar.png");

        inventory.addChild(coin);
        inventory.addChild(atrbBorder);
        inventory.addChild(invText);
        inventory.addChild(persText);
        inventory.addChild(weapon);
        inventory.addChild(armor);
        inventory.addChild(attribute);

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                slots[x, y] = new UImage("Src/Images/Menu/Inventário/Slot.png", new Vector2(8 + x * 8, 22.5f + y * 10), new Vector2(40, 40));
                itemSlot[x,y] = new UImage(" ", new Vector2(8 + x * 8, 22.5f + y * 10), new Vector2(34, 34));
               
                inventory.addChild(slots[x, y]);
                inventory.addChild(itemSlot[x, y]);
                itemSlot[x, y].Action = Selected;
            }
        }
    }

    private void Element_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        HideMenu();
    }

    private void Selected(object sender)
    {
        UImage img = ((UImage)(sender));
        int x = (int)((img.position.x - 8) / 8);
        int y = (int)((img.position.x - 22.5f) / 10);
        int index = x + y * sizeY;
        if (index < 1) index = 0;

        currentItem = inv.getByIndex(index);
        if (img == owner)
        {
            HideMenu();
            owner = null;
        }
        else
        {
            ShowMenu(img.position, usar: true, largar: true,info:true);
            owner = img;
        }

      
       
       
       
    }
    public  bool UpdateTeclado(TecladoEvento e)
        {
            if (e.Tecla == (int)VirtualKey.Enter || e.Tecla == (int)VirtualKey.Escape)
            {
                HideMenu();
                HideInventory();
            }
            return true;
        }

    public void ShowInventory()
    {
        int i = 0;
        foreach(Slot s in inv.slots.Values)
        {
            itemSlot[i % sizeX, i / sizeY].Content = s.arm.getImagem();
            i++;
        }

        inventory.position.x = 50;
        inventory.position.y = 50;
       // AmbienteJogo.RegistrarEventoCallBack(PrioridadeEvento.Interface, UpdateTeclado);
        AmbienteJogo.window.Add(inventory);
    }
    public void HideInventory()
    {
       // AmbienteJogo.RemoverEventoCallBack(PrioridadeEvento.Interface, UpdateTeclado);
        AmbienteJogo.window.Remove(inventory);
    }


    public void showArmor()
    {

        UPanel panArmor = new UPanel(new Vector2(), new Vector2());

        UImage txtArmor = new UImage("Src/Images/Menu/Inventário/Armadura_Texto.png", new Vector2(), new Vector2(112, 181));

        panArmor.addChild(txtArmor);
    }
    public void showWeapon()
    {
        UPanel panWeapon = new UPanel(new Vector2(), new Vector2());

        UImage txtWeapon = new UImage("Src/Images/Menu/Inventário/Arma_Texto.png", new Vector2(), new Vector2(62, 81));

        panWeapon.addChild(txtWeapon);
    }
    public void showAttribute()
    {
        UPanel panAttribute = new UPanel(new Vector2(), new Vector2());

        UImage txtAttribute = new UImage("Src/Images/Menu/Inventário/Atributos_Texto.png", new Vector2(), new Vector2(62, 162));

        panAttribute.addChild(txtAttribute);
    }

    private void Armor(object sender)
    {
        // troca pro panel de armadura
        showArmor();
    }
    private void Weapon(object sender)
    {
        // troca pro panel de arma
        showWeapon();
    }
    private void Attribute(object sender)
    {
        // troca pro panel de atributos
        showAttribute();
    }

    private void ShowMenu(Vector2 startPos,bool usar=false,bool pegar=false,bool largar=false,bool info=false)
    {
        float desloc = 2.5f;
        if (usar)
        {
            btn_usar.position = startPos+new Vector2(7.5f, desloc);
            inventory.addChild(btn_usar);
            desloc += 8;
        }
        if (largar)
        {
            btn_largar.position = startPos + new Vector2(7.5f, desloc);
            inventory.addChild(btn_largar);
            desloc += 8;
        }
        if (pegar)
        {
            btn_pegar.position = startPos + new Vector2(7.5f, desloc);
            inventory.addChild(btn_pegar);
            desloc += 8;
        }
        if (info)
        {
            btn_info.position = startPos + new Vector2(7.5f, desloc);
            inventory.addChild(btn_info);
        }    
        inventory.UpdateUI();
    }

    private void HideMenu()
    {
        owner = null;
        inventory.removeChild(btn_usar);
        inventory.removeChild(btn_largar);
        inventory.removeChild(btn_pegar);
        inventory.removeChild(btn_info);
        inventory.UpdateUI();
    }


     void usar_act(object sender)
    {
       
    }
     void largar_act(object sender)
    {
        
    }
     void pegar_act(object sender)
    {
        
    }
     void info_act(object sender)
    {
        Engine.Print("Clicou em " + currentItem.arm.getItem<Item>().Nome +"\n"+ currentItem.arm.getItem<Item>().Descricao);
    }
}
