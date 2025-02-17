﻿using System;
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
            quest = new QuestManager(P, inven);
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

            string filePath = "SavePlayer.json"; //저장된 내용 가져오기
            string[] lines = File.ReadAllLines(filePath);
            P = JsonSerializer.Deserialize<Player>(lines[0]);
            P.repeat[0] = JsonSerializer.Deserialize<int>(lines[1]);
            P.repeat[1] = JsonSerializer.Deserialize<int>(lines[2]);
            P.repeat[2] = JsonSerializer.Deserialize<int>(lines[3]);
            P.isEquip = JsonSerializer.Deserialize<bool>(lines[4]);

            quest = new QuestManager(P, inven);
            filePath = "SaveQuest.json"; //저장된 내용 가져오기
            if (File.Exists(filePath)) //저장된 퀘스트 정보가 존재한다면
            {
                string[] Squest = File.ReadAllLines(filePath);
                for (int i = 0; i < Squest.Length / 8; i++)
                {
                    quest.questList[i].currentKills = JsonSerializer.Deserialize<int>(Squest[8 * i]);
                    quest.questList[i].isEquip = JsonSerializer.Deserialize<bool>(Squest[8 * i + 1]);
                    quest.questList[i].isQuestEquip = JsonSerializer.Deserialize<bool>(Squest[8 * i + 2]);
                    quest.questList[i].questTower = JsonSerializer.Deserialize<int>(Squest[8 * i + 3]);
                    quest.questList[i].isAccept = JsonSerializer.Deserialize<bool>(Squest[8 * i + 4]);
                    quest.questList[i].isComplete = JsonSerializer.Deserialize<bool>(Squest[8 * i + 5]);
                    quest.questList[i].isReward = JsonSerializer.Deserialize<bool>(Squest[8 * i + 6]);
                    quest.questList[i].TD = JsonSerializer.Deserialize<TowerDifficult>(Squest[8 * i + 7]);
                }
            }

            filePath = "SaveInven.json"; //저장된 내용 가져오기
            if (File.Exists(filePath)) //저장된 인벤토리 정보가 존재한다면
            {
                string[] SInven = File.ReadAllLines(filePath);
                for (int i = 0; i < SInven.Length / 8; i++)
                {
                    Item item = new Item(JsonSerializer.Deserialize<string>(SInven[8 * i]),
                        JsonSerializer.Deserialize<ItemType>(SInven[8 * i + 1]),
                        JsonSerializer.Deserialize<string>(SInven[8 * i + 2]),
                        JsonSerializer.Deserialize<int>(SInven[8 * i + 3]),
                        JsonSerializer.Deserialize<int>(SInven[8 * i + 4]),
                        JsonSerializer.Deserialize<bool>(SInven[8 * i + 7]));
                    item.PlayerHave = JsonSerializer.Deserialize<bool>(SInven[8 * i + 5]);
                    item.PlayerUse = JsonSerializer.Deserialize<bool>(SInven[8 * i + 6]);
                    inven.listHoldItem.Add(item);
                }
            }

            filePath = "SaveShop.json"; //저장된 내용 가져오기
            if (File.Exists(filePath)) //저장된 인벤토리 정보가 존재한다면
            {
                string[] Sshop = File.ReadAllLines(filePath);
                for (int i = 0; i < Sshop.Length / 3; i++)
                {
                    shop.arrShopItem[i].Cost = JsonSerializer.Deserialize<int>(Sshop[3 * i]);
                    shop.arrShopItem[i].PlayerHave = JsonSerializer.Deserialize<bool>(Sshop[3 * i + 1]);
                    shop.arrShopItem[i].PlayerUse = JsonSerializer.Deserialize<bool>(Sshop[3 * i + 2]);
                }
            }

            Start();
        }
        public void SaveData(Player player, QuestManager quest, Inven inven, Shop shop)
        {
            //플레이어, 아이템, 퀘스트 정보 저장
            string filePath = "SavePlayer.json";
            string Splayerdata = JsonSerializer.Serialize(player);
            string Easydun = JsonSerializer.Serialize(player.repeat[0]);
            string Normaldun = JsonSerializer.Serialize(player.repeat[1]);
            string Harddun = JsonSerializer.Serialize(player.repeat[2]);
            string isEquip = JsonSerializer.Serialize(player.isEquip);
            string[] Splayer = { Splayerdata, Easydun,Normaldun, Harddun, isEquip };
            File.WriteAllLines(filePath, Splayer); //저장

            filePath = "SaveQuest.json";
            List<string> Squest = new List<string>();
            for (int i = 0; i< quest.questList.Count; i++)
            {
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].currentKills));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].isEquip));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].isQuestEquip));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].questTower));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].isAccept));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].isComplete));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].isReward));
                Squest.Add(JsonSerializer.Serialize(quest.questList[i].TD));
            }
            File.WriteAllLines(filePath, Squest); //저장

            filePath = "SaveInven.json";
            List<string> SInven = new List<string>();
            for (int i = 0; i < inven.listHoldItem.Count; i++)
            {
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].Name));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].Itemtype));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].Info));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].Value));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].Cost));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].PlayerHave));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].PlayerUse));
                SInven.Add(JsonSerializer.Serialize(inven.listHoldItem[i].SaleItem));
            }
            File.WriteAllLines(filePath, SInven); //저장

            filePath = "SaveShop.json";
            List<string> Sshop = new List<string>();
            for (int i = 0; i < shop.arrShopItem.Length; i++)
            {
                Sshop.Add(JsonSerializer.Serialize(shop.arrShopItem[i].Cost));
                Sshop.Add(JsonSerializer.Serialize(shop.arrShopItem[i].PlayerHave));
                Sshop.Add(JsonSerializer.Serialize(shop.arrShopItem[i].PlayerUse));
            }
            File.WriteAllLines(filePath, Sshop); //저장
        }
        public void DeleteSaveData()
        {
            //플레이어, 아이템, 퀘스트 정보 전체 삭제
            string filePath = "SavePlayer.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            filePath = "SaveQuest.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            filePath = "SaveInven.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            filePath = "SaveShop.json";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void Start()
        {
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
                DesignText.LeftDT("  6. 데이터 삭제", 17, ConsoleColor.DarkRed);
                DesignText.LeftDT("  0. 게임 종료", 18, ConsoleColor.Red);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┗━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┛");
                Console.ResetColor();

                Console.WriteLine();
                int input = Input.input(0, 6);
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
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(0,24);
                        Console.WriteLine("지금까지 데이터가 다 사라집니다. 그래도 삭제하겠습니까?");
                        Console.WriteLine("0. 삭제    1. 뒤로 가기");
                        int dinput = Input.input(0, 1);
                        if (dinput == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("모든 데이터를 삭제합니다.");
                            DeleteSaveData();
                            DesignText.IsMove(15);
                            Environment.Exit(0);
                        }
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
