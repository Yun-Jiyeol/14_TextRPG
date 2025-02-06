using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    internal class Turn
    {
        GameManager gamemanager = new GameManager();

        public void PlayerTurn(Player P, Monster[] M) //플레이어의 턴
        {
            Console.Clear();

            for (int i = 0; i < M.Length; i++) //몬스터 및 플레이어 상태보기
            {
                Console.WriteLine($"- {M[i].Name} : {M[i].Health} / {M[i].MaxHealth}");
            }
            Console.WriteLine();
            Console.WriteLine($"- {P.Name} : {P.Health} / {P.MaxHealth + P.ItemHealth}");
            Console.WriteLine();

            Console.WriteLine("1. 공격한다.");
            //Console.WriteLine("2. 스킬을 사용한다.");
            //Console.WriteLine("3. 아이템을 사용한다.");
            Console.WriteLine("0. 도망간다.");

            Console.WriteLine($"{P.Name}의 공격 차례입니다. 할 행동을 선택하세요.");

            int input = gamemanager.Input(1);
            switch (input)
            {
                case 0:
                    Console.WriteLine($"{P.Name}은(는) 마을로 도망갔습니다!");
                    gamemanager.Start(); //마을로 이동
                    break;

                case 1:
                    ChooseAttack(P, M);
                    break;
            }
        }
        public void ChooseAttack(Player P, Monster[] M) //플레이어의 턴
        {
            Console.Clear();

            for (int i = 0; i < M.Length; i++) //몬스터 및 플레이어 상태보기
            {
                Console.WriteLine($"{i}. {M[i].Name} : {M[i].Health} / {M[i].MaxHealth}");
            }
            Console.WriteLine("0. 돌아간다.");
            Console.WriteLine();

            Console.WriteLine($"{P.Name}은(는) 공격을 선택했습니다.");
            Console.WriteLine("누굴 공격하겠습니까?");

            int input = gamemanager.Input(M.Length);
            switch (input)
            {
                case 0:
                    PlayerTurn(P, M);
                    break;
                default:
                    Console.WriteLine($"{P.Name}은(는) {M[input].Name}을 공격했습니다.");

                    if (M[input].Health == 0) //M[i].IsDead //몬스터가 사망 상태라면
                    {
                        Console.WriteLine($"{M[input].Name}은(는) 이미 죽어 있습니다.");
                        ChooseAttack(P,M); // 다시 선택창으로
                    }
                    else
                    {
                        //M[input].TakeDamage(P.Attack + P.ItemAttack);
                    }

                    MonsterTurn(P, M);
                    break;
            }
        }

        public void MonsterTurn(Player P, Monster[] M) //몬스터의 턴
        {
            for (int i = 0; i < M.Length; i++){
                Console.Clear();

                for (int j = 0; j < M.Length; j++) //몬스터 및 플레이어 상태보기
                {
                    Console.WriteLine($"- {M[j].Name} : {M[j].Health} / {M[j].MaxHealth}");
                }
                Console.WriteLine();
                Console.WriteLine($"- {P.Name} : {P.Health} / {P.MaxHealth + P.ItemHealth}");
                Console.WriteLine();

                Console.WriteLine("몬스터의 턴입니다.");
                Console.WriteLine();

                if (M[i].Health != 0) //!M[i].IsDead
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"{M[i].Name}의 공격!");
                    //P.TakeDamage(M[i].Attack);
                }
            }
        }
    }
}
