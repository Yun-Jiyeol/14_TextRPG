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

        public void PlayerTurn(Player P, List<Monster> M, QuestManager quest) //플레이어의 턴
        {
            ShowNow(P,M);

            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT($"  {P.Name}의 차례입니다.", 12, ConsoleColor.Gray);
            DesignText.LeftDT("  할 행동을 선택하세요.", 13, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT("  1. 공격한다.", 15, ConsoleColor.Gray);
            DesignText.LeftDT("  2. 상태확인.", 16, ConsoleColor.Gray);
            DesignText.LeftDT("  3. 스킬창", 17, ConsoleColor.Gray);
            //Console.WriteLine("4. 아이템을 사용한다."); - 상태에서 가도 될듯?
            DesignText.LeftDT("  0. 도망간다.", 18, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┗━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┛");
            Console.ResetColor();

            Console.WriteLine();

            int input = Input.input(0,3);
            switch (input)
            {
                case 0:
                    ShowNow(P, M);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.LeftDT("  도망갈 시 몬스터들의 공격을", 12, ConsoleColor.Gray);
                    DesignText.LeftDT("  받을 수 있습니다.", 13, ConsoleColor.Gray);
                    DesignText.LeftDT("  그래도 도망 가겠습니까?", 14, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.LeftDT("  1. 계속 싸운다.", 17, ConsoleColor.Gray);
                    DesignText.LeftDT("  0. 도망간다.", 18, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("┗━");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("━┛");
                    Console.ResetColor();

                    Console.WriteLine();
                    int Rinput = Input.input(0, 1);
                    switch (Rinput)
                    {
                        case 0:
                            ShowNow(P, M); //기본 틀 생성
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("┗━");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("━┛");
                            Console.ResetColor();
                            int num = 0; //띄어쓰기용 함수
                            for (int i = 0; i < M.Count; i++)
                            {
                                if (!M[i].isDead)
                                {
                                    int tryAttack = random.Next(0,2);

                                    if(tryAttack == 0)
                                    {
                                        DesignText.LeftDT($"  {M[i].Name}이(가) {P.Name}를 공격을", 11 + num*2, ConsoleColor.Gray);
                                        DesignText.LeftDT($"  시도했으나 실패했습니다.", 12 + num * 2, ConsoleColor.Gray);
                                    }
                                    else
                                    {
                                        DesignText.LeftDT($"  {M[i].Name}이(가) {P.Name}를", 11 + num * 2, ConsoleColor.Gray);
                                        
                                        int damage = P.TakeDamage(M[i],M[i].Attack + M[i].ItemAttack); //얼마나 공격했는지
                                        if (damage == -1)
                                        {
                                            DesignText.LeftDT("  공격했으나 회피했다.", 12 + num * 2, ConsoleColor.Gray);
                                        }
                                        else
                                        {
                                            DesignText.LeftDT($"  {damage}만큼 공격을 했습니다!", 12 + num * 2, ConsoleColor.Gray);
                                        }
                                        DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}", 8, ConsoleColor.Gray);
                                    }
                                    num++;
                                    Thread.Sleep(1000);
                                }
                            }
                            Console.SetCursorPosition(0,21);
                            Console.WriteLine($"{P.Name}은(는) 마을로 도망갔습니다!");
                            DesignText.IsMove(10);
                            break;
                        case 1:
                            PlayerTurn(P,M,quest);
                            break;
                    }
                    break; //Battle로 복귀 후 바로 GameManager.Start()로 복귀하도록

                case 1:
                    ChooseAttack(P, M,quest);
                    break;

                case 2: //상태 확인
                    CheckState(P, M);
                    PlayerTurn(P,M, quest);
                    break;

                case 3: //상태 확인
                    ChooseSkill(P, M, quest);
                    break;
            }
        }

        public void CheckState(Player P, List<Monster> M)
        {
            int num = 0;
            int maxnum = M.Count; //확인할 스탯의 최대치
            bool ischecking = true;

            while (ischecking)
            {
                ShowNow(P, M); //기본 틀 생성
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┗━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┛");
                Console.ResetColor();

                switch (num)
                {
                    case 0:
                        DesignText.LeftDT($" - {P.Name}", 7, ConsoleColor.Yellow);
                        DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}", 8, ConsoleColor.Yellow);
                        P.Status(11); //플레이어 정보 소환
                        break;
                    default: //num번째 몬스터 보기
                        if (!M[num-1].isDead)
                        {
                            DesignText.RightDT($"{M[num-1].Name} : {M[num-1].Health} / {M[num - 1].MaxHealth}", num + 1, ConsoleColor.Yellow);
                        }
                        else
                        {
                            DesignText.RightDT($"{M[num - 1].Name} : {M[num - 1].Health} / {M[num - 1].MaxHealth}", num+1, ConsoleColor.DarkYellow);
                        }
                        M[num-1].Status(11); //몬스터 정보 소환
                        break;
                }
                DesignText.LeftDT("   1. 이전      0.나가기      2.다음", 19, ConsoleColor.Gray);

                Console.SetCursorPosition(0,22);
                int input = Input.input(0, 2);
                switch (input)
                {
                    case 0:
                        ischecking = false; //나가기
                        break;
                    case 1: //이전
                        num--;
                        if(num < 0)
                        {
                            num = maxnum;
                        }
                        break;
                    case 2: //이후
                        num++;
                        if(num > maxnum)
                        {
                            num = 0;
                        }
                        break;
                }
            }
        }
        public void ChooseSkill(Player P, List<Monster> M, QuestManager quest)
        {
            ShowNow(P, M); //기본 틀 생성
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT($"  1. {P.bigswing.Name} ({P.bigswing.UseMana})", 12, ConsoleColor.Gray);
            if(P.Mana >= P.bigswing.UseMana) //마나가 충분한가?
            {
                DesignText.LeftDT($"    - {P.bigswing.Explain}", 13, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT("    - 마나가 부족합니다.", 13, ConsoleColor.DarkGray);
            }
            DesignText.LeftDT($"  2. {P.powerShot.Name} ({P.powerShot.UseMana})", 14, ConsoleColor.Gray);
            if (P.Mana >= P.powerShot.UseMana)
            {
                DesignText.LeftDT($"    - {P.powerShot.Explain}", 15, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT("    - 마나가 부족합니다.", 15, ConsoleColor.DarkGray);
            }
            DesignText.LeftDT("  0. 돌아간다.", 16, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┗━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┛");
            Console.ResetColor();

            Console.WriteLine();

            int input = Input.input(0, 2);
            switch (input)
            {
                case 0:
                    PlayerTurn(P,M,quest);
                    break;
                case 1:
                    DesignText.IsMove(5);
                    ShowNow(P, M); //기본 틀 생성
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("┗━");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("━┛");
                    Console.ResetColor();
                    DesignText.LeftDT($"  {P.Name}은(는) 크게 배었습니다", 12, ConsoleColor.Gray);
                    bool isAllDead = true;
                    for (int i = 0; i < M.Count; i++)
                    {
                        if (M[i].isDead) //몬스터가 사망 상태라면
                        {
                            DesignText.LeftDT($"  {M[i].Name}은(는) 이미 죽어 있습니다.", 13 + i, ConsoleColor.Gray);
                        }
                        else
                        {
                            int attackDamage = random.Next((P.Attack + P.ItemAttack) * 90, (P.Attack + P.ItemAttack) * 110);
                            attackDamage = (attackDamage /100) * P.bigswing.Damage; //스킬 계수
                            if (attackDamage % 100 != 0)
                            {
                                attackDamage = (attackDamage / 100) + 1;
                            }
                            else
                            {
                                attackDamage = (attackDamage / 100);
                            }
                            int Damage = M[i].TakeDamage(P, attackDamage);

                            if (Damage == -1) //회피시
                            {
                                DesignText.LeftDT($"  {M[i].Name}은 회피했습니다.", 13 + i, ConsoleColor.Gray);
                            }
                            else
                            {
                                DesignText.LeftDT($"  {M[i].Name}에게 {Damage}만큼 공격", 13 + i, ConsoleColor.Gray);
                            }
                            if (M[input - 1].isDead) //몬스터가 죽을 시
                            {
                                P.GetEx(M[input - 1].Ex);
                                quest.KillMonster();
                            }
                        }
                        Thread.Sleep(500);
                    }
                    DesignText.LeftDT("  몬스터들의 공격이 시작합니다.", 18, ConsoleColor.Gray);
                    Console.SetCursorPosition(0, 22);
                    DesignText.IsMove(10);
                    MonsterTurn(P, M, quest); //몬스터의 턴으로

                    break;
                case 2:
                    break;
            }
        }
        public void ChooseAttack(Player P, List<Monster> M, QuestManager quest) //플레이어의 턴
        {
            ShowNow(P, M); //기본 틀 생성
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            for (int i = 0; i < M.Count; i++)
            {
                DesignText.LeftDT($"  {i+1}. {M[i].Name}", 12+i, ConsoleColor.Gray);
            }
            for(int i = M.Count; i < 4; i++)
            {
                DesignText.LeftDT("", 12 + i, ConsoleColor.Gray);
            }
            DesignText.LeftDT("  0. 돌아간다.", 16, ConsoleColor.Gray);
            DesignText.LeftDT($"  {P.Name}의 공격!", 17, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┗━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┛");
            Console.ResetColor();

            Console.WriteLine();
            int input = Input.input(0,M.Count);

            switch (input)
            {
                case 0:
                    PlayerTurn(P, M, quest);
                    break;
                default:
                    ShowNow(P, M); //기본 틀 생성
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.LeftDT($"  {P.Name}은(는)", 12, ConsoleColor.Gray);
                    DesignText.LeftDT($"  {M[input - 1].Name}을 공격했습니다.", 13, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("┗━");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("━┛");
                    Console.ResetColor();

                    if (M[input - 1].isDead) //몬스터가 사망 상태라면
                    {
                        Thread.Sleep(500);
                        DesignText.LeftDT($"  {M[input - 1].Name}은(는) 이미 죽어 있습니다.", 15, ConsoleColor.Gray);
                        DesignText.LeftDT("  다른 몬스터를 선택하세요.", 16, ConsoleColor.Gray);
                        Console.SetCursorPosition(0,22);
                        DesignText.IsMove(10);
                        ChooseAttack(P,M, quest); // 다시 선택창으로
                    }
                    else //공격 진행
                    {
                        //플레이어의 데미지의 90% ~ 110% 사이의 데미지(올림값)를 몬스터에게 준다
                        int attackDamage = random.Next((P.Attack + P.ItemAttack) * 90, (P.Attack + P.ItemAttack) * 110);
                        if (attackDamage % 100 != 0)
                        {
                            attackDamage = (attackDamage / 100) + 1;
                        }
                        else
                        {
                            attackDamage = (attackDamage / 100);
                        }
                        int Damage = M[input - 1].TakeDamage(P,attackDamage);

                        ShowNow(P, M); //기본 틀 생성
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.LeftDT($"  {P.Name}은(는)", 12, ConsoleColor.Gray);
                        DesignText.LeftDT($"  {M[input - 1].Name}을 공격했습니다.", 13, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("┗━");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("━┛");
                        Console.ResetColor();

                        if(Damage == -1) //회피시
                        {
                            DesignText.LeftDT($"  {M[input-1].Name}은 회피했습니다.", 14, ConsoleColor.Gray);
                        }
                        else
                        {
                            DesignText.LeftDT($"  {Damage}만큼 공격을 했습니다.", 14, ConsoleColor.Gray);
                        }

                        Thread.Sleep(1500);

                        if (M[input - 1].isDead) //몬스터가 죽을 시
                        {
                            DesignText.LeftDT($"  {M[input - 1].Name}은(는) 죽었습니다.", 16, ConsoleColor.Gray);
                            
                            if (P.GetEx(M[input - 1].Ex)) //랩업 시
                            {
                                DesignText.LeftDT($"  레밸{P.Level}이 되었습니다!", 17, ConsoleColor.Gray);
                                DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}     ", 8, ConsoleColor.Gray);
                            }
                            else
                            {
                                DesignText.LeftDT($"  {M[input - 1].Ex}의 경험치를 얻었습니다.", 17, ConsoleColor.Gray);
                            }

                            quest.KillMonster();

                            bool isAllDead = true;
                            foreach (Monster m in M) //모든 몬스터가 사망 시
                            {
                                if (!m.isDead)
                                {
                                    isAllDead = false;
                                }
                            }
                            if (!isAllDead) //모든 몬스터가 죽지 않을 시
                            {
                                DesignText.LeftDT("  몬스터들의 공격이 시작합니다.", 18, ConsoleColor.Gray);
                                Console.SetCursorPosition(0, 22);
                                DesignText.IsMove(10);
                                MonsterTurn(P, M, quest); //몬스터의 턴으로
                            }
                        }
                        else //죽지 않을 시
                        {
                            DesignText.LeftDT("  몬스터들의 공격이 시작합니다.", 18, ConsoleColor.Gray);
                            Console.SetCursorPosition(0, 22);
                            DesignText.IsMove(10);
                            MonsterTurn(P, M, quest); //몬스터의 턴으로
                        }
                    }
                break;
            }
        }

        public void MonsterTurn(Player P, List<Monster> M, QuestManager quest) //몬스터의 턴
        {
            int num = 0;

            ShowNow(P, M); //기본 틀 생성
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT("  몬스터들의 공격!", 12, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┗━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┛");
            Console.ResetColor();

            for (int i = 0; i < M.Count; i++)
            {
                if (!M[i].isDead)
                {
                    int damage = P.TakeDamage(M[i], M[i].Attack + M[i].ItemAttack); //얼마나 공격했는지
                    if (damage == -1)
                    {
                        DesignText.LeftDT("  공격했으나 회피했다.", 14 + num, ConsoleColor.Gray);
                    }
                    else
                    {
                        DesignText.LeftDT($"  {damage}만큼 공격을 했습니다!", 14 + num, ConsoleColor.Gray);
                    }
                    if (P.isDead)
                    {
                        DesignText.LeftDT($" - {P.Name}", 7, ConsoleColor.DarkGray);
                        DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}     ", 8, ConsoleColor.DarkRed);
                        Console.SetCursorPosition(0,22);
                        Console.WriteLine($"{P.Name}이 사망하였습니다.");
                        Console.WriteLine("게임을 종료합니다.");
                        Console.WriteLine("아무 키나 입력하세요....");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}     ", 8, ConsoleColor.Gray);
                    Thread.Sleep(1500);
                    num++;
                    //P.isDead == true 면 겜 종료
                }
            }
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("플레이어의 차례입니다!");
            DesignText.IsMove(10);
            PlayerTurn(P,M, quest); //다시 플레이어 턴으로
        }
        public void ShowNow(Player P, List<Monster> M)  //화면 위쪽을 만들어줄 함수
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┏━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┓");
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);

            for (int i = 0; i < M.Count; i++) //몬스터 상태보기
            {
                if (!M[i].isDead)
                {
                    DesignText.RightDT($"{M[i].Name} : {M[i].Health} / {M[i].MaxHealth}", 2 + i, ConsoleColor.Gray);
                }
                else
                {
                    DesignText.RightDT($"{M[i].Name} : {M[i].Health} / {M[i].MaxHealth}", 2 + i, ConsoleColor.DarkGray);
                }
            }
            for (int i = M.Count; i < 4; i++) //몬스터 및 플레이어 상태보기
            {
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            }
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT($" - {P.Name}", 7, ConsoleColor.Gray);
            DesignText.LeftDT($"     HP: {P.Health} / {P.MaxHealth + P.ItemHealth}", 8, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("┣━");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("━┫");
        }
    }
}
