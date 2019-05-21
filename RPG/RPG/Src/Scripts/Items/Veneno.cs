using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class Veneno : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public Veneno()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Veneno";
            Preco = 200;
            Estacavel = true;
            Descricao = "Frasco de veneno que causa envenenamento a quem entrar em contato";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.estadoAtual = Estado.Envenenado;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
