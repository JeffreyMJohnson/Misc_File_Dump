using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BitmapImage img = new BitmapImage(new Uri("C:\\Users\\Jeff\\Documents\\Visual Studio 2013\\Projects\\Hello World\\WpfApplication1\\bin\\Debug\\platform_short.png"));
            /*"C:\\Users\\Jeff\\Documents\\Visual Studio 2013\\Projects\\Hello World\\WpfApplication1\\bin\\Debug\\smurf_sprite.png"*/
            imageContainer.Source = img;

            Bitmap b = new Bitmap("platform_short.png");
            string text = "";
            for (int x = 0; x < b.Width; x++)
            {
                for (int y = 0; y < b.Height; y++)
                {
                    System.Drawing.Color pixel = b.GetPixel(x, y);
                    text += "(" + x + ", " + y + "): A:" + pixel.A + " R:" + pixel.R + " G:" + pixel.G + " B:" + pixel.B + "\n";

                }
            }
            txtBox.Text = text;
        }

        private void openFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.DefaultExt = ".png";
            dialog.Filter = "Image Files|*.png;*.bmp;*.jpg";

            //show the box
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                string[] fileNames = dialog.FileNames;
                string text = "";

                for (int i = 0; i < fileNames.Length; i++)
                {
                    text += fileNames[i] + "\n";
                }
                txtBox.Text = text;
            }
        }

        private void openFile_Drop(object sender, DragEventArgs e)
        {

            string[] filesList = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                filesList = (string[])e.Data.GetData(DataFormats.FileDrop);
            }
            string s = "";
            if (filesList != null)
            {
                for (int i = 0; i < filesList.Length; i++)
                {
                    s += filesList[i] + "\n";
                }
            }

            txtBox.Text = s;
        }

        private void ProcessNodeClick(object sender, RoutedEventArgs e)
        {
            rootNode.SelectAll();
        }

        private void rootNode_MouseDown(object sender, MouseButtonEventArgs e)
        {
             

        }

        private void rootNode_MouseUp(object sender, MouseButtonEventArgs e)
        {
rootNode.SelectAll();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("foo");
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            ItemCollection items = treeView.Items;
            items.Add(new TextBox {Text = "foo"});
        }
    }
}
