using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Quest
    {
        // 퀘스트... 목록 보여주기
        // 1 퀘스트 목록
        // 퀘스트를 선택하면 보상 목록을 보여주고
        // 1 수락, 0 뒤로가기
        // 퀘스트를 2개이상 받았다면 퀘스트창이 다 찼습니다 출력하기
        // 퀘스트 목록은 1 ~ 7까지 7개만 보이게
        // 9 누르면 내가 받은 퀘스트 목록(최대 2개)
        // 퀘스트 완료되면 (완) 표시
        // 퀘스트가 완료된게 아니라면 퀘스트를 포기할지 결정
        // 완료 퀘스트를 누르면 퀘스트가 완료되고 보상을 받는다.
        // 퀘스트 

        // 퀘스트 번호
        public int questNumber  = 0;
        // 퀘스트 이름
        public string questName;
        // 퀘스트 정보
        public string questInfo;
        // 퀘스트 보상
        public Item questReward;
        // 몬스터 마리 수
        public int questAmount;
        // 퀘스트 카운팅
        public int questAmountCount;
        // 퀘스트를 넣을 리스트
        List<Quest> questList;

        GameManager gm = new GameManager();



        public Quest(string questname, string questinfo, Item questreward, int amount)
        {
            questName = questname;
            questInfo = questinfo;
            questReward = questreward;
            questAmount = amount;
            QuestList();
        }

        public void QuestWindow()
        {
            Thread.Sleep(500);
            Console.Clear();

            Console.WriteLine("퀘스트 목록\n");

            QuestInfo(questList);

            gm.Input(questNumber);
        }


        // 퀘스트 생성 및 관리
        public void QuestList()
        {
            questList = new List<Quest>()
            {
                new Quest("마을을 위협하는 몬스터 처치", "이봐! 마을 근처에 몬스터들이 너무 많아졌다고 생각하지 않나?" +
                "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고! 모험가인 자네가 좀 처리해주게!", questReward, 5),

                new Quest("마을을 위협하는 몬스터를 많이 처치", "이봐! 마을 근처에 몬스터들이 엄청 많아졌다고 생각하지 않나?" +
                "마을주민들의 안전을 위해서라도 저것들 수를 좀 줄여야 한다고! 모험가인 자네가 좀 처리해주게!", questReward, 10)
            };
        }

        public void QuestInfo(List<Quest> que)
        {
            // 리스트 크기가 7 이상이면 7번 반복 작다면 리스트 크기만큼 반복
            for (int i = 0; i < Math.Min(7, questList.Count); i++)
            {
                questNumber++;
                que[i].questNumber = i + 1;
                Console.WriteLine($"{que[i].questNumber}. {que[i].questName}");
            }

        }

    }


}
