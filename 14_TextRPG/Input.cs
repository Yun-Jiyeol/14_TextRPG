﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    static class Input
    {
        static public int input(int min, int max) //0-i까지의 숫자를 입력 이외에는 "잘못된 입력입니다."
        {
            int i = 1;
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            while (true)
            {
                Console.SetCursorPosition(left, top);
                Console.Write("              ");
                Console.SetCursorPosition(left, top);
                Console.Write("입력 : ");
                string Pinput = Console.ReadLine();
                int numinput;
                
                if (int.TryParse(Pinput, out numinput)) //Pinput => int | 1. true | 2. out numinput = int.Parse(Pinput)
                {
                    if (numinput >= min && numinput <= max) //min <= x <= max 까지의 정수값 입력을 받는다
                    {
                        Console.SetCursorPosition(0, top + 1);
                        Console.WriteLine("                               ");
                        Console.SetCursorPosition(left, top);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(left, top);
                        return numinput;
                    }
                }
                Console.SetCursorPosition(0, top + 1);
                Console.WriteLine($"잘못 된 입력입니다({i})");
                i++;
            }
            
        }

    }
}
