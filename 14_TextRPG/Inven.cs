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
        public void ShowInven()
        {
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]\n");

            itemList.ItemCatalog(listHoldItem.ToArray(), true, false);

            Console.WriteLine("1. 장착 관리\n0. 나가기\n");
            int input = Input.input(0, 1);

            if (input == 0)
            {
                // 마을 메뉴로 나가는 함수 호출할 것
            }
            else
            {
                EquipManage();
            }
        }

        /// <summary>
        /// 아이템 장착 관리
        /// </summary>
        void EquipManage()
        {
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]\n");

            itemList.ItemCatalog(listHoldItem.ToArray(), true, true);

            Console.WriteLine("\n0. 나가기\n");

            int input = Input.input(0, listHoldItem.Count);

            if(input == 0)
            {
                ShowInven();
            }
            else
            {
                // 아이템 장착 및 해제
            }
        }

        public void GetItem(Item _item)
        {
            listHoldItem.Add(_item);
        }
    }
}
