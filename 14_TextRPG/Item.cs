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
        Weapon,
        Shield,
        Armor
    }

    public class Item
    {
        public string Name { get; } //아이템 이름
        public ItemType Itemtype { get; } //아이템 종류
        public string Info { get; } //아이템 설명
        public int Value { get; } //아이템 스텟
        public int Cost { get; private set; } //아이템 가격
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
        public Item(string _name, ItemType _itemType, string _itemInfo, int _value, int _cost, bool _sale)
        {
            Name = _name;
            Itemtype = _itemType;
            Info = _itemInfo;
            Value = _value;
            Cost = _cost;
            PlayerHave = false;
            PlayerUse = false;
            SaleItem = _sale;
        }

        /// <summary>
        /// 상점에서 아이템을 구매했을 때 호출
        /// 플레이어가 소지한 Gold가 아이템의 가격보다 많은지 비교하고
        /// 결과 출력
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_inven"></param>
        public void BuyItem(Player _player, Inven _inven)
        {
            if ((!PlayerHave))
            {
                if (_player.Gold - Cost >= 0)
                {
                    // 인벤토리에 아이템 추가
                    PlayerHave = true;
                    Console.WriteLine("구매를 완료했습니다.");
                    _player.Gold -= Cost;
                    _inven.GetItem(this);
                    Cost /= 10;
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }

            Thread.Sleep(500);
        }

        /// <summary>
        /// 아이템 착용시 호출
        /// </summary>
        /// <param name="_player"></param>
        public void ItemEquip(Player _player)
        {
            if (PlayerUse)
            {
                PlayerUse = false;

                int playerEquipEffect = _player.ItemDefence + _player.ItemAttack + (int)_player.ItemHealth;

                if(playerEquipEffect <= 0)
                {
                    _player.isEquip = false;
                }

                switch (Itemtype)
                {
                    case ItemType.Weapon:
                        _player.ItemAttack -= Value;
                        break;
                    case ItemType.Shield:
                        _player.ItemDefence -= Value;
                        break;
                    case ItemType.Armor:
                        _player.ItemHealth -= Value;
                        _player.Health -= Value;
                        break;
                }
            }
            else
            {
                PlayerUse = true;

                if (!_player.isEquip) _player.isEquip = true;

                switch (Itemtype)
                {
                    case ItemType.Weapon:
                        _player.ItemAttack += Value;
                        break;
                    case ItemType.Shield:
                        _player.ItemDefence += Value;
                        break;
                    case ItemType.Armor:
                        _player.ItemHealth += Value;
                        _player.Health += Value;
                        break;
                }
            }
        }

        public void SellItem(Player _player, Inven _inven)
        {
            _player.Gold += Cost;
            _inven.listHoldItem.Remove(this);

            if(this.PlayerUse)
            {
                ItemEquip(_player);
            }

            this.PlayerHave = false;
            
            if(this.SaleItem)
            {
                Cost *= 10;
            }

            Console.WriteLine("판매를 완료했습니다.");
            Thread.Sleep(500);
        }
    }

    public struct ItemList
    {
        public Item[] arrItem;

        public ItemList()
        {
            arrItem = new Item[]
            {
            new Item("수련자의 갑옷", ItemType.Armor, "수련에 도움을 주는 갑옷입니다.", 20, 1000, true),
            new Item("무쇠갑옷", ItemType.Armor, "무쇠로 만들어져 튼튼한 갑옷입니다.", 30, 2000, true),
            new Item("스파르타의 갑옷", ItemType.Armor,"전설의 스파르타 전사 르탄이 사용했다는 갑옷입니다.", 50, 3500, true),
            new Item("낡은 검", ItemType.Weapon, "사용감이 제법 있는 낡은 검입니다.", 2, 600, true),
            new Item("청동 도끼", ItemType.Weapon, "사용감이 조금 있는 도끼입니다.", 5, 1500, true),
            new Item("스파르타의 창", ItemType.Weapon, "전설의 스파르타 전사 르탄이 사용했다는 소문이 있는 갑옷입니다.", 15, 2500, true),
            new Item("작은 방패", ItemType.Shield, "작고 둥글어서 귀여운 방패입니다.", 4, 1000, true),
            new Item("단단한 방패", ItemType.Shield, "단단한 방패입니다.", 9, 2000, true),
            new Item("스파르타의 방패", ItemType.Shield, "전설의 스파르타 전사 르탄이 사용했다는... 듯한? 그런 갑옷", 15, 3500, true),
            new Item("해진 가죽갑옷", ItemType.Armor, "해진 가죽갑옷이다 .", 5, 200, false)
            };
        }

        /// <summary>
        /// 전달받은 아이템 목록을 출력하는 함수
        /// </summary>
        /// <param name="_arr">출력해야 할 아이템 목록</param>
        /// <param name="_outputMode">출력 방식(0 = 인벤토리 아이템 출력
        /// 1 = 상점에서 구매할 수 있는 아이템 출력
        /// 2 = 인벤토리의 아이템을 판매할 목적으로 출력</param>
        /// <param name="_num">번호가 필요한지 여부</param>
        /// <param name="_choice">아이템 목록 다음으로 출력할 선택지</param>
        public void ItemCatalog(Item[] _arr, int _outputMode, bool _num, string _choice)
        {
            string number = "";
            string equipOrCost;
            string itemType = "";
            int itemCount = 1;

            Console.WriteLine("\n[아이템 목록]");
            foreach (Item i in _arr)
            {
                if (_num) number = itemCount.ToString();

                switch (i.Itemtype)
                {
                    case ItemType.Weapon:
                        itemType = "공격력 +";
                        break;

                    case ItemType.Shield:
                        itemType = "방어력 +";
                        break;

                    case ItemType.Armor:
                        itemType = "체력 +";
                        break;
                }

                if (_outputMode == 0 || _outputMode == 2)
                {
                    if (_arr.Length == 0) break;

                    if (i.PlayerUse)
                    {
                        equipOrCost = "[E]";
                    }
                    else
                    {
                        equipOrCost = "";
                    }

                    string sellCost = "";

                    if(_outputMode ==2)
                    {
                        sellCost = "|  " + i.Cost.ToString() + " G";
                    }

                    Console.WriteLine($"- {number} {equipOrCost}{i.Name}  |  {itemType} {i.Value}  |  {i.Info}  {sellCost}");
                }
                else
                {
                    if (i.PlayerHave)
                    {
                        equipOrCost = "구매 완료";
                    }
                    else
                    {
                        equipOrCost = $"{i.Cost} G";
                    }

                    Console.WriteLine($"- {number} {i.Name}  |  {itemType} {i.Value}  |  {i.Info}  |  {equipOrCost}");
                }

                itemCount++;
            }

            Console.WriteLine($"\n{_choice}\n");
        }
    }
}
