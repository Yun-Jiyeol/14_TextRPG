using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _14_TextRPG
{
    public class Turn
    {
        Random random = new Random();

        public void PlayerTurn(Player P, Monster[] M) //플레이어의 턴
        {
            Console.Clear();

            for (int i = 0; i < M.Length; i++) //몬스터 및 플레이어 상태보기
            {
                if (M[i].Health > 0) // !M[i].isDead
                {
                    Console.WriteLine($"- {M[i].Name} : {M[i].Health} / {M[i].MaxHealth}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"DEAD - {M[i].Name} : {M[i].Health} / {M[i].MaxHealth}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"- {P.Name} : {P.Health} / {P.MaxHealth + P.ItemHealth}");
            Console.WriteLine();

            Console.WriteLine("1. 공격한다.");
            //Console.WriteLine("2. 스킬을 사용한다.");
            //Console.WriteLine("3. 아이템을 사용한다.");
            Console.WriteLine("0. 도망간다.");

            Console.WriteLine($"{P.Name}의 공격 차례입니다. 할 행동을 선택하세요.");

            int input = Input.input(0,1);
            switch (input)
            {
                case 0:
                    Console.WriteLine("도망갈 시 몬스터의 공격을 받을 수 있습니다.");
                    Console.WriteLine("그래도 도망 가겠습니까?");
                    Console.WriteLine();
                    Console.WriteLine("1. 계속 싸운다.");
                    Console.WriteLine("0. 도망간다.");
                    int Rinput = Input.input(0, 1);
                    switch (Rinput)
                    {
                        case 0:
                            for(int i = 0; i < M.Length; i++)
                            {
                                if (!M[i].isDead)
                                {
                                    int tryAttack = random.Next(0,2);

                                    if(tryAttack == 0)
                                    {
                                        Console.WriteLine($"{M[i].Name}이(가) {P.Name}를 공격을 시도했으나 실패했습니다.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{M[i].Name}이(가) {P.Name}를 공격을 했습니다!");
                                        //P.TakeDamage(M[i].Attack);
                                    }
                                    Thread.Sleep(500);
                                }
                            }
                            Console.WriteLine($"{P.Name}은(는) 마을로 도망갔습니다!");
                            Console.WriteLine("아무키나 입력하세요.");
                            Console.ReadKey();
                            break;
                        case 1:
                            PlayerTurn(P,M);
                            break;
                    }
                    break; //Battle로 복귀 후 바로 GameManager.Start()로 복귀하도록

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
                for (int j = 0; j < M.Length; j++) //몬스터 및 플레이어 상태보기
                {
                    if (M[j].Health > 0) // !M[j].isDead
                    {
                        Console.WriteLine($"{j}. {M[j].Name} : {M[j].Health} / {M[j].MaxHealth}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"DEAD {j}. - {M[j].Name} : {M[j].Health} / {M[j].MaxHealth}");
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("0. 돌아간다.");
            Console.WriteLine();

            Console.WriteLine($"{P.Name}은(는) 공격을 선택했습니다.");
            Console.WriteLine("누굴 공격하겠습니까?");

            int input = Input.input(0,M.Length);
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
                        Console.WriteLine("아무키나 입력하세요.");
                        Console.ReadKey();
                        ChooseAttack(P,M); // 다시 선택창으로
                    }
                    else //공격 진행
                    {
                        //플레이어의 데미지의 90% ~ 110% 사이의 데미지(올림값)를 몬스터에게 준다
                        //int attackDamage = random.Next((P.Attack + P.ItemAttack) * 9, (P.Attack + P.ItemAttack) * 11); 
                        //if(attackDamage % 10 != 0)
                        //{
                        //    attackDamage = (attackDamage / 10) + 1;
                        //}
                        //else
                        //{
                        //    attackDamage = (attackDamage / 10);
                        //}
                        //M[input].TakeDamage(attackDamage);

                        Thread.Sleep(500);

                        if (M[input].Health == 0) //몬스터가 죽을 시
                        {
                            Console.WriteLine($"{M[input].Name}은 {P.Name}의 공격으로 인하여 죽었습니다.");

                            bool isAllDead = true;
                            foreach (Monster m in M) //모든 몬스터가 사망 시
                            {
                                if (m.Health > 0)
                                {
                                    isAllDead = false;
                                }
                            }
                            if (isAllDead)
                            {
                                Victory(P,M);
                            }
                            else
                            {
                                Console.WriteLine("아무키나 입력하세요.");
                                Console.ReadKey();
                                MonsterTurn(P, M); //몬스터의 턴으로
                            }
                        }
                        else //죽지 않을 시
                        {
                            Console.WriteLine("아무키나 입력하세요.");
                            Console.ReadKey();
                            MonsterTurn(P, M); //몬스터의 턴으로
                        }
                    }
                break;
            }
        }

        public void MonsterTurn(Player P, Monster[] M) //몬스터의 턴
        {
            for (int i = 0; i < M.Length; i++){
                Console.Clear();

                for (int j = 0; j < M.Length; j++) //몬스터 및 플레이어 상태보기
                {
                    if (M[j].Health > 0) // !M[j].isDead
                    {
                        Console.WriteLine($"- {M[j].Name} : {M[j].Health} / {M[j].MaxHealth}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"DEAD - {M[j].Name} : {M[j].Health} / {M[j].MaxHealth}");
                        Console.ResetColor();
                    }
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
            Console.WriteLine("아무키나 입력하세요.");
            Console.ReadKey();
            PlayerTurn(P,M); //다시 플레이어 턴으로
        }
        public void Victory(Player P, Monster[] M)
        {
            Console.WriteLine($"{P.Name}은 모든 몬스터를 잡고 마을로 돌아갔습니다.");
            Console.WriteLine("아무키나 입력하세요.");
            Console.ReadKey();//Battle로 복귀 후 바로 GameManager.Start()로 복귀하도록
        }
    }
}
