using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Battle
    {
        List<Monster> monsInfo = new List<Monster>();//배틀 몬스터 배치

        public void SpawnMons(Monster monster)
        {
            Random random = new Random();

            int monsNum = random.Next(1, 5);//몬스터 마리수 지정

            for (int i = 0; i < monsNum; i++)//몬스터 수 만큼 실행
            {
                int index = random.Next(0, 7);

                monsInfo[index].MonsDisplay();
            }
        }
    }
}
