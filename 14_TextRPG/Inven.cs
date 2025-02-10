using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Inven
    {
        ItemList itemList;
        public List<Item> listHoldItem = new List<Item>();

        /// <summary>
        /// 인벤토리 아이템 확인
        /// </summary>
        public void ShowInven(Player _player)
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");

            itemList.ItemCatalog(listHoldItem.ToArray(), true, false);

            Console.WriteLine("1. 장착 관리\n0. 나가기\n");
            int input = Input.input(0, 1);

            if (input != 0)
            {
                EquipManage(_player);
            }
        }

        /// <summary>
        /// 아이템 장착 관리
        /// </summary>
        void EquipManage(Player _player)
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");

            itemList.ItemCatalog(listHoldItem.ToArray(), true, true);

            Console.WriteLine("\n0. 나가기\n");

            int input = Input.input(0, listHoldItem.Count);

            if(input == 0)
            {
                ShowInven(_player);
            }
            else
            {
                listHoldItem[input - 1].Use(_player); //마을로 돌아갈듯? : 해결
                EquipManage(_player);
            }
        }

        public void GetItem(Item _item)
        {
            listHoldItem.Add(_item);
        }
    }
}
