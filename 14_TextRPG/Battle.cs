using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Battle
    {
        public List<Monster> SpawnMons(int min, int max)
        {
            List<Monster> mons = new List<Monster>();

            Random random = new Random();

            int index = random.Next(min, max); //최소 최대 받아서 for문으로 몬스터 종류 조정해도 될듯

            switch (index)
            {
                case 0: //순서대로 이름,직업,레밸,주는경험치,체력,최대체력,공격력,방어력
                    mons.Add(new Monster("(E) 레드 슬라임", "슬라임", 1, 3, 8, 8, 6, 1));
                    mons.Add(new Monster("(E) 옐로 슬라임", "슬라임", 1, 3, 12, 12, 4, 3));
                    mons.Add(new Monster("(E) 블루 슬라임", "슬라임", 1, 3, 12, 12, 4, 3));
                    mons.Add(new Monster("(E) 그린 슬라임", "슬라임", 1, 3, 8, 8, 6, 1));
                    break;
                case 1:
                    mons.Add(new Monster("(E) 초록버섯", "버섯", 1, 5, 20, 20, 10, 1));
                    mons.Add(new Monster("(E) 파란버섯", "버섯", 1, 5, 22, 22, 10, 2));
                    break;
                case 2:
                    mons.Add(new Monster("(E) 옐로슬라임", "슬라임", 1, 3, 12, 12, 4, 3));
                    mons.Add(new Monster("(E) 그린슬라임", "슬라임", 1, 3, 8, 8, 6, 1));
                    mons.Add(new Monster("(E) 초록버섯", "버섯", 1, 5, 20, 20, 10, 1));
                    break;
                case 3:
                    mons.Add(new Monster("(E) 스톤 골렘", "골렘", 2, 8, 80, 80, 12, 8));
                    break;
                case 4:
                    mons.Add(new Monster("(E) 타우로마시스", "타우로마시스", 2, 8, 40, 40, 18, 4));
                    break;
                case 5:
                    mons.Add(new Monster("(E) 주니어 발록", "발록", 3, 10, 60, 60, 16, 6));
                    break;
                case 6:
                    mons.Add(new Monster("(N) 슬라임", "슬라임", 1, 5, 100, 100, 10, 1));
                    break;
                case 7:
                    mons.Add(new Monster("(N) 주황 버섯", "버섯", 1, 5, 100, 100, 10, 1));
                    break;
                case 8:
                    mons.Add(new Monster("(N) 초록 버섯", "버섯", 1, 5, 100, 100, 10, 1));
                    break;
                case 9:
                    mons.Add(new Monster("(N) 스톤 골렘", "골렘", 1, 5, 100, 100, 10, 1));
                    break;
                case 10:
                    mons.Add(new Monster("(N) 타우로마시스", "타우로마시스", 1, 5, 100, 100, 10, 1));
                    break;
                case 11:
                    mons.Add(new Monster("(N) 주니어 발록", "발록", 1, 5, 100, 100, 10, 1));
                    break;
                case 12:
                    mons.Add(new Monster("(H) 슬라임", "슬라임", 1, 5, 100, 100, 10, 1));
                    break;
                case 13:
                    mons.Add(new Monster("(H) 주황 버섯", "버섯", 1, 5, 100, 100, 10, 1));
                    break;
                case 14:
                    mons.Add(new Monster("(H) 초록 버섯", "버섯", 1, 5, 100, 100, 10, 1));
                    break;
                case 15:
                    mons.Add(new Monster("(H) 스톤 골렘", "골렘", 1, 5, 100, 100, 10, 1));
                    break;
                case 16:
                    mons.Add(new Monster("(H) 타우로마시스", "타우로마시스", 1, 5, 100, 100, 10, 1));
                    break;
                case 17:
                    mons.Add(new Monster("(H) 주니어 발록", "발록", 1, 5, 100, 100, 10, 1));
                    break;
            }
            return mons;
        }
    }
}
