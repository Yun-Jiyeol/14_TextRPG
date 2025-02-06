using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    internal class Icharacter
    {
        public string Name { get;} //캐릭터 이름
        public string Class { get;} //캐릭터 직업
        public int Level { get; set; } //캐릭터 레벨
        public float Health { get; set; } //캐릭터 현제 체력
        public float MaxHealth { get; set; } //캐릭터 최대 체력
        public int Attack { get; set; } //캐릭터 공격력
        public int Defence { get; set; } //캐릭터 방어력
        public int Gold { get; set; } //캐릭터 소유 골드

    }
}
