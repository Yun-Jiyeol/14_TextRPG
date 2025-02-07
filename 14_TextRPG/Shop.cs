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

        public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]\n");
            // Player로부터 소지 골드 값 받아와서 표시할 것

            itemList.ItemCatalog(arrShopItem, false, false);

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");

            int input = Input.input(0, 1);

            if(input == 0)
            {
                // 마을 메뉴로
            }
            else
            {
                Sale();
            }
        }

        public void Sale()
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]\n");
            // Player로부터 소지 골드 값 받아와서 표시할 것

            itemList.ItemCatalog(arrShopItem, false, true);

            Console.WriteLine("\n0. 나가기\n");

            int input = Input.input(0, arrShopItem.Length);

            if(input == 0)
            {
                ShowShop();
            }
            else
            {
                // 이미 구매한 물건인지 소지한 골드로 교환할 수 있는지를 비교한 다음 결과 출력
            }
        }
    }
}
