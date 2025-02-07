using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    /// <summary>
    /// 아이템 종류를 나누는 열거형
    /// </summary>
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
        public bool SaleItem { get; }   // 상점에서 판매하는 물품인지 아닌지

        /// <summary>
        /// 생성자
        /// 아이템 클래스를 생성할 때 아이템의 정보를 적용
        /// </summary>
        /// <param name="_name">아이템 이름</param>
        /// <param name="_itemType">아이템 종류</param>
        /// <param name="_itemInfo">아이템 설명</param>
        /// <param name="_value">아이템 능력치</param>
        /// <param name="_cost">아이템 가격</param>
        public Item(string _name, int _itemType, string _itemInfo, int _value, int _cost, bool _sale)
        {
            Name = _name;
            Itemtype = (ItemType)_itemType;
            Info = _itemInfo;
            Value = _value;
            Cost = _cost;
            PlayerHave = false;
            PlayerUse = false;
            SaleItem = _sale;
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

        //public void Use()
        //{
        //    if(PlayerUse)
        //    {

        //    }
        //}
    }

    public struct ItemList
    {
        public Item[] arrItem;
        
        public ItemList()
        {
            arrItem = new Item[]
            {
                new Item("수련자의 갑옷", 30, "수련에 도움을 주는 갑옷입니다.", 20, 1000, true),
                new Item("무쇠갑옷", 30, "무쇠로 만들어져 튼튼한 갑옷입니다.", 30, 2000, true),
                new Item("스파르타의 갑옷", 30,"전설의 스파르타 전사 르탄이 사용했다는 갑옷입니다.", 50, 3500, true),
                new Item("낡은 검", 10, "사용감이 제법 있는 낡은 검입니다.", 2, 600, true),
                new Item("청동 도끼", 10, "사용감이 조금 있는 도끼입니다.", 5, 1500, true),
                new Item("스파르타의 창", 10, "전설의 스파르타 전사 르탄이 사용했다는 소문이 있는 갑옷입니다.", 15, 2500, true),
                new Item("작은 방패", 20, "작고 둥글어서 귀여운 방패입니다.", 4, 1000, true),
                new Item("단단한 방패", 20, "단단한 방패입니다.", 9, 2000, true),
                new Item("스파르타의 방패", 20, "전설의 스파르타 전사 르탄이 사용했다는... 듯한? 그런 갑옷", 15, 3500, true)
            };
        }

        public void ItemCatalog(Item[] _arr, bool _inven, bool _num)
        {
            string number = "";
            string equipOrCost;
            string itemType = "";
            int itemCount = 1;

            Console.WriteLine("[아이템 목록");

            foreach(Item i in _arr)
            {
                if (_num) number = itemCount.ToString();

                if(_inven)
                {
                    if (_arr.Length == 0) break;
                    
                    if(i.PlayerUse)
                    {
                        equipOrCost = "[E]";
                    }
                    else
                    {
                        equipOrCost = "";
                    }

                    switch(i.Itemtype)
                    {
                        case ItemType.Weapon:
                            itemType = "공격력";
                            break;

                        case ItemType.Shield:
                            itemType = "방어력";
                            break;

                        case ItemType.Armor:
                            itemType = "체력";
                            break;
                    }

                    Console.WriteLine($"- {number} {equipOrCost}{i.Name}  |  {itemType} +{i.Value}  |  {i.Info}");
                }
                else
                {
                    if(i.PlayerHave)
                    {
                        equipOrCost = "구매완료";
                    }
                    else
                    {
                        equipOrCost = $"{i.Cost} G";
                    }

                    Console.WriteLine($"- {number} {i.Name}  |  {itemType} +{i.Value}  |  {i.Info}  |  {equipOrCost}");
                }

                itemCount++;
            }
        }
    }
}
