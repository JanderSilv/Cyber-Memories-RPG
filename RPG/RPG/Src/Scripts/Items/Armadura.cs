﻿class Armadura : Item, Comercial, Atacavel, Equipavel
{
    public Armadura()
    {
        TipoItem = (ushort)tipoItem.Armadura;

        Nome = "Armadura de couro";
        Preco = 40;
        Estacavel = false;
        Descricao = "Nao é muito util mas melhor que ficar nu";

        ItemManager.GenID(this);
        _3ReaisEngine.Engine.Print("ID da armadura " + ID);
    }

    public void Atacar(Status e)
    {

    }

    public void Equipar(Status e)
    {

    }

    public int getPreco()
    {
        return Preco;
    }
}

