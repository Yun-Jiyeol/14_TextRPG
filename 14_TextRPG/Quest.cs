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
        public int questNumber;
        // 퀘스트 이름
        public string questName;
        // 퀘스트 정보
        public string questInfo;
        // 퀘스트 보상
        public Item questReward;



        public Quest(string questname, string questinfo, Item questreward)
        {
            questName = questname;
            questInfo = questinfo;
            questReward = questreward;
        }

        public void QuestList()
        {

        }

    }


}
