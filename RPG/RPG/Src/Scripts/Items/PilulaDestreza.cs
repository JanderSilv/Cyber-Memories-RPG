using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaDestreza : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaDestreza()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de Destreza";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta a destreza de um aliado em 3 pontos até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.destreza += 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
