using System;
using _3ReaisEngieUWP.RPG.Core;
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
            float unsafeX = 0;
            float unsafeY = 0;

            for (int i = 0; i < length; i++)
            {
                array[i].momentoDeColisao = new Vector4(0,0,0,0);

                for (int j = i + 1; j < length; j++)
                {

                    dist.y = Math.Abs(array[i].posicao.y - array[j].posicao.y);
                    dist.x = Math.Abs(array[i].posicao.x - array[j].posicao.x);

                    unsafeX = (array[i].tamanho.x / 2 + array[j].tamanho.x / 2);
                    unsafeY = (array[i].tamanho.y / 2 + array[j].tamanho.y / 2);

                    if (dist.x > unsafeX && dist.y >unsafeY)
                    {
                        continue;
                    }

                    float dir = (array[j].posicao.x - array[j].tamanho.x / 2) - (array[i].posicao.x + array[i].tamanho.x / 2);
                    float esq = (array[i].posicao.x - array[i].tamanho.x / 2) - (array[j].posicao.x + array[j].tamanho.x / 2);

                    float top = (array[i].posicao.y - array[i].tamanho.y / 2) - (array[j].posicao.y + array[j].tamanho.y / 2);
                    float bot = (array[j].posicao.y - array[j].tamanho.y / 2) - (array[i].posicao.y + array[i].tamanho.y / 2);
                  
                    if(array[i].posicao.x < array[j].posicao.x)
                    {
                        if(dir<0 && dist.y <= unsafeY*0.95f)
                        {
                            array[i].momentoDeColisao.x = dir;
                            array[j].momentoDeColisao.z = dir;
                            continue;
                        }
                    }
                    else
                    {
                        if (esq < 0 && dist.y <= unsafeY*0.95f)
                        {
                            array[i].momentoDeColisao.z = esq;
                            array[j].momentoDeColisao.x = esq;
                            continue;
                        }
                    }

                    if (array[i].posicao.y > array[j].posicao.y)
                    {
                        if(top<0 && dist.x <= unsafeX*0.95f)
                        {
                            array[i].momentoDeColisao.y = top;
                            array[j].momentoDeColisao.w = top;
                            continue;
                        }
                    }
                    else
                    {
                        if (bot < 0 && dist.x <= unsafeX*0.95f)
                        {
                            array[i].momentoDeColisao.w = bot;
                            array[j].momentoDeColisao.y = bot;
                            continue;
                        }
                    }
                    
                }
            }
        }
    }
}
