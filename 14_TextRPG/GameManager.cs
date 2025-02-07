using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class GameManager
    {
        Dunguen dunguen = new Dunguen();
        Player P = new Player();

        public void Start()
        {
            P.Level = 10;
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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                switch (input)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("게임을 종료합니다!");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("플레이어은(는) 자신의 상태를 점검합니다."); //Console.Write($"{Player.Name}은(는) 자신의 상태를 점검합니다");
                        DesignText.IsMove();
                        //Player.State();
                        break;
                    case 2:
                        Console.WriteLine("플레이어은(는) 자신의 아이템을 확인합니다."); //Console.Write($"{Player.Name}은(는) 자신의 아이템을 확인합니다");
                        DesignText.IsMove();
                        //Item
                        break;
                    case 3:
                        Console.WriteLine("플레이어은(는) 상점은 찾아 들어가봅니다"); //Console.Write($"{Player.Name}은(는) 상점은 찾아 들어가봅니다");
                        DesignText.IsMove();
                        //Store
                        break;
                    case 4:
                        Console.WriteLine("플레이어은(는) 던전을 찾아 들어가봅니다"); //Console.Write($"{Player.Name}은(는) 던전을 찾아 들어가봅니다");
                        DesignText.IsMove();
                        dunguen.GoDunguen(P); //던전으로 이동
                        //Battle
                        break;
                    case 5:
                        Console.WriteLine("플레이어은(는) 의뢰서 뭉치를 찾아봅니다"); //Console.Write($"{Player.Name}은(는) 의뢰서 뭉치를 찾아봅니다");
                        DesignText.IsMove();
                        //Quest
                        break;
                }
            }
        }
    }
}
