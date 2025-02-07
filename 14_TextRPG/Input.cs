using System;
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
            while (true)
            {
                Console.Write("입력 : ");
                string Pinput = Console.ReadLine();
                int numinput;

                if (int.TryParse(Pinput, out numinput)) //Pinput => int | 1. true | 2. out numinput = int.Parse(Pinput)
                {
                    if (numinput >= min && numinput <= max) //min <= x <= max 까지의 정수값 입력을 받는다
                    {
                        return numinput;
                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
