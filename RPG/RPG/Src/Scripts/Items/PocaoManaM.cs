using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoManaM : Item, Comercial, Atacavel, Equipavel
    {
        public PocaoManaM()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Mana M";
            Preco = 300;
            Estacavel = true;
            Descricao = "Recupera 30 de MP de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.mana += 30;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
