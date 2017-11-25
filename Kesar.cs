using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kesar
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Trvas Texty Gaxtnagrelu hamar sexmeq 1: \nGaxtnagrvas Texty vercanelu hamar sexmeq 2");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Clear();
                        Console.CursorLeft = 0;
                        Console.Write("text : ");
                        string s = Console.ReadLine();
                        Console.Write("key : ");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Gaxtnagrvas text : ");
                        KesarDecode(s, x);
                        break;
                    case 2:
                        Console.Clear();
                        Console.CursorLeft = 0;
                        Console.Write("text : ");
                        string s1 = Console.ReadLine();
                        Console.Write("key : ");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.Write("vercanvac text : ");
                        KesarEncryption(s1, x1);
                        break;
                }
            }
        }
        public static void KesarDecode(string s1, int key)
        {
            char[] c = new char[s1.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                if ((int)s1[i] - key < 97)
                    c[i] = (char)((int)s1[i] + 26 - key);
                else
                    c[i] = (char)((int)s1[i] - key);
                Console.Write(c[i]);
            }
            Console.WriteLine();
        }
        public static void KesarEncryption(string s1, int key)
        {
            char[] c = new char[s1.Length];
            for (int i = 0; i < s1.Length; i++)
            {
                if ((int)s1[i] + key > 122)
                    c[i] = (char)((int)s1[i] + key - 26);
                else
                    c[i] = (char)((int)s1[i] + key);
                Console.Write(c[i]);
            }
            Console.WriteLine();
        }

    }
}
