using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaForca : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaForca()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de Forca";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta a forca de um aliado em 3 pontos ate o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.forca += 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
