using _3ReaisEngine.RPG.Components;
using System;
using System.Diagnostics;

namespace _3ReaisEngine.RPG.Core
{
    public class GerenciadorFisica
    {
        int length = 0;
        Vector2 dist = Vector2.Zero;
        float unsafeX = 0;
        float unsafeY = 0;

        public void UpdateColisions(Colisao[] array)
        {
            length = array.Length;
       
            if (length <= 1) return;

            for (int i = 0; i < length; i++)
            {
                
                if (array[i].tipo == TipoColisao.Estatica) continue;
                array[i].momentoDeColisao = new Vector4(0, 0, 0, 0);

                for (int j = i + 1; j < length; j++)
                {
                    
                    dist.y = Math.Abs(array[i].entidade.Posicao.y - array[j].entidade.Posicao.y);
                    dist.x = Math.Abs(array[i].entidade.Posicao.x - array[j].entidade.Posicao.x);

                    unsafeX = (array[i].tamanho.x / 2 + array[j].tamanho.x / 2);
                    unsafeY = (array[i].tamanho.y / 2 + array[j].tamanho.y / 2);
                    
                    if (dist.x > unsafeX && dist.y > unsafeY)
                    {
                        continue;
                    }

                    float dir = (array[j].entidade.Posicao.x - array[j].tamanho.x / 2) - (array[i].entidade.Posicao.x + array[i].tamanho.x / 2);
                    float esq = (array[i].entidade.Posicao.x - array[i].tamanho.x / 2) - (array[j].entidade.Posicao.x + array[j].tamanho.x / 2);

                    float top = (array[i].entidade.Posicao.y - array[i].tamanho.y / 2) - (array[j].entidade.Posicao.y + array[j].tamanho.y / 2);
                    float bot = (array[j].entidade.Posicao.y - array[j].tamanho.y / 2) - (array[i].entidade.Posicao.y + array[i].tamanho.y / 2);



                    if (array[i].entidade.Posicao.x < array[j].entidade.Posicao.x)
                    {
                        if (dir < 0 && dist.y <= unsafeY * 0.93f)
                        {
                            array[i].momentoDeColisao.x = dir;
                            array[j].momentoDeColisao.z = dir;
                            array[i].entidade.OnColide(array[j]);
                            array[j].entidade.OnColide(array[i]);
                            continue;
                        }
                    }
                    else if (array[i].entidade.Posicao.x > array[j].entidade.Posicao.x)
                    {
                        if (esq < 0 && dist.y <= unsafeY * 0.93f)
                        {
                            array[i].momentoDeColisao.z = esq;
                            array[j].momentoDeColisao.x = esq;
                            array[i].entidade.OnColide(array[j]);
                            array[j].entidade.OnColide(array[i]);
                            continue;
                        }
                    }

                    if (array[i].entidade.Posicao.y > array[j].entidade.Posicao.y)
                    {
                        if (top < 0 && dist.x <= unsafeX * 0.93f)
                        {
                            array[i].momentoDeColisao.y = top;
                            array[j].momentoDeColisao.w = top;
                            array[i].entidade.OnColide(array[j]);
                            array[j].entidade.OnColide(array[i]);
                            continue;
                        }
                    }
                    else if (array[i].entidade.Posicao.y < array[j].entidade.Posicao.y)
                    {
                        if (bot < 0 && dist.x <= unsafeX * 0.9f)
                        {
                            array[i].momentoDeColisao.w = bot;
                            array[j].momentoDeColisao.y = bot;
                            array[i].entidade.OnColide(array[j]);
                            array[j].entidade.OnColide(array[i]);
                            continue;
                        }
                    }



                }
            }
        }
    }
}
