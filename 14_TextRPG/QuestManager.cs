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
        const int PAGE_SIZE = 6;
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

            questList.Add(new Quest("마을을 위협하는 몬스터 처치", "  이봐! 마을 근처에 몬스터들이\n" +
                "   너무 많아졌다고 생각하지 않나?\n" + "   마을 주민들의 안전을 위해서라도\n"+ "   저것들 수를 좀 줄여야 한다고!\n" +
                "   모험가인 자네가 좀 처리해주게나.", 5, 500, 3));
            questList.Add(new Quest("마을을 위협하는 몬스터 처치2", "  이봐! 마을 근처에 몬스터들이\n" +
                "   엄청 많아졌다고 생각하지 않나?\n" + "   마을 주민들의 안전을 위해서라도\n" + "   저것들 수를 많이 줄여야 한다고!\n" +
                "   모험가인 자네가 많이 처리해주게나.", 10, 1000, 6));
            questList.Add(new Quest("장비를 장착해보자!", "  이봐! 어이 거기 당신! 당신 말이야\n" +
                "   이곳을 돌아다니기에\n" + "   너무 장비가 부실하지않나?\n" + "   장비를 장착하면\n" +
                "   내가 갑옷을 하나 주겠네!", false, 500, 1, ratherArmor));
            questList.Add(new Quest("Easy 던전를 올라가자!", "  당신은 Easy던전을 얼마나 올라가봤지?\n" +
                "   헹, 나는 말이야\n" + "   무려 4층까지 올라가봤다고!\n" + "   나보다 높게 5층을 올라가면\n" +
                "   내 재산중 일부를 보상으로 주겠어", player, 5, 2500, 20, TowerDifficult.Easy));
            questList.Add(new Quest("Normal 던전을 올라가자!", "  이봐! 난 아직 Normal 던전을\n" +
                "   4층까지밖에 못올라 갔지\n" + "   5층의 상황이 궁금하해서 그러는데\n" +
                "   탐험해서 나에게 알려주겠나?", player, 5, 5000, 100, TowerDifficult.Normar));
            questList.Add(new Quest("Hard 던전을 올라가자!", "  이봐 거기있는 자네\n" +
                "   내 팔이 보이나?\n" + "   Hard 던전 5층을 탐험하다가 사라졌지\n" + "   5층을 탐험에 성공해서\n" +
                "   내 팔의 복수를 해주면 좋겠어", player, 5, 10000, 500, TowerDifficult.Hard));
            questList.Add(new Quest("Hard 던전을 올라가자2!", "  이봐 거기있는 자네\n" +
                "   내 팔이 보이나?\n" + "   Hard 던전 10층을 탐험하다가 사라졌지\n" + "   10층을 탐험에 성공해서\n" +
                "   내 팔의 복수를 해주면 좋겠어", player, 10, 10000, 500, TowerDifficult.Hard));
            questList.Add(new Quest("Hard 던전을 올라가자3!", "  이봐 거기있는 자네\n" +
                "   내 팔이 보이나?\n" + "   Hard 던전 15층을 탐험하다가 사라졌지\n" + "   15층을 탐험에 성공해서\n" +
                "   내 팔의 복수를 해주면 좋겠어", player, 15, 10000, 500, TowerDifficult.Hard));

        }

        // 퀘스트의 종류들을 다 볼수 있는 퀘스트 창
        public void OpenQuestMenu()
        {
            while (true)
            {   
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.LeftDT($"  퀘스트 목록 (페이지 {currentPage})", 1, ConsoleColor.Green);

                int listNum = currentPage == 1 ? 1 : 0;
                int start = (currentPage - 1) * PAGE_SIZE == 0 ? 1 : (currentPage - 1) * PAGE_SIZE; // 1 6
                int end = Math.Min(start + PAGE_SIZE, questList.Count);                             // 7 8
                for (int i = start; i < end ; i++) // (1, 2, 3, 4, 5)
                {
                    // quest가 장착 관련 퀘스트라면 PlayerEquip을 실행
                    if (questList[i - listNum].isQuestEquip)
                    {
                        PlayerEquip(player);
                    }
                    else if (questList[i - listNum].isQuestTower)
                    {
                        PlayerTower(player);
                    }


                    // 1 페이지만 0, 1, 2, 3, 4, 5 가 +1이됨 (1, 2, 3, 4, 5, 6)
                    // 2 페이즈는 6, 7, 8, 9, 10, 11 (+1 이 안됨)
                    int questNum = 0;

                    if (currentPage == 1)
                    {
                        questNum = i % PAGE_SIZE == 0 ? PAGE_SIZE : i % PAGE_SIZE;
                    }
                    else if (currentPage > 1)
                    {
                        questNum = i % PAGE_SIZE == 0 ? 1 : i % PAGE_SIZE + 1;
                    }
                    questList[i - listNum].questNumber = questNum;

                    if (questList[i - listNum].isReward)
                        DesignText.LeftDT($" {questNum}. {questList[i - listNum].questName}", 2 + i - start, ConsoleColor.DarkGray);
                    else if (questList[i - listNum].isComplete && questList[i - listNum].isAccept)
                        DesignText.LeftDT($" {questNum}. {questList[i - listNum].questName}", 2 + i - start, ConsoleColor.Green);
                    else if(questList[i - listNum].isAccept)
                        DesignText.LeftDT($" {questNum}. {questList[i - listNum].questName}", 2 + i - start, ConsoleColor.Yellow);
                    else
                        DesignText.LeftDT($" {questNum}. {questList[i - listNum].questName}", 2 + i - start, ConsoleColor.White);
                }
                if (start + PAGE_SIZE > questList.Count)
                {
                    for (int i = questList.Count; i < currentPage * PAGE_SIZE; i++)
                    {
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    }
                }

                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("   7. 이전      0.나가기      8.다음", 9, ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┣━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┫");
                Console.ResetColor();
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

                int failNum = 0;
                while (true)
                {
                    Console.SetCursorPosition(0, 22);
                    int Pinput = Input.input(0, 8);

                    if (Pinput == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine();
                        Console.WriteLine("의뢰서 뭉치를 다 확인한 후 마을로 돌아갑니다.");
                        Console.ResetColor();
                        DesignText.IsMove(5);
                        return;
                    }
                    else if (Pinput == 8)
                    {
                        NextPage();
                        break;
                    }
                    else if (Pinput == 7)
                    {
                        BeforePage();
                        break;
                    }
                    // 입력받은 값이 0보다 크고 PAGE_SIZE(6)보다 작고 start + numinput - 1 의 값이 questList 갯수보다 작다면 실행
                    else if (0 < Pinput && Pinput <= PAGE_SIZE && start + Pinput - listNum <= questList.Count)
                    {
                        if (currentPage == 1)
                        {

                            if (questList[start + Pinput - 2].isReward)
                            {
                                Console.WriteLine("이미 받은 보상입니다.");
                                break;
                            }
                            else
                            {
                                QuestInfo(questList[start + Pinput - 2]);
                                break;
                            }
                        }
                        else if (currentPage > 1)
                        {
                            if (questList[start + Pinput - 1].isReward)
                            {
                                Console.WriteLine("이미 받은 보상입니다.");
                                break;
                            }
                            else
                            {
                                QuestInfo(questList[start + Pinput - 1]);
                                break;
                            }
                        }
                        Console.SetCursorPosition(0, 23);
                        Console.WriteLine("                         ");
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 23);
                        failNum++;
                        Console.WriteLine($"잘못 된 번호입니다({failNum})");
                    }
                }
            }

        }

        // 다음 페이지가 있다면 다음페이지를 보여주는 메서드
        public void NextPage()
        {
            if (currentPage * PAGE_SIZE < questList.Count)
                currentPage++;
            else
            {
                DesignText.LeftDT("  찾아보지만 다른 퀘스트는 없습니다.", 12, ConsoleColor.Yellow);
                Console.SetCursorPosition(0,23);
                DesignText.IsMove(5);
            }
        }

        // 전 페이지가 있다면 전페이지를 보여주는 메서드
        public void BeforePage()
        {
            if (currentPage * PAGE_SIZE > questList.Count)
                currentPage--;
            else
            {
                DesignText.LeftDT("  찾아보지만 다른 퀘스트는 없습니다.", 12, ConsoleColor.Yellow);
                Console.SetCursorPosition(0, 23);
                DesignText.IsMove(5);
            }

        }

        // 수락한 퀘스트 메뉴를 열어주는 메서드
        public void OpenAcceptQuest()
        {
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
                DesignText.LeftDT("  수락한 퀘스트 목록(최대 2개)", 2, ConsoleColor.Gray);
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

                if (acceptQuest.Count == 0)
                {
                    DesignText.LeftDT("  수락한 퀘스트가 없습니다.", 4, ConsoleColor.Gray);
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
                            DesignText.LeftDT($"  {i + 1}. {acceptQuest[i].questName}", 4 + i, ConsoleColor.Green);
                        else
                            DesignText.LeftDT($"  {i + 1}. {acceptQuest[i].questName}", 4 + i, ConsoleColor.Yellow);
                    }
                }
                DesignText.LeftDT("  0. 뒤로가기", 8, ConsoleColor.Blue);

                Console.SetCursorPosition(0, 22);
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
                //초기화
                Console.SetCursorPosition(0, 11);
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
                DesignText.LeftDT($"   {quest.questNumber}. {quest.questName}", 11, ConsoleColor.White);
                DesignText.LeftDT($" 보상 : {quest.rewardGold} G, {quest.rewardExp} 경험치", 13, ConsoleColor.Yellow);

                if (quest.questKills > 0)
                {
                    DesignText.LeftDT($" 몬스터 {quest.questKills} 처치하기 ({quest.currentKills} / {quest.questKills})", 14, ConsoleColor.Gray);
                }
                else if (quest.isItemReward)
                {
                    DesignText.LeftDT($" {quest.rewardItem.Name}", 14, ConsoleColor.Cyan);
                }
                else if (quest.questTower > 0)
                {
                    DesignText.LeftDT($" {quest.TD} 난이도 {quest.questTower - 1} 층 탐험에 성공하기", 14, ConsoleColor.Gray);
                }

                if (quest.isAccept && quest.isComplete)
                {
                    DesignText.LeftDT("  1. 퀘스트 완료", 16, ConsoleColor.Green);
                    Console.WriteLine();
                }
                else if (!quest.isAccept)
                    DesignText.LeftDT("  1. 퀘스트 수락", 16, ConsoleColor.Yellow);
                else if (quest.isAccept)
                    DesignText.LeftDT("  1. 퀘스트 거절", 16, ConsoleColor.Red);

                DesignText.LeftDT("  2. 퀘스트 설명보기", 17, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 닫기", 18, ConsoleColor.Blue);
                Console.WriteLine();

                Console.SetCursorPosition(0,22);
                Console.WriteLine("                           ");//지우기
                Console.SetCursorPosition(0, 22);
                int input = Input.input(0, 2);

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
                else if(input == 2)
                {
                    //초기화
                    Console.SetCursorPosition(0, 11);
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
                    DesignText.LeftDT($"   {quest.questNumber}. {quest.questName}", 11, ConsoleColor.White);

                    DesignText.LeftDT($"{quest.questInfo}", 13, ConsoleColor.Gray);
                    DesignText.LeftDT("", 14, ConsoleColor.Blue);
                    DesignText.LeftDT("", 15, ConsoleColor.Blue);
                    DesignText.LeftDT("", 16, ConsoleColor.Blue);
                    DesignText.LeftDT("", 17, ConsoleColor.Blue);
                    DesignText.LeftDT("", 18, ConsoleColor.Blue);
                    DesignText.LeftDT("  0. 닫기", 19, ConsoleColor.Blue);

                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("                           ");//지우기
                    Console.SetCursorPosition(0, 22);
                    int reinput = Input.input(0, 0);
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
