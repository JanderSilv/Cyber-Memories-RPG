using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoMagica : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PocaoMagica()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao Magica";
            Preco = 900;
            Estacavel = true;
            Descricao = "Recupera todo o HP e MP de aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.mana = e.manaMax;
            e.saude = e.saudeMax;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
}
