using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    internal class Dunguen
    {
        Battle battle = new Battle();
        Turn turn = new Turn();
        public void GoDunguen(Player P, Inven inven, QuestManager quest)
        {
            bool isgoHome = false;

            while (!isgoHome)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("여기는 던전 입구입니다.", 17, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("어느 던전에 입장을 할 것인지", 12, ConsoleColor.Gray);
                DesignText.MiddleDT("선택하세요.", 29, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┣━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┫");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("  1. EASY 던전 입장", 12, ConsoleColor.Gray);
                DesignText.LeftDT("  2. NORMAL 던전 입장", 13, ConsoleColor.Gray);
                if(P.Level >= 3)
                {
                    DesignText.LeftDT("     -입장 가능합니다", 14, ConsoleColor.Green);
                }
                else
                {
                    DesignText.LeftDT("     - 3레벨 부터 입장 가능합니다", 14, ConsoleColor.DarkGray);
                }
                DesignText.LeftDT("  3. HARD 던전 입장", 15, ConsoleColor.Gray);
                if (P.Level >= 7)
                {
                    DesignText.LeftDT("     -입장 가능합니다", 16, ConsoleColor.Green);
                }
                else
                {
                    DesignText.LeftDT("     - 7레벨 부터 입장 가능합니다", 16, ConsoleColor.DarkGray);
                }
                DesignText.LeftDT("  4. 인벤토리", 17, ConsoleColor.Gray);
                DesignText.LeftDT("  5. 퀘스트 확인", 18, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 마을로 귀환", 19, ConsoleColor.Blue);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┗━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┛");
                Console.ResetColor();

                Console.WriteLine();
                int input = Input.input(0, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();

                switch (input)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{P.Name}은(는) 마을로 귀환중입니다.");
                        isgoHome = true;
                        DesignText.IsMove(5);
                        break;
                    case 1:
                        Console.WriteLine($"{P.Name}은(는) EASY 던전에 입장합니다.");
                        isgoHome = true;
                        DesignText.IsMove(5);
                        turn.PlayerTurn(P, battle.SpawnMons(0,6));
                        break;
                    case 2:
                        if (P.Level >= 3)
                        {
                            Console.WriteLine($"{P.Name}은(는) NORMAL 던전에 입장합니다.");
                            isgoHome = true;
                            DesignText.IsMove(5);
                            turn.PlayerTurn(P, battle.SpawnMons(6, 12));
                            //Battle.NORMAL
                        }
                        else
                        {
                            Console.WriteLine($"{P.Name}은(는) 실력 부족으로 거절 당했습니다.");
                            DesignText.IsMove(5);
                        }
                        break;
                    case 3:
                        if (P.Level >= 7)
                        {
                            Console.WriteLine($"{P.Name}은(는) HARD 던전에 입장합니다.");
                            isgoHome = true;
                            DesignText.IsMove(5);
                            turn.PlayerTurn(P, battle.SpawnMons(12, 18));
                            //Battle.Hard
                        }
                        else
                        {
                            Console.WriteLine($"{P.Name}은(는) 실력 부족으로 거절 당했습니다.");
                            DesignText.IsMove(5);
                        }
                        break;
                    case 4:
                        Console.WriteLine($"{P.Name}은(는) 자신의 아이템을 확인합니다.");
                        DesignText.IsMove(5);
                        //Item
                        break;
                    case 5:
                        Console.WriteLine($"{P.Name}은(는) 받은 의뢰서 뭉치를 찾아봅니다");
                        DesignText.IsMove(5);
                        //Quest
                        break;
                }
            }
        }
    }
}
