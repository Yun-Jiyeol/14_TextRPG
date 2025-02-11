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
            {   //이지
                case 0: //순서대로      이름,직업,레벨,주는경험치,체력,최대체력,공격력,방어력
                    mons.Add(new Monster("(E) 레드 슬라임", "슬라임", 1, 3, 10, 10, 8, 1));
                    mons.Add(new Monster("(E) 옐로 슬라임", "슬라임", 1, 3, 12, 12, 6, 2));
                    mons.Add(new Monster("(E) 블루 슬라임", "슬라임", 1, 3, 12, 12, 6, 2));
                    mons.Add(new Monster("(E) 그린 슬라임", "슬라임", 1, 3, 10, 10, 8, 1));
                    break;
                case 1:
                    mons.Add(new Monster("(E) 레드 버섯", "버섯", 2, 5, 20, 20, 10, 1));
                    mons.Add(new Monster("(E) 블루 버섯", "버섯", 2, 5, 22, 22, 10, 2));
                    break;
                case 2:
                    mons.Add(new Monster("(E) 스네이크", "스네이크", 2, 4, 12, 12, 4, 3));
                    mons.Add(new Monster("(E) 좀비", "언데드", 1, 3, 11, 11, 7, 2));
                    mons.Add(new Monster("(E) 그린 버섯", "버섯", 2, 5, 20, 20, 10, 1));
                    break;
                case 3:
                    mons.Add(new Monster("(E) 스톤 골렘", "골렘", 2, 8, 40, 40, 12, 8));
                    break;
                case 4:
                    mons.Add(new Monster("(E) 스켈레톤", "언데드", 2, 5, 26, 26, 8, 4));
                    mons.Add(new Monster("(E) 스켈레톤", "언데드", 2, 5, 26, 26, 8, 4));
                    mons.Add(new Monster("(E) 좀비", "언데드", 2, 3, 20, 20, 8, 4));
                    break;
                case 5:
                    mons.Add(new Monster("(E) 새끼 거미", "거미", 3, 5, 19, 19, 8, 5));
                    mons.Add(new Monster("(E) 새끼 거미", "거미", 3, 5, 19, 19, 8, 5));
                    mons.Add(new Monster("(E) 새끼 거미", "거미", 3, 5, 19, 19, 8, 5));
                    mons.Add(new Monster("(E) 새끼 거미", "거미", 3, 5, 19, 19, 8, 5));
                    break;
                //노말
                case 6:
                    mons.Add(new Monster("(N) 고블린", "고블린", 5, 8, 30, 30, 12, 5));
                    mons.Add(new Monster("(N) 둔감한 고블린", "고블린", 5, 8, 30, 30, 8, 9));
                    mons.Add(new Monster("(N) 고블린", "고블린", 5, 8, 30, 30, 12, 5));
                    mons.Add(new Monster("(N) 난폭한 고블린", "고블린", 5, 8, 30, 30, 12, 5));
                    break;
                case 7:
                    mons.Add(new Monster("(N) 오크", "오크", 7, 10, 50, 50, 15, 10));
                    mons.Add(new Monster("(N) 고블린", "고블린", 5, 8, 30, 30, 12, 5));
                    mons.Add(new Monster("(N) 고블린", "고블린", 5, 8, 30, 30, 12, 5));
                    break;
                case 8:
                    mons.Add(new Monster("(N) 엘리트 오크", "오크", 10, 12, 70, 70, 10, 15));
                    break;
                case 9:
                    mons.Add(new Monster("(N) 늑대인간", "늑대인간", 8, 9, 40, 40, 15, 9));
                    mons.Add(new Monster("(N) 늑대인간", "늑대인간", 8, 9, 40, 40, 15, 9));
                    break;
                case 10:
                    mons.Add(new Monster("(N) 자이언트 골렘", "골렘", 7, 10, 85, 85, 10, 10));
                    break;
                case 11:
                    mons.Add(new Monster("(N) 블루 슬라임", "슬라임", 1, 3, 12, 12, 6, 2));
                    mons.Add(new Monster("(N) 대왕 거미", "거미", 9, 8, 60, 60, 10, 1));
                    break;
                //하드
                case 12:
                    mons.Add(new Monster("(H) 구울", "언데드", 8, 8, 50, 50, 15, 6));
                    mons.Add(new Monster("(H) 구울", "언데드", 8, 8, 50, 50, 15, 6));
                    mons.Add(new Monster("(H) 구울", "언데드", 8, 8, 50, 50, 15, 6));
                    mons.Add(new Monster("(H) 구울", "언데드", 8, 8, 50, 50, 15, 6));
                    break;
                case 13:
                    mons.Add(new Monster("(H) 드래곤", "드래곤", 12, 13, 75, 75, 18, 8));
                    mons.Add(new Monster("(H) 새끼 드래곤", "드래곤", 7, 10, 30, 30, 10, 3));
                    mons.Add(new Monster("(H) 새끼 드래곤", "드래곤", 7, 10, 30, 30, 10, 3));
                    break;
                case 14:
                    mons.Add(new Monster("(H) 가고일", "가고일", 10, 12, 60, 60, 12, 10));
                    mons.Add(new Monster("(H) 가고일", "가고일", 10, 12, 60, 60, 12, 10));
                    break;
                case 15:
                    mons.Add(new Monster("(H) 뱀파이어", "흡혈귀", 12, 10, 75, 75, 10, 10));
                    break;
                case 16:
                    mons.Add(new Monster("(H) 타락 기사", "타락 기사", 14, 15, 100, 100, 20, 13));
                    break;
                //보스
                case 17:    //이지
                    mons.Add(new Monster("(B) 대왕 슬라임", "슬라임", 7, 5, 60, 60, 10, 3));
                    break;
                case 18:    //노말
                    mons.Add(new Monster("(B) 네크로맨서", "강령술사", 12, 5, 80, 80, 10, 4));
                    break;
                case 19:    //하드
                    mons.Add(new Monster("(B) 벡스 Z 먼데시르타", "보스", 17, 5, 120, 120, 25, 10));
                    break;

            }
            return mons;
        }
    }
}
