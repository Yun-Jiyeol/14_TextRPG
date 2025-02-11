using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class QuestManager
    {
        // 한 페이지에 퀘스트가 몇개 들어갈지 설정
        const int PAGE_SIZE = 7;
        // 현재 퀘스트 창 페이지
        int currentPage = 1;
        // 퀘스트 리스트
        List<Quest> questList = new List<Quest>();
        // 수락한 퀘스트 리스트
        List<Quest> acceptQuest = new List<Quest>();

        // 퀘스트 보상을 주기 위함
        ItemList itemList = new ItemList();
        Item ratherArmor;
        Inven itemIvn;

        

        Player player;

        // 퀘스트 생성
        public QuestManager(Player play, Inven ivn)
        {           
            foreach (Item IL in itemList.arrItem)
            {
                if (IL.Name == "해진 가죽갑옷")
                {
                    ratherArmor = IL;
                }
            }
            itemIvn = ivn;
            player = play;

            questList.Add(new Quest("마을을 위협하는 몬스터 처치", "이봐! 마을 근처에 몬스터들이 너무 많아졌다고 생각하지 않나? \n " +
                "마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고! \n" +
                "모험가인 자네가 좀 처리해주게나.", 5, 500, 3));
            questList.Add(new Quest("마을을 위협하는 많은 몬스터 처치", "이봐! 마을 근처에 몬스터들이 엄청 많아졌다고 생각하지 않나? \n " +
                "마을 주민들의 안전을 위해서라도 저것들 수를 많이 줄여야 한다고! \n" +
                "모험가인 자네가 많이 처리해주게나.", 10, 1000, 6));
            questList.Add(new Quest("장비를 장착해보자!", "'이봐! 어이 거기 당신! 당신 말이야 \n" +
                "이곳을 돌아다니기에 너무 장비가 부실하지않나?\n" +
                "장비를 장착하면 내가 갑옷을 하나 주겠네!'", false, 500, 1, ratherArmor));
            questList.Add(new Quest("Easy 던전를 올라가자!", "'당신은 Easy던전을 얼마나 올라가봤지? \n" +
                "헹, 나는 말이야 무려 4층까지 올라가봤다고!\n" +
                "나보다 높게 5층을 올라가면 내 재산중 일부를 보상으로 주겠어'", player, 5, 2500, 20, TowerDifficult.Easy));
            questList.Add(new Quest("Normal 던전을 올라가자!", "'이봐! 난 아직 Normal 던전을 4층까지밖에 못올라 갔지\n" +
                "5층의 상황이 궁금하해서 그러는데 탐험해서 나에게 알려주겠나?'", player, 5, 5000, 100, TowerDifficult.Normar));
            questList.Add(new Quest("Hard 던전을 올라가자!", "'이봐 거기있는 자네 내 팔이 보이나?" +
                "Hard 던전 5층을 탐험하다가 사라졌지" +
                "5층을 탐험에 성공해서 내 팔의 복수를 해주면 좋겠어'", player, 5, 10000, 500, TowerDifficult.Hard));

        }

        // 퀘스트의 종류들을 다 볼수 있는 퀘스트 창
        public void OpenQuestMenu()
        {
            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();

                string check = "■";
                string unCheck = "□";

                Console.WriteLine($"퀘스트 목록 (페이지 {currentPage})");
                Console.WriteLine("\n");

                int start = (currentPage - 1) * PAGE_SIZE == 0 ? 1 : (currentPage - 1) * PAGE_SIZE;
                int end = Math.Min(start + PAGE_SIZE, questList.Count);
                for (int i = start; i < end + 1; i++)
                {
                    // quest가 장착 관련 퀘스트라면 PlayerEquip을 실행
                    if (questList[i - 1].isQuestEquip)
                    {
                        PlayerEquip(player);
                    }
                    else if (questList[i - 1].isQuestTower)
                    {
                        PlayerTower(player);
                    }

                    // 퀘스트를 수락 했다면 박스가 칠해지게
                    string questCheck = questList[i - 1].isAccept ? check : unCheck;
                    questList[i - 1].questNumber = i;

                    if (questList[i - 1].isReward)
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    else if (questList[i - 1].isComplete && questList[i - 1].isAccept)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"{i % PAGE_SIZE}. {questList[i - 1].questName} | {questCheck}");

                    Console.ResetColor();
                }
                Console.WriteLine("\n");
                Console.WriteLine("8. 다음 페이지");
                Console.WriteLine("9. 진행 중 퀘스트");
                Console.WriteLine("0. 뒤로가기");
                Console.Write("\n입력 : ");

                string Pinput = Console.ReadLine();
                int numinput;

                
                if (int.TryParse(Pinput, out numinput))
                {
                    if (numinput == 0)
                        return;
                    else if (numinput == 8)
                        NextPage();
                    else if (numinput == 9)
                        OpenAcceptQuest();
                    // 입력받은 값이 0보다 크고 PAGE_SIZE(7)보다 작고 start + numinput - 1 의 값이 questList 갯수보다 작다면 실행
                    else if (0 < numinput && numinput <= PAGE_SIZE && start + numinput - 1 <= questList.Count)
                    {
                        if (questList[start + numinput - 2].isReward)
                        {
                            Console.WriteLine("이미 받은 보상입니다.");
                        }
                        else
                            QuestInfo(questList[start + numinput - 2]);
                            
                    }
                    else
                        Console.WriteLine("잘못 된 입력입니다.");
                }
                else
                    Console.WriteLine("잘못 된 입력입니다.");
            }

        }

        // 다음 페이지가 있다면 다음페이지를 보여주는 메서드
        public void NextPage()
        {
            if (currentPage * PAGE_SIZE < questList.Count)
                currentPage++;
            else
                Console.WriteLine("마지막 페이지 입니다.");
        }

        // 수락한 퀘스트 메뉴를 열어주는 메서드
        public void OpenAcceptQuest()
        {
            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("수락한 퀘스트 목록(최대 2개) \n");
                if (acceptQuest.Count == 0)
                {
                    Console.WriteLine("수락한 퀘스트가 없습니다.");
                }
                else
                {
                    for (int i = 0; i < acceptQuest.Count; i++)
                    {
                        // quest가 장착 관련 퀘스트라면 PlayerEquip을 실행
                        if (acceptQuest[i].isQuestEquip)
                        {
                            PlayerEquip(player);
                        }
                        else if (acceptQuest[i].isQuestTower)
                        {
                            PlayerTower(player);
                        }

                        if (acceptQuest[i].isComplete)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}. {acceptQuest[i].questName}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("\n0. 뒤로가기");
                Console.WriteLine();

                int input = Input.input(0, acceptQuest.Count);

                if (input == 0)
                    return;
                else if (input == 1)
                    QuestInfo(acceptQuest[0]);
                else if (input == 2)
                    QuestInfo(acceptQuest[1]);

            }


        }

        // 퀘스트의 정보를 보여주는 메서드(아직 미완)
        public void QuestInfo(Quest quest)
        {
            while (true)
            {
                Thread.Sleep(500);
                Console.Clear();

                Console.WriteLine($"{quest.questNumber}. {quest.questName}");
                Console.WriteLine();
                Console.WriteLine($"{quest.questInfo}");
                Console.WriteLine();
                Console.WriteLine($"보상 : {quest.rewardGold} G, {quest.rewardExp} 경험치");
                if (quest.questKills > 0)
                {
                    Console.WriteLine($"몬스터 {quest.questKills} 처치하기 ({quest.currentKills} / {quest.questKills})");
                }
                else if (quest.isItemReward)
                {
                    Console.WriteLine($"{quest.rewardItem.Name}");
                }
                else if (quest.questTower > 0)
                {
                    Console.WriteLine($"{quest.TD} 난이도 {quest.questTower - 1} 층 탐험에 성공하기");
                }
                Console.WriteLine();

                if (quest.isAccept && quest.isComplete)
                {
                    Console.WriteLine("1. 퀘스트 완료");
                }
                else if (!quest.isAccept)
                    Console.WriteLine("1. 퀘스트 수락");
                else if (quest.isAccept)
                    Console.WriteLine("1. 퀘스트 거절");

                Console.WriteLine("0. 닫기");
                Console.WriteLine();

                int input = Input.input(0, 1);

                if (input == 0) return;
                else if (input == 1)
                {
                    // 퀘스트를 받았고 퀘스트를 완료를 했다면
                    if (quest.isAccept && quest.isComplete)
                    {
                        if (quest.isItemReward)
                            CompleteQuest(player, quest, itemIvn);
                        else if (quest.questKills > 0 || quest.questTower > 0)
                            CompleteQuest(player, quest);

                        return;
                    }
                    // 퀘스트를 받지 않았다면 퀘스트를 받을수 있게
                    else if (!quest.isAccept)
                    {
                        AcceptQuest(quest);
                        return;
                    }
                    // 퀘스트를 받아놓고 완료를 못했다면 퀘스트를 포기할 수 있게
                    else if(quest.isAccept)
                    {
                        RejectQuest(quest);
                        return;
                    }
                    else
                        Console.WriteLine("잘못 된 입력입니다.");
                }
                else
                    Console.WriteLine("잘못 된 입력입니다.");


            }

        }

        // 퀘스트를 수락했을 떄 실행시켜줄 메서드
        public void AcceptQuest(Quest quest)
        {
            if (quest.isAccept)
            {
                Console.WriteLine("이미 수락한 퀘스트 입니다.");
                return;
            }

            if (acceptQuest.Count >= 2)
            {
                Console.WriteLine("퀘스트는 최대 2개만 받으실 수 있습니다.");
                return;
            }

            quest.Accept();
            acceptQuest.Add(quest);

            // List1 의 3번째를 List 2번에 Add  List
            
        }

        //퀘스트를 거절 했을 때 실행시켜줄 메서드
        public void RejectQuest(Quest quest)
        {
            if (quest.isAccept)
            {
                acceptQuest.Remove(quest);
                quest.Reject();
            }

        }

        //퀘스트를 완료 했을 때 실행시켜줄 메서드
        public void CompleteQuest(Player player, Quest quest)
        {
            if (quest.isAccept && quest.isComplete)
            {
                quest.Complete(player);
                acceptQuest.Remove(quest);
            }
        }

        public void CompleteQuest(Player player, Quest quest, Inven inv)
        {
            if (quest.isAccept && quest.isComplete)
            {
                quest.Complete(player, inv);
                acceptQuest.Remove(quest);
            }
        }

        //몬스터를 죽일 떄 호출시켜줄 메서드
        public void KillMonster()
        {
            if (acceptQuest.Count >= 0)
            {
                foreach (Quest quest in acceptQuest)
                {
                    if (quest.questKills > 0 && !quest.isComplete)
                    {
                        quest.currentKills++;

                        if (quest.currentKills >= quest.questKills)
                        {
                            quest.isComplete = true;
                        }
                    }
                }
            }
        }

        public void PlayerEquip(Player play)
        {
            if (acceptQuest.Count >= 0)
            {
                foreach (Quest quest in acceptQuest)
                {
                    if (quest.isQuestEquip && !quest.isEquip && play.isEquip)
                    {
                        quest.isComplete = true;
                    }
                }
            }
        }

        // 퀘스트의 타워 층수 갱신 메서드
        public void PlayerTower(Player player)
        {
            if (acceptQuest.Count >= 0)
            {
                foreach (Quest quest in acceptQuest)
                {
                    if (quest.isQuestTower)
                    {
                        switch (quest.TD)
                        {
                            case TowerDifficult.Easy:
                                quest.currentTower = player.repeat[0];
                                break;

                            case TowerDifficult.Normar:
                                quest.currentTower = player.repeat[1];
                                break;

                            case TowerDifficult.Hard:
                                quest.currentTower = player.repeat[2];
                                break;
                        }

                        if (quest.currentTower == quest.questTower)
                        {
                            quest.isComplete = true;
                        }
                    }
                }
            }
        }
       

    }
}
