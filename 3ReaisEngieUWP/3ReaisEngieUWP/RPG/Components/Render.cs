using _3ReaisEngine.Attributes;
using _3ReaisEngine.Core;
using _3ReaisEngine.Events;
using _3ReaisEngine.RPG.Core;
using _3ReaisEngine.UI;
using Newtonsoft.Json;
using System;
using Windows.UI.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.Components
{
   /// <summary>
   /// Componente que renderiza a entidade na tela
   /// </summary>
    public class Render : Componente<Render>
    {
        [JsonIgnore]
        ///<summary>
        /// Classe Image fornecida pelo UWP
        /// </summary>
        public Image img { get; private set; }
        public int Layer = 0;
        /// <summary>
        /// Tamanho da imagem
        /// </summary>
        public Vector2 size { get => new Vector2((float)img.Width, (float)img.Height); set { img.Width = value.x; img.Height = value.y; } }
        [JsonIgnore]
        ///<summary>
        /// Organiza a posicao da imagem na tela, fornecido pelo UWP
        /// </summary>
        public TranslateTransform transform;
       

        public Render()
        {
            
            transform = new TranslateTransform();
            img = new Image();
            BitmapImage source = new BitmapImage(new Uri("ms-appx:/Assets/StoreLogo.png"));
            img.Source = source;
            img.PointerPressed += Img_PointerPressed;
            img.PointerReleased += Img_PointerReleased;
            source.Play();
            //img.Width = 100;
            //img.Height = 100;
            img.RenderTransform = transform;
        }
        /// <summary>
        /// Constroe o componente
        /// </summary>
        /// <param name="x"> Posicao horizontal no mapa </param>
        /// <param name="y"> Posicao vertical no mapa</param>
        public Render(float x, float y)
        {
            transform = new TranslateTransform();
            img = new Image();
            BitmapImage source = new BitmapImage(new Uri("ms-appx:/Assets/StoreLogo.png"));
            img.Source = source;
            img.PointerPressed += Img_PointerPressed;
            img.PointerReleased += Img_PointerReleased;
            source.Play();
            img.Width = 100;
            img.Height = 100;
            img.RenderTransform = transform;
            transform.X = x;
            transform.Y = y;
        }
        /// <summary>
        /// Constroe o componente carregando a imagem ou gif fornecida
        /// </summary>
        /// <param name="path"> Caminho da imagem a ser carregada</param>
        public Render(string path)
        {
            transform = new TranslateTransform();
            img = new Image();
            BitmapImage source = new BitmapImage(new Uri("ms-appx:" + path));
            img.Source = source;
            img.PointerPressed += Img_PointerPressed;
            img.PointerReleased += Img_PointerReleased;
            source.Play();
           // img.Width = 100;
           // img.Height = 100;
            img.RenderTransform = transform;
        }
        /// <summary>
        /// Constroe o componente carregando a imagem fornecida
        /// </summary>
        /// <param name="path"></param>
        /// <param name="x"> Posicao horizontal no mapa </param>
        /// <param name="y"> Posicao vertical no mapa</param>
        public Render(string path, float x, float y)
        {
            
            transform = new TranslateTransform();
            img = new Image();
            BitmapImage source = new BitmapImage(new Uri("ms-appx:" + path));
            img.Source = source;
            img.PointerPressed += Img_PointerPressed;
            img.PointerReleased += Img_PointerReleased;
            source.Play();
           // img.Width = 100;
           // img.Height = 100;
            img.RenderTransform = transform;
            transform.X = x;
            transform.Y = y;
        }
       
        private void Img_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PointerPoint ptrPt = e.GetCurrentPoint(img);
            MouseEvento me = new MouseEvento();
            me.Tipo = Modificador.ButtonDown;
            me.Modificador = e.KeyModifiers;
            me.Position = new Vector2((float)ptrPt.Position.X, (float)ptrPt.Position.Y);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                me.Botao = MouseButton.Left;
            }
            if (ptrPt.Properties.IsMiddleButtonPressed)
            {
                me.Botao = MouseButton.Scroll;
            }
            if (ptrPt.Properties.IsRightButtonPressed)
            {
                me.Botao = MouseButton.Right;
            }

            entidade.OnClick(me);
        }

        private void Img_PointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            PointerPoint ptrPt = e.GetCurrentPoint(img);
            MouseEvento me = new MouseEvento();
            me.Tipo = Modificador.ButtonUp;
            me.Modificador = e.KeyModifiers;
            me.Position = new Vector2((float)ptrPt.Position.X, (float)ptrPt.Position.Y);

            if (ptrPt.Properties.IsLeftButtonPressed)
            {
                me.Botao = MouseButton.Left;
            }
            if (ptrPt.Properties.IsMiddleButtonPressed)
            {
                me.Botao = MouseButton.Scroll;
            }
            if (ptrPt.Properties.IsRightButtonPressed)
            {
                me.Botao = MouseButton.Right;
            }

            entidade.OnClick(me);
        }
        /// <summary>
        /// Carrega uma imagem ou gif no componente
        /// </summary>
        /// <param name="path">Caminho do recurso</param>
        public void LoadImage(string path)
        {
            BitmapImage source = new BitmapImage(new Uri("ms-appx:" + path));
            img.Source = source;
            source.Play();
        }  


    }
}
