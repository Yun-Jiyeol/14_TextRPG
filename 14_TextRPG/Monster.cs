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
        public Monster(string name, string job,  int level, int health, int maxHealth, int attack, int defence)
        {
            Name = name;
            Class = job;
            Level = level;
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
            Defence = defence;

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
