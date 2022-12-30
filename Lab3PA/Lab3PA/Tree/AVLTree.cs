using System;
using System.IO;

namespace Lab3PA.Tree;

public class AVLTree
{
    private int Height(Node? node)
    {
        return node?.height ?? 0;
    }

    private int BalanceFactor(Node? node)
    {
        return Height(node.nodeR) - Height(node.nodeL);
    }

    private void FixHeight(Node? node)
    {
        var hL = Height(node.nodeL);
        var hR = Height(node.nodeR);
        node.height = (hL > hR ? hL : hR) + 1;
    }

    private Node? RotateRight(Node? node)
    {
        var s = node.nodeL;
        node.nodeL = s.nodeR;
        s.nodeR = node;
        FixHeight(node);
        FixHeight(s);
        
        return s;
    }

    private Node? RotateLeft(Node? node)
    {
        var s = node.nodeR;
        node.nodeR = s.nodeL;
        s.nodeL = node;
        FixHeight(node);
        FixHeight(s);
        
        return s;
    }

    private Node? Balance(Node? node)
    {
        FixHeight(node);
        if(BalanceFactor(node) == 2)
        {
            if(BalanceFactor(node.nodeR) < 0)
                node.nodeR = RotateRight(node.nodeR);
            return RotateLeft(node);
        }

        if (BalanceFactor(node) != -2) return node;
        if(BalanceFactor(node.nodeL) > 0)
            node.nodeL = RotateLeft(node.nodeL);
        return RotateRight(node);
    }

    public Node? Insert(Node? node, int key)
    {
        if (node == null) return new Node(key);
        if (key < node.key)
            node.nodeL = Insert(node.nodeL, key);
        else
            node.nodeR = Insert(node.nodeR, key);
        return Balance(node);
    }

    private Node? FindMin(Node? node)
    {
        return node.nodeL != null ? FindMin(node.nodeL) : node;
    }

    private Node? RemoveMin(Node? node)
    {
        if (node.nodeL == null)
            return node.nodeR;
        node.nodeL = RemoveMin(node.nodeL);
        return Balance(node);
    }

    public Node? FillRandom(Node? x, int? num)
    {
        var rnd = new Random();
        for (int i = 0; i < num; i++)
            x = Insert(x, rnd.Next(10000));

        return x;
    }

    public Node? Remove(Node? node, int key)
    {
        if (node == null) return null;
        
        if (key < node.key)
            node.nodeL = Remove(node.nodeL, key);
        
        else if (key > node.key)
            node.nodeR = Remove(node.nodeR, key);
        
        else
        {
            var l = node.nodeL;
            var r = node.nodeR;
            
            if (r == null) return l;
            
            var min = FindMin(r);
            min.nodeR = RemoveMin(r);
            min.nodeL = l;
            
            return Balance(min);
        }

        return Balance(node);
    }
    
    public string PrintTree(Node root, int space, int height, string dir) {
        if (root == null) {
            return null;
        }

        var ss = "";
        space += height;
        ss += PrintTree(root.nodeR, space - 2, height, "right");
        if (dir.Equals("main"))
        {
            ss += "\n";
            ss += (new string(' ', (space) * 2 - 4));
            ss += (root.key);
            ss += "\n";
        }
        else
        {
            ss += "\n";
            ss += (new string(' ', (space - height) * 2));
            if (dir.Equals("right")) ss += ("┌");
            if(dir.Equals("left")) ss += ("└");
            ss += (new string('-', height - 1));
            ss += (root.key);
            ss += "\n";
        }
        ss += PrintTree(root.nodeL, space - 2, height, "left");
        return ss;
    }
    

    public void SaveTree(Node node, StreamWriter sw)
    {
        if (node == null) sw.WriteLine("#");
        
        else
        {
            sw.WriteLine(node.key);
            sw.WriteLine(node.height);
            
            SaveTree(node.nodeL, sw);
            SaveTree(node.nodeR, sw);
        }
    }

    public Node? ReadTree(Node node, StreamReader sr)
    {
        if (sr.EndOfStream)
        {
            return null;
        }
        var el = sr.ReadLine();
        Console.WriteLine(el);
        if (el.Equals("#") || el.Equals("")) return null;
        var height = sr.ReadLine();
        node = new Node(int.Parse(el), int.Parse(height));
        node.nodeL = ReadTree(node.nodeL, sr);
        node.nodeR = ReadTree(node.nodeR, sr);
        Console.WriteLine(node.key);
        return node;
    }
    
    
}
