using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class CuraParalisia : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public CuraParalisia()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Cura Paralisia";
            Preco = 50;
            Estacavel = true;
            Descricao = "Remove a paralisia de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            if ((e.estadoAtual & Estado.Paralisado) != 0)
            {
                e.estadoAtual ^= Estado.Paralisado;
            }
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
