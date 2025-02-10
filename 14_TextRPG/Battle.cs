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

            int monsNum = random.Next(1, 5);//몬스터 마리수 지정

            for (int i = 0; i < monsNum; i++)//몬스터 수 만큼 실행
            {
                int index = random.Next(min,max); //최소 최대 받아서 for문으로 몬스터 종류 조정해도 될듯

                switch (index)
                {
                    case 0:
                        mons.Add(new Monster("E슬라임", 100, 100, 10));
                        break;
                    case 1:
                        mons.Add(new Monster("E주황버섯", 100, 100, 10));
                        break;
                    case 2:
                        mons.Add(new Monster("E초록버섯", 100, 100, 10));
                        break;
                    case 3:
                        mons.Add(new Monster("E스톤 골렘", 100, 100, 10));
                        break;
                    case 4:
                        mons.Add(new Monster("E타우로마시스", 100, 100, 10));
                        break;
                    case 5:
                        mons.Add(new Monster("E주니어 발록", 100, 100, 10));
                        break;
                    case 6:
                        mons.Add(new Monster("N슬라임", 200, 100, 10));
                        break;
                    case 7:
                        mons.Add(new Monster("N주황버섯", 200, 100, 10));
                        break;
                    case 8:
                        mons.Add(new Monster("N초록버섯", 200, 100, 10));
                        break;
                    case 9:
                        mons.Add(new Monster("N스톤 골렘", 200, 100, 10));
                        break;
                    case 10:
                        mons.Add(new Monster("N타우로마시스", 200, 100, 10));
                        break;
                    case 11:
                        mons.Add(new Monster("N주니어 발록", 200, 100, 10));
                        break;
                    case 12:
                        mons.Add(new Monster("H슬라임", 300, 100, 10));
                        break;
                    case 13:
                        mons.Add(new Monster("H주황버섯", 300, 100, 10));
                        break;
                    case 14:
                        mons.Add(new Monster("H초록버섯", 300, 100, 10));
                        break;
                    case 15:
                        mons.Add(new Monster("H스톤 골렘", 300, 100, 10));
                        break;
                    case 16:
                        mons.Add(new Monster("H타우로마시스", 300, 100, 10));
                        break;
                    case 17:
                        mons.Add(new Monster("H주니어 발록", 300, 100, 10));
                        break;
                }
            }
            return mons;
        }
    }
}
