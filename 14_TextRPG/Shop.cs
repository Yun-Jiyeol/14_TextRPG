using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Shop
    {
        public Item[] arrShopItem; // 상점에서 판매하는 아이템 배열
        ItemList itemList = new ItemList();

        /// <summary>
        /// 전체 아이템 중 상점에서 판매하는 아이템을 배열로 만든다
        /// </summary>
        public Shop()
        {
            List<Item> listShopItem = new List<Item>();

            foreach (Item i in itemList.arrItem)
            {
                if (i.SaleItem)
                {
                    listShopItem.Add(i);
                }
            }

            listShopItem = listShopItem.OrderBy(item => item.Itemtype).ToList();
            arrShopItem = listShopItem.ToArray();
        }

        public void ShowShop(Player _player, Inven _inven)
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");

            itemList.ItemCatalog(arrShopItem, 1, false, "1. 아이템 구매\n2. 아이템 판매\n0. 나가기");
            int input = Input.input(0, 2);

            if(input == 1)
            {
                BuyShopItem(_player, _inven);
            }
            else if(input == 2)
            {
                SellItem(_player, _inven);
            }
        }

        private void BuyShopItem(Player _player, Inven _inven)
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");

            itemList.ItemCatalog(arrShopItem, 1, true, "0. 나가기");
            int input = Input.input(0, arrShopItem.Length);

            if(input == 0)
            {
                ShowShop(_player, _inven);
            }
            else
            {
                arrShopItem[input - 1].BuyItem(_player, _inven);
                BuyShopItem(_player, _inven);
            }
        }

        private void SellItem(Player _player, Inven _inven)
        {
            Console.Clear();
            Console.WriteLine("상점\n판매하실 아이템을 선택하세요.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G");

            itemList.ItemCatalog(_inven.listHoldItem.ToArray(), 2, true, "0. 나가기");
            int input = Input.input(0, _inven.listHoldItem.Count);

            if(input == 0)
            {
                ShowShop(_player, _inven);
            }
            else
            {
                _inven.listHoldItem[input - 1].SellItem(_player, _inven);
                SellItem(_player, _inven);
            }
        }
    }
}
