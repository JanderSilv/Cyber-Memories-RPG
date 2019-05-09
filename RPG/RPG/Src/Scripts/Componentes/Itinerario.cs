using _3ReaisEngine;
using _3ReaisEngine.Components;
using _3ReaisEngine.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public enum State
    {
        INDO,
        CHEGOU,
        ESPERANDO
    }

    public class No
    {
        public List<No> others = new List<No>();
        public Vector2 position;
        
    }

    
    public class Itinerario : Componente<Itinerario>
    {    
        Dictionary<string, No> caminho = new Dictionary<string, No>();
        Random rnd = new Random();
        State estato;
        No atual;
        No destino;
        float espera = 3;
        public Movel movel;

        public Itinerario()
        {
            atual = null;
            destino = null;
            estato = State.ESPERANDO;
           
        }

        public void Update()
        {
            if (caminho.Count <= 1)
            {
                Engine.Debug("caminho pequeno demais");
                return;
            }
            if (atual == null)
            {
                Engine.Debug("primeiro passo");
                atual = caminho.Values.ElementAt(0);
            }

            if (estato == State.ESPERANDO)
            {
                if (espera > 0)
                {
                    espera -= 0.3f;
                }
                else
                {
                    espera = 3;
                    Escolher();
                    estato = State.INDO;
                }
            }
            if(estato == State.INDO)
            {
                if (entidade.EntPos != destino.position)
                {
                    if (entidade.EntPos.x < destino.position.x) movel.Mover(1,0);
                    else if (entidade.EntPos.x > destino.position.x) movel.Mover(-1, 0);

                    if (entidade.EntPos.y < destino.position.y) movel.Mover(0, 1);
                    else if (entidade.EntPos.y > destino.position.y) movel.Mover(0, -1);
                }
                else
                {
                    atual = destino;
                    espera = 3;
                    estato = State.ESPERANDO;
                }
            }

        }

        public void AddPos(string nome, Vector2 pos)
        {
            No n = new No();
            n.position = pos;
            caminho.Add(nome, n);
        }

        public void Conect(string no1,string no2)
        {
            caminho[no1].others.Add(caminho[no2]);
            caminho[no2].others.Add(caminho[no1]);
        }

        void Escolher()
        {
            if (atual == null) return;
            int possibilidades = atual.others.Count;
            int escolha = rnd.Next(0, possibilidades);

            destino = atual.others[escolha];
        }
    }


