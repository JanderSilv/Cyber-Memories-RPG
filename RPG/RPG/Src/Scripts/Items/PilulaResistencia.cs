using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaResistencia : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaResistencia()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de Resistencia";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta a resistencia em 3 pontos até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.resistencia += 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
