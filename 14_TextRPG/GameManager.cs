using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class GameManager
    {
        Dunguen dunguen = new Dunguen();
        Player P = new Player();
        Inven inven = new Inven();
        Shop shop = new Shop();
        QuestManager quest;

        public void SettingPlayerName() //맨처음 플레이할시만 생성
        {
            P = new Player();//플레이저 스탯 초기화
            basicform();

            DesignText.LeftDT("  플레이어의 이름을 입력해주세요.", 12, ConsoleColor.White);
            Console.SetCursorPosition(0, 22);
            // 게임 시작 시 플레이어 명 입력
            while (true)
            {
                Console.Write("입력 : ");
                P.Name = Console.ReadLine();

                if (P.Name == null || P.Name == String.Empty) //이름을 정확히 입력할 때 까지
                {
                    Console.WriteLine("다시 입력해 주세요");
                }
                else
                {
                    break;
                }
            }
            DesignText.LeftDT($"  플레이어의 이름은 {P.Name}입니다.", 14, ConsoleColor.White);
            Console.SetCursorPosition(3, 15);
            DesignText.IsMove(5);
            SettingPlayerjob();
        }
        public void SettingPlayerjob()
        {
            basicform();
            DesignText.LeftDT($"  [{P.Name}]", 2, ConsoleColor.White);
            DesignText.LeftDT("  직업을 선택하여 주세요", 3, ConsoleColor.White);
            DesignText.LeftDT("   각 직업에 따른 스탯이 적용됩니다.", 4, ConsoleColor.White);
            DesignText.LeftDT("  1. 전사", 12, ConsoleColor.White);
            DesignText.LeftDT("  2. 도적", 13, ConsoleColor.White);
            DesignText.LeftDT("  3. 검투사", 14, ConsoleColor.White);
            DesignText.LeftDT("  4. 광전사", 15, ConsoleColor.White);

            Console.SetCursorPosition(0, 22);
            int input = Input.input(1, 4);

            basicform();
            switch (input) //각 직업에 따른 스탯 조정은 여기서 하시면 됩니다.
            {
                case 1:
                    DesignText.LeftDT("  체력 + 20, 공격력 + 2", 12, ConsoleColor.Green);
                    P.Class = "전사";
                    P.Health += 20;
                    P.MaxHealth += 20;
                    P.Attack += 2;
                    break;
                case 2:
                    DesignText.LeftDT("  회피율 + 5%, 약점율 + 10%", 12, ConsoleColor.Green);
                    DesignText.LeftDT("  체력 - 10", 13, ConsoleColor.Red);
                    P.Class = "도적";
                    P.Health -= 10;
                    P.MaxHealth -= 10;
                    P.Avoid = 15;
                    P.Critical = 25;
                    break;
                case 3:
                    DesignText.LeftDT("  체력 + 10, 방어력 + 4", 12, ConsoleColor.Green);
                    P.Class = "검투사";
                    P.Health += 10;
                    P.MaxHealth += 10;
                    P.Defence += 4;
                    break;
                case 4:
                    DesignText.LeftDT("  공격력 + 6", 12, ConsoleColor.Green);
                    DesignText.LeftDT("  체력 - 20", 13, ConsoleColor.Red);
                    P.Class = "광전사";
                    P.Health -= 20;
                    P.MaxHealth -= 20;
                    P.Attack += 6;
                    break;
            }

            P.Status(2);

            DesignText.LeftDT("  1. 확정", 15, ConsoleColor.White);
            DesignText.LeftDT("  2. 재설정", 16, ConsoleColor.White);

            Console.SetCursorPosition(0, 22);
            input = Input.input(1, 2);

            switch (input) //각 직업에 따른 스탯 조정은 여기서 하시면 됩니다.
            {
                case 1:
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{P.Name}은(는) 여행을 떠납니다.");
                    DesignText.IsMove(10);
                    Start();
                    break;
                case 2:
                    SettingPlayerName();
                    break;
            }
        }
        void basicform() //기본 틀 생성
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
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
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
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
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
        }
        public void LoadPlayer()
        {
            //플레이어, 아이템, 퀘스트 정보 로드
            string filePath = "SaveGame.json"; //저장된 내용 가져오기
            string[] lines = File.ReadAllLines(filePath);

            P = JsonSerializer.Deserialize<Player>(lines[0]);
            if (File.Exists(lines[1]))
            {
                quest = JsonSerializer.Deserialize<QuestManager>(lines[1]);
            }
            if (File.Exists(lines[2]))
            {
                inven = JsonSerializer.Deserialize<Inven>(lines[1]);
            }
            if (File.Exists(lines[3]))
            {
                shop = JsonSerializer.Deserialize<Shop>(lines[2]);
            }
            Start();
        }
        public void SaveData(Player player, QuestManager quest, Inven inven, Shop shop)
        {
            //플레이어, 아이템, 퀘스트 정보 저장
            string filePath = "SaveGame.json";
            string Splayer = JsonSerializer.Serialize(player);
            string Squest = JsonSerializer.Serialize(quest);
            string Sinven = JsonSerializer.Serialize(inven);
            string Sshop = JsonSerializer.Serialize(shop);

            string[] json = {Splayer, Squest, Sinven, Sshop};
            File.WriteAllLines(filePath, json); //저장
        }
        public void DeleteSaveData()
        {
            //플레이어, 아이템, 퀘스트 정보 전체 삭제
        }

        public void Start()
        {
            quest = new QuestManager(P,inven);

            while (true)
            {
                SaveData(P, quest, inven, shop);
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
                DesignText.LeftDT("  1. 상태 보기", 12, ConsoleColor.Gray);
                DesignText.LeftDT("  2. 인벤 토리", 13, ConsoleColor.Gray);
                DesignText.LeftDT("  3. 상점", 14, ConsoleColor.Gray);
                DesignText.LeftDT("  4. 전투 시작", 15, ConsoleColor.Gray);
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
                        DesignText.IsMove(5);
                        CheckPlayerState();
                        break;
                    case 2:
                        Console.WriteLine($"{P.Name}은(는) 자신의 아이템을 확인합니다.");
                        DesignText.IsMove(5);
                        inven.ShowInven(P); //확인 불가 직접 확인해주세요
                        break;
                    case 3:
                        Console.WriteLine($"{P.Name}은(는) 상점은 찾아 들어가봅니다");
                        DesignText.IsMove(5);
                        shop.ShowShop(P,inven); //애러 발생 추후 확인 부탁
                        break;
                    case 4:
                        Console.WriteLine($"{P.Name}은(는) 던전을 찾아 들어가봅니다");
                        DesignText.IsMove(5);
                        dunguen.GoDunguen(P, inven, quest); //던전으로 이동
                        //Battle
                        break;
                    case 5:
                        Console.WriteLine($"{P.Name}은(는) 의뢰서 뭉치를 찾아봅니다");
                        DesignText.IsMove(5);
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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine($"{P.Name}은(는) 돌아갑니다.");
            Console.ResetColor();
            DesignText.IsMove(5);
        }
    }
}
