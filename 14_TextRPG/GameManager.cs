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
        Inven inven = new Inven();
        Shop shop = new Shop();
        QuestManager quest = new QuestManager();


        public void Start()
        {
            // 게임 시작 시 플레이어 명 입력
            //while (true)
            //{
            //    Console.Write("플레이어의 이름을 입력해주세요 : ");
            //    P.Name = Console.ReadLine();

            //    if (P.Name == null || P.Name == String.Empty) //이름을 정확히 입력할 때 까지
            //    {
            //        Console.WriteLine("다시 입력해 주세요");
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
            //Console.WriteLine("\n플레이어의 이름은 {0}입니다.\n", P.Name);
            //Console.WriteLine("아무키나 입력하세요.....");
            //Console.ReadKey();

            while (true)
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
                DesignText.MiddleDT("여기는 당신의 마을입니다.", 15, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("던전에 입장하기 전 마을에서", 13, ConsoleColor.Gray);
                DesignText.MiddleDT("할 행동을 고르세요.", 21, ConsoleColor.Gray);
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
                DesignText.LeftDT("  1. 상태보기", 12, ConsoleColor.Gray);
                DesignText.LeftDT("  2. 인벤토리", 13, ConsoleColor.Gray);
                DesignText.LeftDT("  3. 상점", 14, ConsoleColor.Gray);
                DesignText.LeftDT("  4. 전투시작", 15, ConsoleColor.Gray);
                DesignText.LeftDT("  5. 퀘스트", 16, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 게임 종료", 17, ConsoleColor.Red);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("게임을 종료합니다!");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine($"{P.Name}은(는) 자신의 상태를 점검합니다.");
                        DesignText.IsMove();
                        CheckPlayerState();
                        break;
                    case 2:
                        Console.WriteLine($"{P.Name}은(는) 자신의 아이템을 확인합니다.");
                        DesignText.IsMove();
                        inven.ShowInven(P); //확인 불가 직접 확인해주세요
                        break;
                    case 3:
                        Console.WriteLine($"{P.Name}은(는) 상점은 찾아 들어가봅니다");
                        DesignText.IsMove();
                        //shop.ShowShop(P,inven); //애러 발생 추후 확인 부탁
                        break;
                    case 4:
                        Console.WriteLine($"{P.Name}은(는) 던전을 찾아 들어가봅니다");
                        DesignText.IsMove();
                        dunguen.GoDunguen(P, inven, quest); //던전으로 이동
                        //Battle
                        break;
                    case 5:
                        Console.WriteLine($"{P.Name}은(는) 의뢰서 뭉치를 찾아봅니다");
                        DesignText.IsMove();
                        quest.OpenQuestMenu();
                        //threadsleep으로 렉걸리는 느낌이라 삭제 부탁드립니다. -> 나중에 꾸밀 때 뜯어 갔다는 느낌으로 사용해도 될거 같네요
                        //퀘스트 확인 창이 총 2개 있는데 퀘스트 수락하면 거절 버튼만 생성하도록 제작 부탁드립니다.
                        //그리고 받은 모든 퀘스트를 확인하는 쪽은 나중에 던전입장 전에 확인 하는 창을 만들껀데 거기서 사용하고 싶습니다.
                        break;
                }
            }
        }
        public void CheckPlayerState()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┏━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┓");
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            P.Status(2); //플레이어의 스텟 표기
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┣━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┫");
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT("  0. 돌아가기", 13, ConsoleColor.Blue);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
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
            int input = Input.input(0, 0);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"{P.Name}은(는) 돌아갑니다.");
            DesignText.IsMove();
        }
    }
}
