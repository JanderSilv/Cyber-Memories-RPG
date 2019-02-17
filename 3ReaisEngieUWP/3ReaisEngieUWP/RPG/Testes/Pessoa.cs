using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using _3ReaisEngine.RPG.Components;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.RPG.Events;

namespace _3ReaisEngine.RPG.Testes
{
    public class Pessoa : Entidade
    {
        public Pessoa(string Nome) : base(Nome)
        {
            AddComponente<Colisao>();
        }

        public override void OnColide(Colisao col)
        {
            base.OnColide(col);
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
