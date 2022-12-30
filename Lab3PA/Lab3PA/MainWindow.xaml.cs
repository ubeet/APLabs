using System;
using System.IO;
using System.Windows;
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
        private AVLTree tree = new AVLTree();
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsNumeric(string txt, out int num)
        {
            return int.TryParse(txt, out num);
        }
        private void Btn_AddEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (!IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = tree.Insert(x, num);
            textBox1.Text = "";
            var str = tree.PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
        }
        
        private void Btn_RemoveEl(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (!IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = tree.Remove(x, num);
            var str = tree.PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;


        }
        string path = Directory
            .GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory)
                    .ToString())
                .ToString()) + "/tree.txt";
        private void Btn_SaveTree(object sender, RoutedEventArgs e)
        {
            var sw = new StreamWriter(path);
            tree.SaveTree(x, sw);
            sw.Close();
        }

        private void Btn_FillRandom(object sender, RoutedEventArgs e)
        {
            var txt = textBox1.Text;
            if (!IsNumeric(txt, out var num))
            {
                textBox1.Text = "";
                return;
            }
            x = tree.FillRandom(x, num);
            textBox1.Text = "";
            var str = tree.PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
        }
        
        private void Btn_ReadTree(object sender, RoutedEventArgs e)
        {
            var sr = new StreamReader(path);
            x = tree.ReadTree(x, sr);
            var str = tree.PrintTree(x, 10, 10, "main");
            textBlock1.Text = str;
            sr.Close();
        }
    }
}