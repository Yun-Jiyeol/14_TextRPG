﻿using System;
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
                DesignText.LeftDT($"  1. EASY 던전 {P.repeat[0]}층 입장", 12, ConsoleColor.Gray);
                DesignText.LeftDT($"  2. NORMAL 던전 {P.repeat[1]}층 입장", 13, ConsoleColor.Gray);
                if(P.Level >= 3)
                {
                    DesignText.LeftDT("     -입장 가능합니다", 14, ConsoleColor.Green);
                }
                else
                {
                    DesignText.LeftDT("     - 3레벨 부터 입장 가능합니다", 14, ConsoleColor.DarkGray);
                }
                DesignText.LeftDT($"  3. HARD 던전 {P.repeat[2]}층 입장", 15, ConsoleColor.Gray);
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
                        DesignText.IsMove(10);
                        EasyDuguen(P);
                        break;
                    case 2:
                        if (P.Level >= 3)
                        {
                            Console.WriteLine($"{P.Name}은(는) NORMAL 던전에 입장합니다.");
                            isgoHome = true;
                            DesignText.IsMove(10);
                            //monsters = battle.SpawnMons(6, 12); //랜덤 몬스터 소환
                            
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
                            DesignText.IsMove(10);
                            //monsters = battle.SpawnMons(12, 18); //랜덤 몬스터 소환
                            
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
        public void EasyDuguen(Player P)
        {
            int floor = 1;
            int maxfloor = 3;
            bool isdunguen = true;

            while (isdunguen)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("EASY 던전", 31, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("던전 클리어를 위한", 22, ConsoleColor.Gray);
                DesignText.MiddleDT("전략을 구상하세요", 23, ConsoleColor.Gray);
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
                DesignText.LeftDT($"  1. 다음 몬스터 처치 - {maxfloor - floor + 1}남음", 12, ConsoleColor.Gray);
                DesignText.LeftDT("  2. 상태확인", 13, ConsoleColor.Gray);
                //DesignText.LeftDT("  3. 스킬확인", 14, ConsoleColor.Gray);
                //DesignText.LeftDT("  4. 인벤토리", 15, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //사용시 줄 삭제
                DesignText.LeftDT("  3. 퀘스트 확인", 16, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 마을로 귀환", 17, ConsoleColor.Red);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
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
                        isdunguen = false;
                        DesignText.IsMove(5);
                        break;
                    case 1:
                        List<Monster> monsters = new List<Monster>(); //소환할 몬스터를 저장하는 함수
                        bool isalldead = true; //몬스터를 다 잡고 나왔는지 확인할 함수(층수용)
                        if(floor == maxfloor)
                        {
                            monsters = battle.SpawnMons(5, 6); //보스 몬스터 소환
                        }
                        else
                        {
                            monsters = battle.SpawnMons(0, 5); //랜덤 몬스터 소환
                        }

                        turn.PlayerTurn(P, monsters); //전투 시작
                        isalldead = true;
                        foreach (Monster monster in monsters)
                        {
                            if (!monster.isDead) //모든 몬스터가 죽지 않았다면
                            {
                                isalldead = false;
                            }
                        }
                        if (isalldead) //모든 몬스터를 잡았다면 층수 올리기
                        {
                            if(floor == maxfloor)
                            {
                                Console.SetCursorPosition(0,22);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"{P.Name}은(는) 마을로 귀환중입니다.");
                                P.repeat[0]++;
                                isdunguen = false;
                                DesignText.IsMove(10);
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 22);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"{P.Name}은(는) 다음 전투를 준비합니다.");
                                floor++;
                                DesignText.IsMove(10);
                            }
                        }
                        else //아닐 시(도망) 마을로
                        {
                            isdunguen = false;
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }
    }
}
