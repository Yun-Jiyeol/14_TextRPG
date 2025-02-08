using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Battle
    {
        public List<Monster> SpawnMons()
        {
            List<Monster> mons = new List<Monster>();

            Random random = new Random();

            int monsNum = random.Next(1, 5);//몬스터 마리수 지정

            for (int i = 0; i < monsNum; i++)//몬스터 수 만큼 실행
            {
                int index = random.Next(0,6); //최소 최대 받아서 for문으로 몬스터 종류 조정해도 될듯

                switch (index)
                {
                    case 0:
                        mons.Add(new Monster("슬라임", 100, 100, 10));
                        break;
                    case 1:
                        mons.Add(new Monster("주황버섯", 100, 100, 10));
                        break;
                    case 2:
                        mons.Add(new Monster("초록버섯", 100, 100, 10));
                        break;
                    case 3:
                        mons.Add(new Monster("스톤 골렘", 100, 100, 10));
                        break;
                    case 4:
                        mons.Add(new Monster("타우로마시스", 100, 100, 10));
                        break;
                    case 5:
                        mons.Add(new Monster("주니어 발록", 100, 100, 10));
                        break;
                }
            }
            return mons;
        }
    }
}
