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

            List<Monster> monsters = new List<Monster>();
            monsters.Add(new Monster("슬라임", 100, 100, 10));
            monsters.Add(new Monster("주황버섯", 100, 100, 10));
            monsters.Add(new Monster("초록버섯", 100, 100, 10));
            monsters.Add(new Monster("스톤 골렘", 100, 100, 10));
            monsters.Add(new Monster("타우로마시스", 100, 100, 10));
            monsters.Add(new Monster("주니어 발록", 100, 100, 10));


        }
        
        public string MonsDisplay()
        {
            string str = $"{Name}  HP {Health}";
            return str;    
        }

        
    }
}
