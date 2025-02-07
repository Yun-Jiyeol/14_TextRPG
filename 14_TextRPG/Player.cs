using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Player : Character
    {
        public float ItemHealth { get; set; } //아이템으로 오른 체력
        public int ItemAttack { get; set; } //아이템으로 오른 공격력
        public int ItemDefence { get; set; } //아이템으로 오른 방어력
        //public int Ex { get; set; } //플레이어 현제 경험치
        // public int MaxEx { get; set; } //플레이어 렙업에 필요한 경험치
    }
}
