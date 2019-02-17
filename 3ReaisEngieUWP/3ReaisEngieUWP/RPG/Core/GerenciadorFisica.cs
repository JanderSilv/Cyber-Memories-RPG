using System;
using _3ReaisEngine.RPG.Components;


namespace _3ReaisEngine.RPG.Core
{
    public class GerenciadorFisica
    {
        int length =0;
        Vector2 dist = Vector2.Zero;
        Vector2 centerI = Vector2.Zero;
        Vector2 centerJ = Vector2.Zero;

        public void UpdateColisions(Colisao[] array)
        {
            length  = array.Length;
            if (length == 0) return;
            dist    = Vector2.Zero;
            centerI = Vector2.Zero;
            centerJ = Vector2.Zero;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    centerI.x = array[i].largura / 2;
                    centerI.y = array[i].altura / 2;
                    centerJ.x = array[j].largura / 2;
                    centerJ.y = array[j].altura / 2;

                    dist = (array[i].Posicao - centerI) - (array[j].Posicao - centerJ);

                    if ((dist.x > 0 && dist.x < array[j].largura) || (dist.x < 0 && Math.Abs(dist.x) < array[i].largura) || (dist.y > 0 && dist.y < array[j].altura) || (dist.y < 0 && Math.Abs(dist.y) < array[i].altura))
                    {
                        array[i].momentoDeColisao = dist;
                        array[j].momentoDeColisao = -dist;

                        array[i].entidade.OnColide(array[j]);
                        array[j].entidade.OnColide(array[i]);
                    }
                }
            }
        }
    }
}
