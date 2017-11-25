using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigener
{
    class Program
    {
        static void Main(string[] args)
        {
            do  
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.CursorLeft = 0;
                Console.Write("Press 'E' for Encryption and 'D' for Decoding\n");
                Console.ResetColor();
                char a = (char)Console.ReadKey().Key;
                if (a == 'E')
                {
                    Console.Clear();
                    Console.CursorLeft = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter the Key...");
                    Console.ResetColor();
                    string key1 = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter the Text For Encryption...");
                    Console.ResetColor();
                    string text1 = Console.ReadLine();
                    ShowMatrix(ViginerMatrix());
                    Console.WriteLine(text1);
                    Console.WriteLine(NewKey(key1, text1));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Encrypted text is...");
                    Console.ResetColor();
                    Console.WriteLine(ViginerEncryption(key1, text1).ToLower());
                }
                else if (a == 'D')
                {
                    Console.Clear();
                    Console.CursorLeft = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter the Key...");
                    Console.ResetColor();
                    string key2 = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter the Text For Decoding...");
                    Console.ResetColor();
                    string text2 = Console.ReadLine();
                    ShowMatrix(ViginerMatrix());
                    Console.WriteLine(text2);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Decoded text is...");
                    Console.ResetColor();
                    Console.WriteLine(ViginerDecoding(key2, text2).ToLower());
                }
                else
                {
                    Console.CursorLeft = 0;
                    Console.WriteLine("You have pressed wrong symbol!");
                }
                Console.CursorLeft = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Press 'Y' to Continue\n");
                Console.ResetColor();
            } while (Console.ReadKey().Key == ConsoleKey.Y);
        }

        public static char[,] ViginerMatrix()
        {
            char[,] matrix = new char[26, 26];
            char[] alp = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int nextRow;
            for (int i = 0; i < alp.Length; i++)
            {
                for (int j = 0; j < alp.Length; j++)
                {
                    nextRow = i + j;
                    if (nextRow >= alp.Length)
                    {
                        nextRow -= alp.Length;
                    }
                    matrix[i, j] = alp[nextRow];
                }
            }
            return matrix;
        }

        public static void ShowMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == 0 || i == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(matrix[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string NewKey(string key, string text)
        {
            string newKey = null;
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    continue;
                while (j >= key.Length)
                {
                    j -= key.Length;
                }
                if (key[j] == ' ')
                    j++;
                newKey += key[j++];
            }
            return newKey;
        }

        public static string NewText(string key, string text)
        {
            string newText = null;
            string newKey = NewKey(key, text);
            string WidthoutSpace = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    continue;
                WidthoutSpace += text[i];
            }
            for (int i = 0; i < newKey.Length; i++)
            {
                newText += WidthoutSpace[i];
                newText += newKey[i];
            }
            return newText;
        }

        public static string ViginerEncryption(string key, string textInput)
        {
            string newText = null;
            string text = NewText(key, textInput).ToUpper();
            char[,] matrix = ViginerMatrix();
            for (int k = 0; k < text.Length - 1; k++)
            {
                char first = text[k];
                char second = text[++k];
                int firstIndex = 0;
                int secondIndex = 0;
                char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == first)
                        secondIndex = i;
                    if (alphabet[i] == second)
                        firstIndex = i;
                }
                newText += matrix[secondIndex, firstIndex];
            }
            return newText;
        }

        public static string ViginerDecoding(string key, string textInput)
        {
            string newText = null;
            string text = NewText(key, textInput).ToUpper();
            char[,] matrix = ViginerMatrix();
            for (int k = 0; k < text.Length - 1; k++)
            {
                char first = text[k];
                char second = text[++k];
                int firstIndex = 0;
                int secondIndex = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, 0] == second)
                        {
                            firstIndex = i;
                            if (matrix[firstIndex, j] == first)
                                secondIndex = j;
                        }
                        else

                            break;
                    }
                }
                newText += matrix[0, secondIndex];
            }
            return newText;
        }
    }
}
