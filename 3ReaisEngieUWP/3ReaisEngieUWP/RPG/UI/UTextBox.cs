using _3ReaisEngine.Core;
using _3ReaisEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class UTextBox : UIEntidade
    {
        public delegate void OnTextChange(UTextBox sender, string text);

        TextBox txb = new TextBox();

        public float fontSize { get => (float)txb.FontSize; set => txb.FontSize = value; }

        public HorizontalAlignment horizontalAlignment { get => txb.HorizontalAlignment; set => txb.HorizontalAlignment = value; }
        public VerticalAlignment verticalAlignment { get => txb.VerticalAlignment; set => txb.VerticalAlignment = value; }

        public TextAlignment textAlignment { get => txb.HorizontalTextAlignment; set => txb.HorizontalTextAlignment = value; }
        public TextWrapping textWrapping { get => txb.TextWrapping; set => txb.TextWrapping = value; }



        public float maxHeight { get => (float)txb.MaxHeight; set => txb.MaxHeight = value; }
        public int maxLenght { get => txb.MaxLength; set => txb.MaxLength = value; }
        public string text { get => txb.Text; set => txb.Text = value; }

        public OnTextChange onTextChange;

    void start()
        {
        txb.HorizontalAlignment = HorizontalAlignment.Right;
        txb.VerticalAlignment = VerticalAlignment.Top;
        txb.HorizontalTextAlignment = TextAlignment.Right;
        txb.TextWrapping = TextWrapping.Wrap;
        txb.MaxHeight = 50;
        txb.MaxLength = 100;
        txb.Text = "";

        element = txb;
        txb.Foreground = new SolidColorBrush(Colors.White); ;
        txb.HorizontalAlignment = HorizontalAlignment.Left;
        txb.VerticalAlignment = VerticalAlignment.Top;
        txb.RenderTransform = new TranslateTransform();
        frameworkElement = (FrameworkElement)element;
        txb.TextChanged += Txb_TextChanged;
        
        }

        private void Txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            onTextChange?.Invoke(this, txb.Text);
        }

    public UTextBox()
        {
            start();
        txb.Width = 100;
        txb.Height = 50;
        transform.X = 100;
        transform.Y = 100;
        txb.Header = "Notes";
        txb.PlaceholderText = "Type your notes here";
        this.position = new Vector2(0, 0);
        this.size = new Vector2(100, 50);
        }
        public UTextBox(string header,string placeholder)
        {
            start();
            txb.Width = 100;
            txb.Height = 50;
            transform.X = 100;
            transform.Y = 100;
            txb.Header = header;
            txb.PlaceholderText = placeholder;
            this.position = new Vector2(0, 0);
            this.size = new Vector2(100, 50);
        }
        public UTextBox(string placeholder,Vector2 pos)
        {
            start();
            txb.Width = 100;
            txb.Height = 50;
            transform.X = 100;
            transform.Y = 100;
            txb.Header = "Header";
            txb.PlaceholderText = placeholder;
            this.position = pos;
            this.size = new Vector2(100, 50);
        }
        public UTextBox(string placeholder, Vector2 pos,Vector2 size)
        {
            start();
            
            txb.Width = 100;
            txb.Height = 50;
            transform.X = 100;
            transform.Y = 100;
            txb.Header = "Header";
            txb.PlaceholderText = placeholder;
            this.position = pos;
            this.size = size;
        }
}

