using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class Antidoto : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public Antidoto()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Antidoto";
            Preco = 50;
            Estacavel = true;
            Descricao = "Remove veneno de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            if ((e.estadoAtual & Estado.Envenenado) != 0)
            {
                e.estadoAtual ^= Estado.Envenenado;
            }
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
