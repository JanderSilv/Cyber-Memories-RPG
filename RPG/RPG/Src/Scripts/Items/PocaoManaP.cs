using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoManaP : Item, Comercial, Atacavel, Equipavel
    {
        public PocaoManaP()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Mana P";
            Preco = 120;
            Estacavel = true;
            Descricao = "Recupera 20 de MP de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.mana += 20;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
