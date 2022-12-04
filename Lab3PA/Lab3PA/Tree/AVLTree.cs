using System;
using System.IO;

namespace Lab3PA.Tree;

public static class AVLTree
{
    public static int Height(Node? node)
    {
        return node?.height ?? 0;
    }

    public static int BalanceFactor(Node? node)
    {
        return Height(node.nodeR) - Height(node.nodeL);
    }

    public static void FixHeight(Node? node)
    {
        var hL = Height(node.nodeL);
        var hR = Height(node.nodeR);
        node.height = (hL > hR ? hL : hR) + 1;
    }

    public static Node? RotateRight(Node? node)
    {
        var s = node.nodeL;
        node.nodeL = s.nodeR;
        s.nodeR = node;
        FixHeight(node);
        FixHeight(s);
        return s;
    }
    
    public static Node? RotateLeft(Node? node)
    {
        var s = node.nodeR;
        node.nodeR = s.nodeL;
        s.nodeL = node;
        FixHeight(node);
        FixHeight(s);
        return s;
    }
    
    public static Node? Balance(Node? node)
    {
        FixHeight(node);
        if(BalanceFactor(node) == 2)
        {
            if(BalanceFactor(node.nodeR) < 0)
                node.nodeR = RotateRight(node.nodeR);
            return RotateLeft(node);
        }
        if(BalanceFactor(node) == -2)
        {
            if(BalanceFactor(node.nodeL) > 0)
                node.nodeL = RotateLeft(node.nodeL);
            return RotateRight(node);
        }
        return node;
    }

    public static Node? Insert(Node? node, int key)
    {
        if (node == null) return new Node(key);
        if (key < node.key)
            node.nodeL = Insert(node.nodeL, key);
        else
            node.nodeR = Insert(node.nodeR, key);
        return Balance(node);
    }

    public static Node? FindMin(Node? node)
    {
        return node.nodeL != null ? FindMin(node.nodeL) : node;
    }

    public static Node? RemoveMin(Node? node)
    {
        if (node.nodeL == null)
            return node.nodeR;
        node.nodeL = RemoveMin(node.nodeL);
        return Balance(node);
    }

    public static Node? FillRandom(Node? x, int? num)
    {
        var rnd = new Random();
        for (int i = 0; i < num; i++)
        {
            x = Insert(x, rnd.Next(10000));
        }

        return x;
    }

    public static Node? Remove(Node? node, int key)
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
    
    public static string PrintTree(Node root, int space, int height, string dir) {
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
    

    public static void SaveTree(Node node, StreamWriter sw)
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

    public static Node? ReadTree(Node node, StreamReader sr)
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
