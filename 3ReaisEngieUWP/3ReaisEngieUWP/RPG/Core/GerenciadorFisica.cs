using _3ReaisEngine.Components;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _3ReaisEngine.Core
{
    public class GerenciadorFisica
    {
       
        float GetAngle(Vector2 a,Vector2 b, Vector2 eixo)
        {
            float d = Engine.Distance(a, b);
            float h = 0;
            float sin;
            if(eixo.x != 0)
            {
                h = Math.Abs(a.y - b.y);
            }
            if (eixo.y != 0)
            {
                h = Math.Abs(a.x - b.x);
            }

            sin = h / d;

            return (float)(Math.Asin(sin)*(180.0f/Math.PI));
        }
        
        public void UpdateColisions(Colisao[] array)
        {
            int lenght = array.Length;
            Vector2 distance;
            Vector2 safeDist = Vector2.Zero;
            float angleCol;
            Vector2 dir;

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


                    distance = Engine.DistanceVec(array[i].entidade.EntPos, array[j].entidade.EntPos);
                    safeDist.x = (array[i].tamanho.x + array[j].tamanho.x) / 2.0f;
                    safeDist.y = (array[i].tamanho.y + array[j].tamanho.y) / 2.0f;

                  
                    if (distance.x > safeDist.x || distance.y > safeDist.y) continue;

                    angleCol = GetAngle(array[i].entidade.EntPos, array[j].entidade.EntPos, new Vector2(1, 0));
                    dir = (angleCol < GetAngle(array[i].entidade.EntPos, (array[i].entidade.EntPos + array[i].tamanho / 2.0f), Vector2.right) ? Vector2.right : Vector2.up);

                    if (array[i].entidade.EntPos.x > array[j].entidade.EntPos.x && dir == Vector2.right) array[i].momentoDeColisao.z = -1;
                    if (array[i].entidade.EntPos.x < array[j].entidade.EntPos.x && dir == Vector2.right) array[i].momentoDeColisao.x = -1;                   
                    if (array[i].entidade.EntPos.y > array[j].entidade.EntPos.y && dir == Vector2.up) array[i].momentoDeColisao.w = -1;
                    if (array[i].entidade.EntPos.y < array[j].entidade.EntPos.y && dir == Vector2.up) array[i].momentoDeColisao.y = -1;
                    array[i].OnColide(array[j]);

                }
            }
        }
    }
}
