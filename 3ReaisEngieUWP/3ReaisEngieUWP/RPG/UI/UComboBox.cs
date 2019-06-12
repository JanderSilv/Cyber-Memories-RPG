using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3ReaisEngine.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace _3ReaisEngine.UI
{
    using uwpUI = Windows.UI.Xaml.Controls;

    public class UComboBox : UIEntidade
    {

        ComboBox cbb = new ComboBox();

        public Execute Action;

        public void start()
        {
            cbb.HorizontalAlignment = HorizontalAlignment.Left;
            cbb.VerticalAlignment = VerticalAlignment.Top;
            cbb.RenderTransform = new TranslateTransform();
            Action = Action;
            cbb.SelectionChanged += act;
            element = cbb;
            frameworkElement = (FrameworkElement)element;
        }

        public UComboBox(Execute Action = null)
        {
            cbb.Width = 100;
            cbb.Height = 50;
            transform.X = 0;
            transform.Y = 0;
            start();
        }
        public UComboBox(Vector2 position, Execute Action = null)
        {

            cbb.Width = 100;
            cbb.Height = 50;
            transform.X = position.x;
            transform.Y = position.y;
            this.position = position;
            start();

        }
        public UComboBox(Vector2 position, Vector2 size, Execute Action = null)
        {
            start();
            cbb.Width = size.x;
            cbb.Height = size.y;
            transform.X = position.x;
            transform.Y = position.y;
            this.position = position;
            this.size = size;
           
        }


        public void AddItem(object item)
        {
            ComboBoxItem cbbItem = new ComboBoxItem();

            cbb.Items.Add(item);

        }

        public int Selected()
        {
            return cbb.SelectedIndex;
        }
        public object SelectedElement()
        {
            return cbb.SelectedItem;
        }

        private void act(object sender, RoutedEventArgs e)
        {
            Action?.Invoke(this);
        }

        public override void Resize(float x, float y)
        {
            cbb.Height = y;
            cbb.Width = x;
        }
    }
}