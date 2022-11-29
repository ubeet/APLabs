using System;
using System.Collections.Generic;
using System.IO;
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
using Lab3PA.Tree;
using static Lab3PA.Tree.AVLTree;

namespace Lab3PA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Node? x;
        public MainWindow()
        {
            InitializeComponent();
            var elGeom = new EllipseGeometry(new Point(50,50), 45, 20);
        }
        private void Btn_AddEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (txt != "")
                x = Insert(x, Convert.ToInt32(txt));
            textBox1.Text = "";
            var str = PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
        }
        
        private void Btn_RemoveEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (txt != "")
                x = Remove(x, Convert.ToInt32(txt));
            
        }
        string path = Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + "/tree.txt";
        private void Btn_SaveTree(object sender, RoutedEventArgs e)
        {
            var sw = new StreamWriter(path);
            SaveTree(x, sw);
            sw.Close();
        }

        private void Btn_FillRandom(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (txt != "")
                x = FillRandom(x, Convert.ToInt32(txt));
            textBox1.Text = "";
            var str = PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
        }
        
        private void Btn_ReadTree(object sender, RoutedEventArgs e)
        {
            var sr = new StreamReader(path);
            x = ReadTree(x, sr);
            var str = PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
            sr.Close();
        }
    }
}