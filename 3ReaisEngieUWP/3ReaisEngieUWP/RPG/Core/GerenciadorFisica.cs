using _3ReaisEngine.Components;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _3ReaisEngine.Core
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
            bool[] tested = new bool[array.Length];

            if (length <= 1) return;

            for (int i = 0; i < length; i++)
            {
                
                if (array[i].tipo == TipoColisao.Estatica) continue;
                array[i].momentoDeColisao = new Vector4(0, 0, 0, 0);

                for (int j = 0; j < length; j++)
                {
                    if (j == i) continue;

                    dist.y = Math.Abs(array[i].entidade.EntPos.y - array[j].entidade.EntPos.y);
                    dist.x = Math.Abs(array[i].entidade.EntPos.x - array[j].entidade.EntPos.x);

                    unsafeX = (array[i].tamanho.x / 2 + array[j].tamanho.x / 2);
                    unsafeY = (array[i].tamanho.y / 2 + array[j].tamanho.y / 2);
                    
                    if (dist.x > unsafeX && dist.y > unsafeY)
                    {
                        continue;
                    }

                    float dir = (array[j].entidade.EntPos.x - array[j].tamanho.x / 2) - (array[i].entidade.EntPos.x + array[i].tamanho.x / 2);
                    float esq = (array[i].entidade.EntPos.x - array[i].tamanho.x / 2) - (array[j].entidade.EntPos.x + array[j].tamanho.x / 2);

                    float top = (array[i].entidade.EntPos.y - array[i].tamanho.y / 2) - (array[j].entidade.EntPos.y + array[j].tamanho.y / 2);
                    float bot = (array[j].entidade.EntPos.y - array[j].tamanho.y / 2) - (array[i].entidade.EntPos.y + array[i].tamanho.y / 2);

                   

                    if (array[i].entidade.EntPos.x < array[j].entidade.EntPos.x)
                    {
                        if (dir < 0 && dist.y <= unsafeY * 0.93f)
                        {
                            array[i].momentoDeColisao.x = dir;                         
                            array[i].OnColide(array[j]);                      
                            continue;
                        }
                    }
                    else if (array[i].entidade.EntPos.x > array[j].entidade.EntPos.x)
                    {
                        if (esq < 0 && dist.y <= unsafeY * 0.93f)
                        {
                            array[i].momentoDeColisao.z = esq;                           
                            array[i].OnColide(array[j]);
                            continue;
                        }
                    }

                    if (array[i].entidade.EntPos.y > array[j].entidade.EntPos.y)
                    {
                        if (top < 0 && dist.x <= unsafeX * 0.93f)
                        {
                            array[i].momentoDeColisao.y = top;
                            array[i].OnColide(array[j]);
                            continue;
                        }
                    }
                    else if (array[i].entidade.EntPos.y < array[j].entidade.EntPos.y)
                    {
                        if (bot < 0 && dist.x <= unsafeX * 0.9f)
                        {
                            array[i].momentoDeColisao.w = bot;                            
                            array[i].OnColide(array[j]);
                            continue;
                        }
                    }

                  
                }
                
            }
        }
    }
}
