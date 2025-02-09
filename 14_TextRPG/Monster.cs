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
        public Monster(string name, int health, int maxHealth, int attack)
        {
            Name = name;
            Health = health;
            MaxHealth = maxHealth;
            Attack = attack;
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
