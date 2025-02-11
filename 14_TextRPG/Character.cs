using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _14_TextRPG
{
    
    public class Character
    {
        public string Name { get; set; } //캐릭터 이름
        public string Class { get; set; } //캐릭터 직업
        public int Level { get; set; } //캐릭터 레벨
        public float Health { get; set; } //캐릭터 현제 체력
        public float MaxHealth { get; set; } //캐릭터 최대 체력
        public float Mana { get; set; } //캐릭터 현제 체력
        public float MaxMana { get; set; } //캐릭터 최대 체력
        public float ItemHealth { get; set; } //아이템으로 오른 체력
        public int Attack { get; set; } //캐릭터 공격력
        public int ItemAttack { get; set; } //아이템으로 오른 공격력
        public int Defence { get; set; } //캐릭터 방어력
        public int ItemDefence { get; set; } //아이템으로 오른 방어력
        public int Gold { get; set; } //캐릭터 소유 골드
        public bool isDead { get; set; } = false; //캐릭터 사망 유무
        public int Ex { get; set; } //플레이어 현제 경험치
        public int MaxEx { get; set; } //플레이어 렙업에 필요한 경험치
        public bool isEquip { get; set; } = false; //캐릭터 장비 장착 여부
        public int Avoid { get; set; } //회피확률
        public int Critical { get; set; } //치명타 확률
        public float CriDamage { get; set; } //치명타 확률
        public void Status(int i) //전투 때 보여지게끔 (몬스터)
        {
            DesignText.LeftDT($" [{Name}의 정보]", i, ConsoleColor.Gray);
            DesignText.LeftDT($"  LV.{Level} . {Class}", i+1, ConsoleColor.Gray);
            if (MaxEx > 0)
            {
                DesignText.LeftDT($"  경험치 : {Ex} / {MaxEx}", i + 2, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT($"  주는 경험치 : {Ex}", i + 2, ConsoleColor.Gray);
            }
            if (ItemHealth != 0) //장비 체력이 있을 시
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 3);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i + 3);
                Console.Write($"  체력: {Health} / {MaxHealth + ItemHealth}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"+({ItemHealth})");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"  마나 : {Mana} / {MaxMana}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 3);
                Console.WriteLine("┃");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 3);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i + 3);
                Console.Write($"  체력: {Health} / {MaxHealth}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"  마나 : {Mana} / {MaxMana}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 3);
                Console.WriteLine("┃");
            }
            if (ItemAttack != 0) //무기 공격력이 있을 시
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 4);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i + 4);
                Console.Write($"  공격력: {Attack + ItemAttack}");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"+({ItemAttack})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  약점 확률: {Critical}%");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 4);
                Console.WriteLine("┃");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 4);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(1, i + 4);
                Console.Write($"  공격력: {Attack}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  약점 확률: {Critical}%");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 4);
                Console.WriteLine("┃");
            }
            if (ItemDefence != 0) //무기 방어력이 있을 시
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 5);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(1, i + 5);
                Console.Write($"  방어력: {Defence + ItemDefence}");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"+({ItemDefence})");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  회피 확률: {Avoid}%");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 5);
                Console.WriteLine("┃");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, i + 5);
                Console.Write("┃");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(1, i + 5);
                Console.Write($"  방어력: {Defence}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  회피 확률: {Avoid}%");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(41, i + 5);
                Console.WriteLine("┃");
            }
            if (Gold >= 0)
            {
                DesignText.LeftDT($"  가진 돈: {Gold}G", i + 6, ConsoleColor.Yellow);
            }
        }
        public int TakeDamage(Character character, int i , bool isskill) //피해를 받는다면
        {
            Random random = new Random();

            if(Avoid < random.Next(1, 101) || isskill) //회피를 못할 시 또는 스킬일 시
            {
                float damage = i;
                if (character.Critical >= random.Next(1, 101)) //치명타 시
                {
                    damage *= character.CriDamage;
                }

                if (damage > ((Defence+ItemDefence) / 2)) //방어력보다 적을 시
                {
                    damage = damage - ((Defence + ItemDefence) / 2);
                }
                else
                {
                    damage = 0;
                }

                Health -= (int)damage; //damage만큼 데미지

                if (Health <= 0) //사망 시
                {
                    Health = 0;
                    isDead = true;
                }
                return (int)damage;
            }
            return -1;
        }
    }
}
