using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    
    public class Character
    {
        public string Name { get; set; } //캐릭터 이름
        public string Class { get; set; } //캐릭터 직업
        public int Level { get; set; } //캐릭터 레벨
        public float Health { get; set; } //캐릭터 현제 체력
        public float MaxHealth { get; set; } //캐릭터 최대 체력
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
                DesignText.LeftDT($"  체력: {Health + ItemHealth} / {MaxHealth} + ({ItemHealth})", i + 3, ConsoleColor.DarkRed);
            }
            else
            {
                DesignText.LeftDT($"  체력: {Health} / {MaxHealth}", i + 3, ConsoleColor.DarkRed);
            }
            if (ItemAttack != 0) //무기 공격력이 있을 시
            {
                DesignText.LeftDT($"  공격력: {Attack + ItemAttack} + ({ItemAttack})", i + 4, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT($"  공격력: {Attack}", i + 4, ConsoleColor.Gray);
            }
            if (ItemDefence != 0) //무기 방어력이 있을 시
            {
                DesignText.LeftDT($"  방어력: {Defence + ItemDefence} + ({ItemDefence})", i + 5, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT($"  방어력: {Defence}", i + 5, ConsoleColor.Gray);
            }
            if (Gold >= 0)
            {
                DesignText.LeftDT($"  가진 돈: {Gold}G", i + 6, ConsoleColor.Yellow);
            }
        }
        public void TakeDamage(int i) //피해를 받는다면
        {
            if(i > (Defence / 2))
            {
                i = i - (Defence / 2);
            }
            else
            {
                i = 0;
            }

            Health -= i; //i만큼 데미지

            if (Health <= 0) //사망 시
            {
                Health = 0;
                isDead = true;
            }
        }
    }
}
