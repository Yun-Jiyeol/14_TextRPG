using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _14_TextRPG
{
    static class DesignText //꾸미기용 클래스
    {
        static public void MiddleDT(string input , int num , ConsoleColor color) //중앙 정렬
        {
            //num(띄어쓰기 량)
            int length = num / 2;
            int left = num % 2; //짝수인지

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("┃");
            for(int i = 0; i < length; i++) //중앙 정령
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = color;
            Console.Write(input);
            for (int i = 0; i < length + left; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("┃");

            Console.ResetColor();
        }
        static public void LeftDT(string input, int num, ConsoleColor color) //좌측 정렬
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, num);
            Console.Write("┃");
            Console.ForegroundColor = color;
            Console.SetCursorPosition(1, num);
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(41, num);
            Console.WriteLine("┃");

            Console.ResetColor();
        }
        static public void RightDT(string input, int num, ConsoleColor color) //우측 정렬
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, num);
            Console.Write("┃");
            Console.ForegroundColor = color;
            Console.SetCursorPosition(1, num);
            Console.Write(input.PadLeft(32));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(41, num);
            Console.WriteLine("┃");

            Console.ResetColor();
        }
        static public void IsMove(int num) //플레이어 이동 시
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < num; i++)
            {
                Console.Write("■");
                Thread.Sleep(100);
            }
            Console.ResetColor();
        }

        //text를 char로 1나씩 입력받아 콘솔에 입력될 크기가 2칸짜리면 2칸, 1칸짜리는 1칸을 더해줘서 반환해주는 메서드
        static public int GetConsoleWidth(string text) 
        {
            int width = 0;
            foreach (char c in text)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter)
                    width += 2;
                else
                    width++;
            }
            return width;
        }
    }
}
