using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.Components
{
    [RequerComponente(typeof(Render))]
    ///<summary>
    /// Componente que gerencia as animações de uma entidade
    /// Requer componente Render para poder renderizar as animações
    /// </summary>
    public class Animacao:Componente<Animacao>
    {
       
        Dictionary<string, BitmapImage> animations = new Dictionary<string, BitmapImage>();

        /// <summary>
        /// Adiciona um gif na lista de animaçoes
        /// </summary>
        /// <param name="Nome"> Nome por qual o componente irá reconhecer o gif </param>
        /// <param name="animPath"> Caminho onde o gif está localizado no sistema de arquivos </param>
        public void AddAnimation(string Nome,string animPath)
        {
            BitmapImage source = new BitmapImage(new Uri("ms-appx:"+animPath));
            if (!animations.ContainsKey(Nome) && source != null)
            {
                animations.Add(Nome, source);
            }
        }
        /// <summary>
        /// Remove um gif da lista de animações
        /// </summary>
        /// <param name="Nome"> Nome do gif a ser removido</param>
        /// <param name="anim"></param>
        public void RemoveAnimation(string Nome, BitmapImage anim)
        {
            if (animations.ContainsKey(Nome) && anim != null)
            {
                animations.Remove(Nome);
            }
        }
        /// <summary>
        /// Inicia uma animação
        /// </summary>
        /// <param name="Nome"> Nome da animação a ser reproduzida</param>
        /// <param name="render"> Qual renderizador irá reproduzi-la</param>
        public void Play(string Nome,Render render)
        {
            if (animations.ContainsKey(Nome))
            {
                render.img.Source = animations[Nome];
            }
        }
        /// <summary>
        /// Inicia uma animação nesta entidade
        /// </summary>
        /// <param name="Nome"> Nome da animação a ser reproduzida</param>
        public void Play(string Nome)
        {
            Render render = entidade.GetComponente<Render>();
            if (animations.ContainsKey(Nome))
            {
                render.img.Source = animations[Nome];
            }
        }
    }
}
