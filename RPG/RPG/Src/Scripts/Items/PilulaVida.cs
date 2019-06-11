﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Items
{
    class PilulaVida : Item, Comercial, Atacavel, Equipavel, Habilidade
    {
        public PilulaVida()
        {
            TipoItem = (ushort)tipoItem.Consumivel;

            Nome = "Pilula de Vida";
            Preco = 200;
            Estacavel = true;
            Descricao = "Aumenta o HP Máximo de um aliado em 50 até o fim da batalha";

            ItemManager.GenID(this);
        }

        public void Equipar(Status e)
        {
            e.saude = e.saudeMax + 50;
        }

        public int getPreco()
        {
            return Preco;
        }
    }
}