using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class QuestManager
    {
        const int PAGE_SIZE = 7;
        int currentPage = 1;
        bool isPage;
        List<Quest> questList = new List<Quest>();
        List<Quest> acceptQuest = new List<Quest>();

        public QuestManager()
        {
            questList.Add(new Quest("마을을 위협하는 몬스터 처치", "이봐! 마을 근처에 몬스터들이 너무 많아졌다고 생각하지 않나? \n " +
                "마을 주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고! \n" +
                "모험가인 자네가 좀 처리해주게나.", 5, 500, 3));
            questList.Add(new Quest("마을을 위협하는 많은 몬스터 처치", "이봐! 마을 근처에 몬스터들이 엄청 많아졌다고 생각하지 않나? \n " +
                "마을 주민들의 안전을 위해서라도 저것들 수를 많이 줄여야 한다고! \n" +
                "모험가인 자네가 많이 처리해주게나.", 10, 1000, 6));
        }

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
                    // 퀘스트를 수락 했다면 박스가 칠해지게
                    string questCheck = questList[i - 1].isAccept ? check : unCheck;
                    questList[i - 1].questNumber = i;
                    Console.WriteLine($"{i % PAGE_SIZE}. {questList[i - 1].questName} | {questCheck}");
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
                    else if (0 < numinput && numinput <= PAGE_SIZE && start + numinput - 1 <= questList.Count)
                    {
                        QuestInfo(questList[start + numinput - 2], false);
                    }
                }
                else
                    Console.WriteLine("잘못된 입력입니다.");
            }

        }

        public void NextPage()
        {
            if (currentPage * PAGE_SIZE < questList.Count)
                currentPage++;
            else
                Console.WriteLine("마지막 페이지 입니다.");
        }

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
                        Console.WriteLine($"{i + 1}. {acceptQuest[i].questName}");
                    }
                }
                Console.WriteLine("\n0. 뒤로가기");
                Console.WriteLine();

                int input = Input.input(0, acceptQuest.Count);

                if (input == 0)
                    return;
                else if (input == 1)
                    QuestInfo(acceptQuest[0], true);
                else if (input == 2)
                    QuestInfo(acceptQuest[1], true);

            }


        }
        public void QuestInfo(Quest quest, bool isAcceptMenu)
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
                Console.WriteLine();

                if (!isAcceptMenu || !quest.isAccept)
                    Console.WriteLine("1. 퀘스트 수락");

                if (quest.isAccept)
                    Console.WriteLine("2. 퀘스트 거절");

                Console.WriteLine("0. 닫기");
                Console.WriteLine();

                int input = Input.input(0, 2);

                if (input == 0) return;
                else if (input == 1)
                {
                    if (!isAcceptMenu)
                        AcceptQuest(quest);
                    else
                        Console.WriteLine("잘못된 입력입니다.");
                }
                else if (input == 2)
                {
                    if (quest.isAccept)
                        RejectQuest(quest);
                    return;
                }
                else
                    Console.WriteLine("잘못된 입력입니다.");


            }

        }

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

        public void RejectQuest(Quest quest)
        {
            if (quest.isAccept)
            {
                acceptQuest.Remove(quest);
                quest.Reject();

            }

        }
    }
}
