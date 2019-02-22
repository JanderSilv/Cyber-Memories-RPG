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

                    //colisao a direita
                    if (array[i].Posicao.x < array[j].Posicao.x)
                    {
                        float d = (array[j].posicao.x - array[j].tamanho.x / 2) - (array[i].posicao.x + array[i].tamanho.x / 2);
                        if (d<0 && dist.y<=unsafeY){
                            array[i].momentoDeColisao.x = d;
                            array[j].momentoDeColisao.z = d;
                        }
                       
                    }
                    
                    //colisao a esquerda (corrigir)
                    if (array[i].Posicao.x > array[j].Posicao.x)
                    {
                        float d = (array[j].posicao.x + array[j].tamanho.x / 2) - (array[i].posicao.x - array[i].tamanho.x / 2);
                        if (d < 0 && dist.y <= unsafeY)
                        {
                            array[i].momentoDeColisao.z = d;
                            array[j].momentoDeColisao.x = d;
                        }
                       
                    }

                    //colisao em cima
                    if(array[i].Posicao.y > array[j].posicao.y)
                    {
                        float d = (array[i].posicao.y - array[i].tamanho.y / 2) - (array[j].posicao.y + array[j].tamanho.y / 2); 
                        if(d<0 && dist.x <= unsafeX)
                        {
                            array[i].momentoDeColisao.y = d;
                            array[j].momentoDeColisao.w = d;
                        }
                    }

                    //colisao direita(implementar)
                }
            }
        }
    }
}
