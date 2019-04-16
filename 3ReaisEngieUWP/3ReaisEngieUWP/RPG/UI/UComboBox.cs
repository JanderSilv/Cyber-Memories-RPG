
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
    
    public class UComboBox:IUIEntidade
    {

        uwpUI.ComboBox element = new uwpUI.ComboBox();
        TranslateTransform transform = new TranslateTransform();
        
        private Vector2 pos = new Vector2(), si = new Vector2(100, 50);
        public Vector2 position { get { return pos; } set { pos = value; transform.X = value.x; transform.Y = value.y; } }
        public Vector2 size { get { return si; } set { si = value; element.Width = value.x; element.Height = value.y; } }
        public string Nome;
        public UIElement getElement()
        {
            return element;
        }
        public Vector2 getPosition()
        {
            return pos;
        }
        public Vector2 getSize()
        {
            return si;
        }
        public Execute Action;

        public UComboBox(Execute Action = null)
        {
            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = 0;
            transform.Y = 0;

            element.RenderTransform = transform;

            this.Action = Action;
            element.SelectionChanged += act;

        }
        public UComboBox(Vector2 position, Execute Action = null)
        {
       
            element.Width = 100;
            element.Height = 50;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;

            element.RenderTransform = transform;
            element.SelectionChanged += act;
            this.Action = Action;
        }
        public UComboBox(Vector2 position, Vector2 size, Execute Action = null)
        {
            element.Width = size.x;
            element.Height = size.y;

            element.HorizontalAlignment = HorizontalAlignment.Left;
            element.VerticalAlignment = VerticalAlignment.Top;

            transform.X = position.x;
            transform.Y = position.y;

            pos = position;
            si = size;

            element.RenderTransform = transform;
            element.SelectionChanged += act;
            this.Action = Action;
        }


        public void AddItem(object item)
        {
            ComboBoxItem cbbItem = new ComboBoxItem();
            //cbbItem.Content = item.getName();
           //cbbItem.
            element.Items.Add(item);
            
        }

        public int Selected()
        {
            return element.SelectedIndex;
        }
        public object SelectedElement()
        {
            return element.SelectedItem;
        }

        private void act(object sender, RoutedEventArgs e)
        {
            Action?.Invoke(this);
        }
        public string getName()
        {
            return Nome;
        }
    }
}
