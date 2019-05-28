using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoManaG : Item, Comercial, Atacavel, Equipavel
    {
        public PocaoManaG()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Mana G";
            Preco = 550;
            Estacavel = true;
            Descricao = "Recupera 100% de MP de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.mana = e.manaMax;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
