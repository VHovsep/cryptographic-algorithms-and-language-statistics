using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parz_Poxarinum
{
    class Program
    {
        static string CheckText(string text)
        {
            string newText = "";
            string indexes = "";
            string chars = "";
            for (int i = 0; i < text.Length; i++)
            {
                foreach (char item in indexes)
                {
                    if (i == item)
                    {
                        i++;
                        break;
                    }
                }
                foreach (char item in chars)
                {
                    if (text[i] == item)
                    {
                        i++;
                        break;
                    }
                }
                newText += text[i];
                for (int j = i + 1; j < text.Length; j++)
                {
                    if (text[i] == text[j])
                    {
                        indexes += j;
                        chars += text[j];
                    }
                }
            }
            return newText;
        }

        public static string NewAlphabet(string text)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            return CheckText(text + alphabet);
        }

        public static string SimpleSubstitution(string textForCoding, string oldAlphabet, string newAlphabet)
        {
            string newText = "";
            for (int i = 0; i < textForCoding.Length; i++)
            {
                if (textForCoding[i] == ' ')
                    newText += ' ';
                else
                {
                    int oldCharIndex = oldAlphabet.IndexOf(textForCoding[i]);
                    newText += newAlphabet[oldCharIndex];
                }
            }
            return newText;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Enter Some Text For Key: ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            string text = Console.ReadLine();
            Console.WriteLine("\nNew Alphabet:\n" + NewAlphabet(CheckText(text)));

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("\nOld Alphabet:\n" + alphabet);
            while(true)
            { 
            int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nEnter Some Text For Coding: ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        string textForCoding = Console.ReadLine();
                        Console.WriteLine(SimpleSubstitution(textForCoding, alphabet, NewAlphabet(CheckText(text))));
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nEnter Some Text For Decoding: ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        string textForCoding1 = Console.ReadLine();
                        Console.WriteLine(SimpleSubstitution(textForCoding1, NewAlphabet(CheckText(text)), alphabet));
                        break;
                    default:
                        Console.WriteLine("Press 1(Coding) or 2(Decoding)");
                        break;
                }
            }
        }
    }
}
