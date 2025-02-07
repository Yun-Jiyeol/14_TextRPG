using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Monster : Character
    {
        public Monster(Character character)
        {
            if (character.Level >= 5) //캐릭터의 레벨이 5이하일 때
            {
                Name = "슬라임";
                Health = 100;
                MaxHealth = 100;
                Attack = 10;
            }
            else if (character.Level >= 10)//캐릭터의 레벨이 10이하일 때
            {
                Name = "스톤 골렘";
                Health = 300;
                MaxHealth = 300;
                Attack = 20;
            }
            else
            {
                ////캐릭터의 레벨이 6 이상, 9이하일 때
                Name = "초록 버섯";
                Health = 200;
                MaxHealth = 200;
                Attack = 15;
            }
        }
            
    }
}
