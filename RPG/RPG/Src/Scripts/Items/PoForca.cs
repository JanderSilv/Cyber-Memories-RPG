using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PoForca : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PoForca()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Po de Força";
            Preco = 200;
            Estacavel = true;
            Descricao = "Pó mágico que diminui a forca de quem entra em contato ";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.forca -= 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
