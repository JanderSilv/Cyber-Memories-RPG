using _3ReaisEngine.Components;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _3ReaisEngine.Core
{
    public class GerenciadorFisica
    {
       

        public void UpdateColisions(Colisao[] array)
        {
            int length = 0;
            Vector2 dist = Vector2.Zero;
            float unsafeX = 0;
            float unsafeY = 0;
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

                    if (array[i].entidade.Nome == "Tust")
                    {
                        Engine.Debug("Distancia: " + dist.ToString());
                        Engine.Debug("Unsafe: " + unsafeX + ", " + unsafeY);
                        Engine.Debug("Tust 1:" + array[i].entidade.EntPos.ToString() + " , Opera 2:" + array[j].entidade.EntPos.ToString());
                    }
                  
                    if (dist.x > unsafeX && dist.y > unsafeY)
                    {
                        continue;
                    }
                    
                    float dir = (array[j].entidade.EntPos.x - array[j].tamanho.x / 2) - (array[i].entidade.EntPos.x + array[i].tamanho.x / 2);
                    float esq = (array[i].entidade.EntPos.x - array[i].tamanho.x / 2) - (array[j].entidade.EntPos.x + array[j].tamanho.x / 2);
                    float top = (array[i].entidade.EntPos.y - array[i].tamanho.y / 2) - (array[j].entidade.EntPos.y + array[j].tamanho.y / 2);
                    float bot = (array[j].entidade.EntPos.y - array[j].tamanho.y / 2) - (array[i].entidade.EntPos.y + array[i].tamanho.y / 2);
                    if (array[i].entidade.Nome == "Tust") Engine.Debug("Dir: " + dir + ", Esq: " + esq + ", Top: " + top + ", Bot: " + bot);

                    if (array[i].entidade.EntPos.x < array[j].entidade.EntPos.x)
                    {
                        if (dir < 0 && dist.y <= unsafeY )
                        {
                            array[i].momentoDeColisao.x = dir;                         
                            array[i].OnColide(array[j]);                      
                           
                        }
                    }
                    else if (array[i].entidade.EntPos.x > array[j].entidade.EntPos.x)
                    {
                        if (esq < 0 && dist.y <= unsafeY )
                        {
                            array[i].momentoDeColisao.z = esq;                           
                            array[i].OnColide(array[j]);
                            
                        }
                    }

                    if (array[i].entidade.EntPos.y > array[j].entidade.EntPos.y)
                    {
                        if (top < 0 && dist.x <= unsafeX )
                        {
                            array[i].momentoDeColisao.y = top;
                            array[i].OnColide(array[j]);
                            
                        }
                    }
                    else if (array[i].entidade.EntPos.y < array[j].entidade.EntPos.y)
                    {
                        if (bot < 0 && dist.x <= unsafeX )
                        {
                            array[i].momentoDeColisao.w = bot;                            
                            array[i].OnColide(array[j]);
                            
                        }
                    }
                //    if (array[i].entidade.Nome == "Tust") Engine.Debug("Momento colisao " + array[i].momentoDeColisao.ToString());

                }
                
            }
        }

        public void UpdateColisions2(Colisao[] array)
        {
            int lenght = array.Length;
            Vector2 distance;
            Vector2 safeDist = Vector2.Zero;

            for (int i = 0; i < lenght; i++)
            {
                if (array[i].tipo == TipoColisao.Estatica) continue;

                array[i].momentoDeColisao.w = 0;
                array[i].momentoDeColisao.x = 0;
                array[i].momentoDeColisao.y = 0;
                array[i].momentoDeColisao.z = 0;

                for (int j = 0; j < lenght; j++)
                {
                    if (i == j) continue;

                    
                     distance = new Vector2(array[i].entidade.EntPos.x - array[j].entidade.EntPos.x, array[i].entidade.EntPos.y - array[j].entidade.EntPos.y);

                     safeDist.x = (array[i].tamanho.x + array[j].tamanho.x) / 2.0f;
                     safeDist.y = (array[i].tamanho.y + array[j].tamanho.y) / 2.0f;

                    float hor = Math.Abs(distance.x);
                    float ver = Math.Abs(distance.y);

                    if (hor > safeDist.x || ver > safeDist.y) continue;

                    if (array[i].entidade.Nome == "Tust") Engine.Debug("Player: "+array[i].entidade.EntPos.ToString()+", Opera: "+array[j].entidade.EntPos.ToString()+"Safe: "+safeDist.ToString()+", Distance: "+distance.ToString());
                    
                    if (array[i].entidade.EntPos.x > array[j].entidade.EntPos.x) array[i].momentoDeColisao.z = -1;
                    if (array[i].entidade.EntPos.x < array[j].entidade.EntPos.x) array[i].momentoDeColisao.x = -1;                   
                    if (array[i].entidade.EntPos.y > array[j].entidade.EntPos.y) array[i].momentoDeColisao.w = -1;
                    if (array[i].entidade.EntPos.y < array[j].entidade.EntPos.y) array[i].momentoDeColisao.y = -1;
                    array[i].OnColide(array[j]);

                }
            }
        }
    }
}
