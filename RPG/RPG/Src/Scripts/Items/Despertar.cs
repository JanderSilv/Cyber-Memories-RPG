]using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class Despertar : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public Despertar()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Despertar";
            Preco = 50;
            Estacavel = true;
            Descricao = "Acorda um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            if ((e.estadoAtual & Estado.Dormindo) != 0)
            {
                e.estadoAtual ^= Estado.Dormindo;
            }
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
