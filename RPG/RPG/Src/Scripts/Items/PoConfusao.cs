using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PoConfusao : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PoConfusao()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Po de Confusao";
            Preco = 180;
            Estacavel = true;
            Descricao = "Pó mágico que causa confusão a quem inalá-lo";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.estadoAtual = Estado.Confuso;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
