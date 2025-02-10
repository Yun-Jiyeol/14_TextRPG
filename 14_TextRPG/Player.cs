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

        public Player()
        {
            Name = "플레이어";
            Class = "전사";
            Ex = 0;
            MaxEx = 10;
            Level = 01;
            Health = 100;
            MaxHealth = 100;
            Attack = 200; //태스트용 원펀맨
            Defence = 5;
            Gold = 1500;
        }

        public void GetHeal(int heal)
        {
            Health += heal;
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        public bool GetEx(int _ex)
        {
            Ex += _ex; 
            if(MaxEx <= Ex)
            {
                Level++; //래벨업
                Ex -= MaxEx; //현제 경험치 감소
                MaxEx += (MaxEx/10)*3;

                MaxHealth += 10; //스탯증가
                Attack += 1;
                Defence += 1;
                int LevelupHeal = (int)MaxHealth / 3;
                GetHeal(LevelupHeal); //랩업시 회복(최대 체력의 1/3)
                return true;
            }
            return false; //랩업 실패
        }
    }
}
