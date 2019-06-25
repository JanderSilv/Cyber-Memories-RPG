using _3ReaisEngine;
using _3ReaisEngine.Core;
using System;

public enum Estado
{

    Normal = 1, Envenenado = 2, Paralisado = 4, Confuso = 8, Dormindo = 16, Cego = 32
}

public class Combate : Componente<Combate>
{
    public int forca, inteligencia, resistencia, sorte, saude, destreza, level, mana;
    public int saudeMax, manaMax, forcaMax; 
    public float velocidade;
    public double  xpMax, xpRecebido, xpAtual;
    public Estado estadoAtual;

    public Arma arma;
    public Elmo elmo;
    public Peitoral peitoral;
    public Calca calca;
    public Bota bota;

    public void Use(Arma arma)
    {
        
        this.arma?.Desequipar(this);
        this.arma = arma;
        this.arma.Equipar(this);
        Engine.Print("Int: " + inteligencia + "\n For: " + forca + "\n Dest: " + destreza);
    }
    public void Use(Armadura arm)
    {
        if(arm is Elmo)
        {
            this.elmo?.Desequipar(this);
            elmo = (Elmo)arm;
            this.elmo.Equipar(this);
        }
        else if(arm is Peitoral)
        {
            this.peitoral?.Desequipar(this);
            peitoral = (Peitoral)arm;
            this.peitoral.Equipar(this);
        }
        else if(arm is Calca)
        {
            this.calca?.Desequipar(this);
            calca = (Calca)arm;
            this.calca.Equipar(this);
        }
        else if(arm is Bota)
        {
            this.bota?.Desequipar(this);
            bota = (Bota)arm;
            this.bota.Equipar(this);
        }
    }

    public void Ataque(Combate cmb)
    {
        if ((estadoAtual & Estado.Paralisado) != 0) return;
        else if((cmb.estadoAtual & Estado.Paralisado) != 0){
            arma.Atacar(cmb);
            return;
        }
        if (new Random().Next(0, 100) + destreza < 20+cmb.destreza) return;

        if (new Random().Next(0, 100) + sorte > 90 + cmb.sorte)
        {
            arma.danoBasico += (int)(arma.danoBasico * 0.20f);
            arma.Atacar(cmb);
            arma.danoBasico -= (int)(arma.danoBasico * 0.20f);
        }
        else
        {
            arma.Atacar(cmb);
        }
    }
    public void AtaqueEspel(Combate cmb)
    {
        if ((estadoAtual & Estado.Paralisado) != 0) return;
        else if ((cmb.estadoAtual & Estado.Paralisado) != 0)
        {
            arma.Atacar(cmb);
            arma.habilidade.Atacar(cmb);
            return;
        }
        if (new Random().Next(0, 100) + destreza < 20 + cmb.destreza) return;

        if (new Random().Next(0, 100) + sorte > 90 + cmb.sorte)
        {
            arma.danoBasico += (int)(arma.danoBasico * 0.20f);
            arma.Atacar(cmb);
            arma.danoBasico -= (int)(arma.danoBasico * 0.20f);
        }
        else
        {
            arma.Atacar(cmb);
        }
        arma.habilidade.Atacar(cmb);
      
    }
    public bool upLevel()
    {
        if (xpAtual >= xpMax)
        {
            level += 1;
            xpAtual -= xpMax ;
            xpMax = xpMax * 1.50;
            return true;
        }
        else
        {
            return false;
        }
    }
}
