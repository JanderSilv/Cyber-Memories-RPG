using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoVidaG: Item, Comercial, Atacavel, Equipavel
    {
        public PocaoVidaG()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Vida G";
            Preco = 450;
            Estacavel = true;
            Descricao = "Recupera 100% de HP de um aliado";

            ItemManager.GenID(this);
        }

        public void Atacar(Status e)
        {
           
        }

        public void Equipar(Status e)
        {
            e.saude = e.saudeMax;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
