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
        public string questName { get; set; }
        // 퀘스트 정보
        public string questInfo { get; set; }
        // 몬스터 마리 수
        public int questAmount { get; set; }
        // 퀘스트 카운팅
        // 퀘스트 보상
        public int rewardGold { get; set; }
        public Item rewardItem  { get; set; }
        public int rewardExp    { get; set; }
        public int questAmountCount { get; set; }
        // 퀘스트를 받았는지 여부
        public bool isAccept { get; set; } = false;
        // 퀘스트 완료 했는지 여부
        public bool isComplete { get; set; }
        




        public Quest(string questname, string questinfo, int amount, int rewardgold, int rewardexp, Item rewarditem)
        {
            questName = questname;
            questInfo = questinfo;
            rewardItem = rewarditem;
            questAmount = amount;
            rewardGold = rewardgold;
        }

        public Quest(string questname, string questinfo, int amount, int rewardgold, int rewardexp)
        {
            questName = questname;
            questInfo = questinfo;
            questAmount = amount;
            rewardGold = rewardgold;
            rewardExp = rewardexp;
        }

        public void Accept()
        {
            isAccept = true;
            Console.WriteLine();
            Console.WriteLine($"[{questName}] 을(를) 수락하셨습니다! ");
        }

        public void Reject()
        {
            isAccept = false;
            Console.WriteLine();
            Console.WriteLine($"[{questName}] 을(를) 거절하셨습니다.");
        }

        public void CompleteQuest(Player player)
        {
            if (isComplete)
            {
                Console.WriteLine($"{questName} 퀘스트 완료! ");
                Console.WriteLine($"보상");
                Console.WriteLine($"{rewardGold}");
                Console.WriteLine($"{rewardExp}");
            }
        }

    }


}
