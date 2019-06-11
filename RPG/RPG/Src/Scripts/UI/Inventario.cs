using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace RPG.Src.Scripts.UI
{
    class Inventario 
    {
        public void ShowInventory()
        {
            // Tem que organizar as posições, ainda não testei.

            UPanel inventory = new UPanel(new Vector2(50, 50), new Vector2(660, 330));

            UImage storage = new UImage("Src/Images/Menu/Inventário/Contorno.png", new Vector2(1, 5), new Vector2(100, 100));
            UImage coin = new UImage("Src/Images/Menu/Inventário/Moeda.png", new Vector2(90,4), new Vector2(100,100));

            // Preencher os slots

            UImage atrbBorder = new UImage("Src/Images/Menu/Inventário/Contorno_Inventario.png", new Vector2(70, 40), new Vector2(100, 100));
            UImage invText = new UImage("Src/Images/Menu/Inventário/Inventário_1.png", new Vector2(10, 10), new Vector2(100, 100));
            UImage atrbText = new UImage("Src/Images/Menu/Inventário/Personagem.png", new Vector2(70, 10), new Vector2(100, 100));


            UButton weapon = new UButton("", new Vector2(70, 10), new Vector2(56,51), Weapon);
            UButton armor = new UButton("", new Vector2(70,20), new Vector2(56,51), Armor);
            UButton attribute = new UButton("", new Vector2(70, 30), new Vector2(56, 51), Attribute);

            weapon.setBackground("Src/Images/Menu/Inventário/Armas.png");
            weapon.setOnHover("Src/Images/Menu/Inventário/Armas_Selecionados.png");
            armor.setBackground("Src/Images/Menu/Inventário/Armadura.png");
            armor.setOnHover("Src/Images/Menu/Inventário/Armadura_Selecionado.png");
            attribute.setBackground("Src/Images/Menu/Inventário/Atributos.png");
            attribute.setOnHover("Src/Images/Menu/Inventário/Atributos_Selecionado.png");

            inventory.addChild(storage);
            inventory.addChild(coin);
            inventory.addChild(atrbBorder);
            inventory.addChild(invText);
            inventory.addChild(atrbText);
            inventory.addChild(weapon);
            inventory.addChild(armor);
            inventory.addChild(attribute);
        }

        public void showArmor() {

            UPanel panArmor = new UPanel(new Vector2(), new Vector2());

            UImage txtArmor = new UImage("Src/Images/Menu/Inventário/Armadura_Texto.png", new Vector2(), new Vector2(100,100));

            panArmor.addChild(txtArmor);
        }

        public void showWeapon()
        {
            UPanel panWeapon = new UPanel(new Vector2(), new Vector2());

            UImage txtWeapon = new UImage("Src/Images/Menu/Inventário/Arma_Texto.png", new Vector2(), new Vector2(100, 100));

            panWeapon.addChild(txtWeapon);
        }

        public void showAttribute()
        {
            UPanel panAttribute = new UPanel(new Vector2(), new Vector2());

            UImage txtAttribute = new UImage("Src/Images/Menu/Inventário/Atributos_Texto.png", new Vector2(), new Vector2(100, 100));

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
}
