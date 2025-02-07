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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("여기는 당신의 마을입니다.", 15, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("던전에 입장하기 전 마을에서", 13, ConsoleColor.Gray);
                DesignText.MiddleDT("할 행동을 고르세요.", 21, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("┣━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("  1. 상태보기", 27, ConsoleColor.Gray);
                DesignText.LeftDT("  2. 인벤토리", 27, ConsoleColor.Gray);
                DesignText.LeftDT("  3. 상점", 31, ConsoleColor.Gray);
                DesignText.LeftDT("  4. 전투시작", 27, ConsoleColor.Gray);
                DesignText.LeftDT("  5. 퀘스트", 29, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 게임 종료", 26, ConsoleColor.Red);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.ResetColor();
                Console.WriteLine();

                int input = Input.input(0, 5);
                switch (input)
                {
                    case 0:
                        Console.WriteLine();
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
