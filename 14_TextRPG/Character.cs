using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Character
    {
        GameManager gamemanager;
        public string Name { get;} //캐릭터 이름
        public string Class { get; set; } //캐릭터 직업
        public int Level { get; set; } //캐릭터 레벨
        public float Health { get; set; } //캐릭터 현제 체력
        public float MaxHealth { get; set; } //캐릭터 최대 체력
        public int Attack { get; set; } //캐릭터 공격력
        public int Defence { get; set; } //캐릭터 방어력
        public int Gold { get; set; } //캐릭터 소유 골드
        public bool isDead { get; set; } = false; //캐릭터 사망 유무
        public void Status() //전투 때 보여지게끔 (몬스터)
        {
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ({Class})");
            Console.WriteLine($"공격력 : {Attack} + (0)"); // 아이템으로 오른 공격력 반영 해주세요
            Console.WriteLine($"방어력 : {Defence} + (0)"); // 아이템으로 오른 방어력 반영 해주세요
            Console.WriteLine($"체력 : {Health}/{MaxHealth}");
            Console.WriteLine($"Gold : {Gold}G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            while (true)
            { 
            int exit = int.Parse(Console.ReadLine());
                switch (exit)
                { 
                case 0:
                        gamemanager.Start();
                            break;

                }
            }
        }
    }
}
