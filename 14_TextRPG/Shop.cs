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
        ItemList itemList;

        /// <summary>
        /// 전체 아이템 중 상점에서 판매하는 아이템을 배열로 만든다
        /// </summary>
        public Shop()
        {
            List<Item> listShopItem = new List<Item>();

            foreach(Item i in itemList.arrItem)
            {
                if(i.SaleItem)
                {
                    listShopItem.Add(i);
                }
            }

            arrShopItem = listShopItem.ToArray();
        }

        public void ShowShop(Player _player, Inven _inven)
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G\n");

            itemList.ItemCatalog(arrShopItem, false, false);

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");

            int input = Input.input(0, 1);

            if(input != 0)
            {
                Sale(_player, _inven);
            }
        }

        public void Sale(Player _player, Inven _inven)
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.Gold} G\n");

            itemList.ItemCatalog(arrShopItem, false, true);

            Console.WriteLine("\n0. 나가기\n");

            int input = Input.input(0, arrShopItem.Length);

            if(input == 0)
            {
                ShowShop(_player, _inven);
            }
            else
            {
                arrShopItem[input - 1].Buy(_player, _inven);
            }
        }
    }
}
