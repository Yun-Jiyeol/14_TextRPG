using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Monster : Character
    {
        public Monster()
        {

        }
        public Monster(string name, string job,  int level, int ex , int health, int maxHealth, int attack, int defence)
        {
            Name = name;
            Class = job;
            Level = level;
            Ex = ex; //주는 경험지 양
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
            Defence = defence;
            
            MaxEx = 0;
            Gold = -1;
        }

        public string MonsDisplay()
        {
            //몬스터 - 이름 체력
            string str = $"{Name}  HP {Health}";
            return str;
        }


    }
}
