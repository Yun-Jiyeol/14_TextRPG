using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class GameManager
    {
        public void Start()
        {
            while (true)
            {
                Console.Clear(); 
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("1. 상태보기");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("         ┃");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("2. 인벤토리");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("         ┃");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("3. 상점");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("             ┃");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("4. 전투시작");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("         ┃");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("5. 퀘스트");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("           ┃");
                Console.Write("┃        ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("0. 게임 종료");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("        ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.WriteLine();

                Console.ResetColor();
                int input = Input.input(0, 5);
                switch (input)
                {
                    case 0:
                        Console.WriteLine("게임을 종료합니다!");
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
        }
    }
}
