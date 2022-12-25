using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
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

        private bool IsNumeric(string txt, out int num)
        {
            return int.TryParse(txt, out num);
        }
        private void Btn_AddEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (txt == "" || !IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = Insert(x, num);
            textBox1.Text = "";
            var str = PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
        }
        
        private void Btn_RemoveEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (txt == "" || !IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = Remove(x, num);


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
            if (txt == "" || !IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = FillRandom(x, num);
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