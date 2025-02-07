using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    static class DesignText
    {
        static public void DT(string input , int num)
        {
            //num(띄어쓰기 량)
            int length = num / 2;
            int left = num % 2; //짝수인지

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("┃");
            for(int i = 0; i < length; i++) //중앙 정령
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(input);
            for (int i = 0; i < length + left; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("┃");

            Console.ResetColor();
        }
    }
}
