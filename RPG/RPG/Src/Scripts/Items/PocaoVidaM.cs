using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoVidaM : Item, Comercial, Atacavel, Equipavel
    {
        
        public PocaoVidaM()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Vida M";
            Preco = 170;
            Estacavel = true;
            Descricao = "Recupera 30 de HP de um aliado";

            ItemManager.GenID(this);
        }

        public void Atacar(Status e)
        {
          
        }

        public void Equipar(Status e)
        {
            e.saude += 30;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
