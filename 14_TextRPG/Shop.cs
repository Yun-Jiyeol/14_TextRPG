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
    }
}
