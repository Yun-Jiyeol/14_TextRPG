using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public enum ItemType
    {
        Weapon = 10,
        Shield = 20,
        Armor = 30
    }
    
    public class Item
    {
        public string Name { get; } //아이템 이름
        public ItemType Itemtype { get; } //아이템 종류
        public string Info { get; } //아이템 설명
        public int Value { get; } //아이템 스텟
        public int Cost { get; } //아이템 가격
        public bool PlayerHave { get; set; } //플레이어가 소지 유무
        public bool PlayerUse { get; set; } //플레이어가 착용 유무

        /// <summary>
        /// 생성자
        /// 아이템 클래스를 생성할 때 아이템의 정보를 적용
        /// </summary>
        /// <param name="_name">아이템 이름</param>
        /// <param name="_itemType">아이템 종류</param>
        /// <param name="_itemInfo">아이템 설명</param>
        /// <param name="_value">아이템 능력치</param>
        /// <param name="_cost">아이템 가격</param>
        public Item(string _name, int _itemType, string _itemInfo, int _value, int _cost)
        {
            Name = _name;
            Itemtype = (ItemType)_itemType;
            Info = _itemInfo;
            Value = _value;
            Cost = _cost;
            PlayerHave = false;
            PlayerUse = false;
        }

        public int Buy(int _holdingGold)
        {
            if ((!PlayerHave))
            {
                if (_holdingGold - Cost >= 0)
                {
                    // 인벤토리에 아이템 추가
                    PlayerHave = true;
                    Console.WriteLine("구매를 완료했습니다.");
                    return _holdingGold - Cost;
                }
                else
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            
            return _holdingGold;
        }

        public void Use()
        {
            if(PlayerUse)
            {

            }
        }
    }
}
