using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaMana : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaMana()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de Mana";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta o MP Máximo de um aliado em 50 até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.mana = e.manaMax + 50;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
