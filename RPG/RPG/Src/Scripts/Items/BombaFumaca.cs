using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class BombaFumaca : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public BombaFumaca()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Bomba Fumaca";
            Preco = 160;
            Estacavel = true;
            Descricao = "Gera uma fumaça que dificulta o acerto de golpes";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.estadoAtual = Estado.Cego; 
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
