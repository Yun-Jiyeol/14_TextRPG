using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    internal class GameManager
    {
        public void Start()
        {
            Console.WriteLine("1. 상태보기");
            Console.WriteLine();
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("4. 전투시작");
            Console.WriteLine();
            Console.WriteLine("5. 퀘스트");
            Console.WriteLine();
            Console.WriteLine("0. 게임 종료");
            Console.WriteLine();

            int input = Input(5);
            switch (input)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    //Player.State();
                    break;
                case 2:
                    //Item
                    break;
                case 3:
                    //Store
                    break;
                case 4:
                    //Battle
                    break;
                case 5:
                    //Quest
                    break;
            }
        }

        public int Input(int i) //0-i까지의 숫자를 입력 이외에는 "잘못된 입력입니다."
        {
            while (true)
            {
                Console.Write("입력 : ");
                string Pinput = Console.ReadLine();
                int numinput;

                if (int.TryParse(Pinput, out numinput)) //Pinput => int | 1. true | 2. out numinput = int.Parse(Pinput)
                {
                    if (numinput >= 0 && numinput <= i)
                    {
                        return numinput;
                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
