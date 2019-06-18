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
    UImage[,] slots = new UImage[sizeX, sizeY];
    public InventarioPopUp()
    {
       
        inventory.manipulationMode = ManipulationModes.All;
        inventory.SetBackGround("Src/Images/Menu/Inventário/Contorno.png");
        UImage coin = new UImage("Src/Images/Menu/Inventário/Moeda.png", new Vector2(92.75f, 12.5f), new Vector2(24, 26));

        // Preencher os slots do inventário.

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
                inventory.addChild(slots[x, y]);
            }
        }
    }
        public  bool UpdateTeclado(TecladoEvento e)
        {
            if (e.Tecla == (int)VirtualKey.Enter || e.Tecla == (int)VirtualKey.Escape)
            {
                HideInventory();
            }
            return true;
        }
    public void ShowInventory()
    {
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
}
