using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaInteligencia : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaInteligencia()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de inteligencia";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta a inteligencia de um aliado em 3 pontos até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.inteligencia += 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
