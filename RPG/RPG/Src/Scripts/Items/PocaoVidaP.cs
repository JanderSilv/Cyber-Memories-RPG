using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PocaoVidaP: Item, Comercial, Atacavel, Equipavel
    {
        public PocaoVidaP()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pocao de Vida P";
            Preco = 60;
            Estacavel = true;
            Descricao = "Recupera 20 de HP de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.saude += 60;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
