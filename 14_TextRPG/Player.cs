using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Player : Character
    {
        public int[] repeat = {1,1,1 };

        //public int Ex { get; set; } //플레이어 현제 경험치
        // public int MaxEx { get; set; } //플레이어 렙업에 필요한 경험치
        public Player()
        {
            Name = "플레이어";
            Class = "전사";
            Level = 01;
            Health = 100;
            MaxHealth = 100;
            Attack = 200; //태스트용 원펀맨
            Defence = 5;
            Gold = 1500;
        }
    }
}
