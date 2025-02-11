using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public enum TowerDifficult
    {
        Easy = 144,
        Normar,
        Hard
    }

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

        // 퀘스트 카운팅 (몬스터 잡았을 때)
        // 퀘스트 보상
        public int rewardGold { get; set; }
        public Item rewardItem  { get; set; }
        public int rewardExp    { get; set; }

        // 몬스터를 잡아야 할 마리 수
        public int questKills { get; set; }
        // 현재 킬 수
        public int currentKills {  get; set; }
        //장비 착용 목표 아이템
        public string questItem {  get; set; }
        //장비 착용을 했는지
        public bool isEquip { get; set; } = false;
        // 장비 착용 관련 퀘스트
        public bool isQuestEquip { get; set; } = false;

        // 타워 층수
        public int questTower { get; set; }
        public int currentTower { get; set; }
        public TowerDifficult TD { get; set; }
        public bool isQuestTower {  get; set; } = false;


        // 퀘스트를 받았는지 여부
        public bool isAccept { get; set; } = false;
        // 퀘스트 완료 했는지 여부
        public bool isComplete { get; set; } = false;
        // 퀘스트 보상을 다 받았는지 여부
        public bool isReward { get; set; } = false;
        public bool isItemReward { get; set; } = false;

        


        
        // 몬스터 처치 퀘스트
        public Quest(string questname, string questinfo, int amount, int rewardgold, int rewardexp)
        {
            questName = questname;
            questInfo = questinfo;
            questKills = amount;
            rewardGold = rewardgold;
            rewardExp = rewardexp;
            currentKills = 0;
        }

        //장비 착용 퀘스트
        public Quest(string questname, string questinfo, bool isequip, int rewardgold, int rewardexp, Item rewarditem)
        {
            questName = questname;
            questInfo = questinfo;
            isEquip = isequip;
            rewardGold = rewardgold;
            rewardExp = rewardexp;
            rewardItem = rewarditem;
            isItemReward = true;
            isQuestEquip = true;
        }

        // 플레이어 타워 층수 퀘스트
        public Quest(string questname, string questinfo, Player play , int questtower , int rewardgold, int rewardexp, TowerDifficult Td)
        {
            questName = questname;
            questInfo = questinfo;
            switch (TD)
            {
                case TowerDifficult.Easy:
                    currentTower = play.repeat[0];
                    break;

                case TowerDifficult.Normar:
                    currentTower = play.repeat[1];
                    break;

                case TowerDifficult.Hard:
                    currentTower = play.repeat[2];
                    break;
            }
            questTower = questtower + 1;
            TD = Td;
            rewardGold = rewardgold;
            rewardExp = rewardexp;
            isQuestTower = true;
        }


        public void Accept()
        {
            isAccept = true;
            Console.SetCursorPosition(0, 12);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT($"[{questName}] 을(를)", 40 - DesignText.GetConsoleWidth($"[{questName}] 을(를)"), ConsoleColor.Gray);
            DesignText.MiddleDT("수락하셨습니다!", 25, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.SetCursorPosition(0, 24);
            Console.WriteLine($"퀘스트를 수주하는중");
            DesignText.IsMove(7);
        }

        public void Reject()
        {
            isAccept = false;
            Console.SetCursorPosition(0, 12);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT($"[{questName}] 을(를)", 40 - DesignText.GetConsoleWidth($"[{questName}] 을(를)"), ConsoleColor.Gray);
            DesignText.MiddleDT("거절하셨습니다!", 25, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.SetCursorPosition(0, 24);
            Console.WriteLine($"퀘스트를 포기하러 가는중");
            DesignText.IsMove(7);
            currentKills = 0;
        }


        public void Complete(Player player)
        {
            if (isComplete)
            {
                Console.SetCursorPosition(0, 12);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT($"{questName} 퀘스트 완료!", 40 - DesignText.GetConsoleWidth($"{questName} 퀘스트 완료!"), ConsoleColor.Gray);
                DesignText.MiddleDT("★ 보상 ★", 40 - DesignText.GetConsoleWidth("★ 보상 ★"), ConsoleColor.Green);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT($"골드 : {rewardGold}", 16 , ConsoleColor.Gray);
                DesignText.LeftDT($"경험치 : {rewardExp}", 17, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.SetCursorPosition(0, 24);
                Console.WriteLine("퀘스트의 성공을 보고하는중");
                DesignText.IsMove(10);

                //보상 지급
                player.Gold += rewardGold;
                player.Ex += rewardExp;

                //
                isReward = true;
            }
        }
        public void Complete(Player player, Inven inv)
        {
            if (isComplete)
            {
                Console.SetCursorPosition(0, 12);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT($"{questName} 퀘스트 완료!", 40 - DesignText.GetConsoleWidth($"{questName} 퀘스트 완료!"), ConsoleColor.Gray);
                DesignText.MiddleDT("★ 보상 ★", 40 - DesignText.GetConsoleWidth("★ 보상 ★"), ConsoleColor.Green);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT($"골드 : {rewardGold}", 16, ConsoleColor.Gray);
                DesignText.LeftDT($"경험치 : {rewardExp}", 17, ConsoleColor.Gray);
                DesignText.LeftDT($"아이템 : {rewardItem.Name}", 18 , ConsoleColor.Cyan);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.SetCursorPosition(0, 24);
                Console.WriteLine("퀘스트의 성공을 보고하는중");
                DesignText.IsMove(10);

                //보상 지급
                player.Gold += rewardGold;
                player.Ex += rewardExp;
                inv.GetItem(rewardItem);

                //
                isReward = true;
            }
        }

    }


}
