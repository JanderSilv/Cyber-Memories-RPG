using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class TrevoSorte : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public TrevoSorte()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Trevo da sorte";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta a sorte de um aliado em 3 pontos até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.sorte += 3;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}
