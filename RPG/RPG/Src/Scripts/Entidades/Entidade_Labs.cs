using _3ReaisEngine;
using _3ReaisEngine.Attributes;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts.Entidades
{
    [RequerComponente(typeof(Render))]
    public class Porta:Entidade
    {
        public Porta(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Porta.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class AvidoPerigo : Entidade
    {
        public AvidoPerigo(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0005_Perigo.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Grade : Entidade
    {
        public Grade(Vector2 pos)
        {
            EntPos = pos;
            EntPos.x -= 2;
            EntPos.y += 26f;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0007_Grade.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Monitores : Entidade
    {
        public Monitores(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0003_Monitores.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Luzes : Entidade
    {
        public Luzes(Vector2 pos)
        {
            EntPos = pos;
            EntPos.y += 16.5f;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0006_Luz.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class ArCondicionado : Entidade
    {
        public ArCondicionado(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_Ar-Condicionado.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class MesaHorizontal : Entidade
    {
        Colisao col;
        public MesaHorizontal(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 80;
            col.tamanho.y = 40;
            col.relativePos.x += 15;
            col.relativePos.y -= 15;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0004_Mesa-Horizontal.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class MesaVertical : Entidade
    {
        Colisao col;
        public MesaVertical(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 70;
            col.tamanho.y = 100;
            col.relativePos.y = 10;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;

            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0003_Mesa-Vertical.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class CadeiraCosta : Entidade
    {
        Colisao col;
        public CadeiraCosta(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 25;
            col.tamanho.y = 60;
            col.relativePos.x -= 10;
            col.relativePos.y -= 30;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0001_Cadeira-Costa.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Maquina : Entidade
    {
        Colisao col;
        public Maquina(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 80;
            col.tamanho.y = 80;
            col.relativePos.x += 20;
            col.relativePos.y += 20;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0003_Máquinas.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Teletransporte : Entidade
    {
        Colisao col;
        public Teletransporte(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 48;
            col.tamanho.y = 104;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            EntPos.x += 28;
            EntPos.y -= 8;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0002_TP.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class MaqTP : Entidade
    {
        Colisao col;
        public MaqTP(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 52;
            col.tamanho.y = 52;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0009_Maq-de-TP.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Armario : Entidade
    {
        Colisao col;
        public Armario(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 60;
            col.tamanho.y = 120;
            col.relativePos.y += 10;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            EntPos.x += 60;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0007_Armário.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Extintor : Entidade
    {
        Colisao col;
        public Extintor(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 16;
            col.tamanho.y = 20;
            col.relativePos.x -= 8;
            col.relativePos.y -= 8;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            EntPos.x += 60;
            EntPos.y -= 15;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0004_Extintor.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class CadeiraEsq : Entidade
    {
        Colisao col;
        public CadeiraEsq(Vector2 pos)
        {
            col = AddComponente<Colisao>();
            col.tamanho.x = 30;
            col.tamanho.y = 30;
            col.tipo = TipoColisao.Estatica;
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_0000_Cadeira-Esq.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Notebook : Entidade
    {
        public float atu = 0;
        public Notebook(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Lab_Notebook.png");
        }

        public override void Update()
        {
            atu += 0.005f;
        }

        public override void OnClick(MouseEvento e)
        {
           
            if (Engine.Distance(this.EntPos, Player.currentPlayer.EntPos) < 50)
            {
                ChatBar.ShowChat("Src/Images/Laboratório/Lab_Notebook.png", "              BAIXANDO ATUALIZAÇÕES\n                                "+(int)atu+"%\n        NÃO DESLIGUE O COMPUTADOR");
            }
        }
    }

    [RequerComponente(typeof(Render))]
    public class Vidraria : Entidade
    {
        public Vidraria(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0006_Vidrarias.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Livros : Entidade
    {
        public Livros(Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0001_Livros.png");
        }

    }

    [RequerComponente(typeof(Render))]
    public class Papeis : Entidade
    {
        public Papeis (Vector2 pos)
        {
            EntPos = pos;
            Render r = GetComponente<Render>();
            r.LoadImage("Src/Images/Laboratório/Assets-Laborátorio_0002_Papeis.png");
        }

        public override void OnClick(MouseEvento e)
        {
           
            if (Engine.Distance(this.EntPos, Player.currentPlayer.EntPos) < 50)
            {
                ChatBar.ShowChat("Src/Images/Players/" + Player.currentPlayer.skin + "/Face.png", "Hmm... \nSr. Bruno escreveu uma boa história aqui.");
            }
            
        }

    }

}
