using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class Elixir: Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public Elixir()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Elixir";
            Preco = 95;
            Estacavel = true;
            Descricao = "Remove varios estados negativos de um aliado";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.estadoAtual = 0;
            
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
