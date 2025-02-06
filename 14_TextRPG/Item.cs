using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    enum ItemType
    {
        Weapon = 40,
        Armor,
    }
    internal class Item
    {
        public string Name { get; } //아이템 이름
        public ItemType Itemtype { get; set; } //아이템 종류
        public string Info { get; } //아이템 설명
        public int Value { get; set; } //아이템 스텟
        public int Cost { get; set; } //아이템 가격
        public bool PlayerHave { get; set; } //플레이어가 소지 유무
        public bool PlayerUse { get; set; } //플레이어가 착용 유무
    }
}
