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
            int page = 0; //현제 페이지

            while (true)
            {
                int pageSize = listHoldItem.ToArray().Length / 5; //전체 페이지 0부터 시작
                int lastpageItem = listHoldItem.ToArray().Length % 5; //마지막 페이지에 있을 아이템의 수
                int itemNum;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.LeftDT("  [ 인 벤 토 리 ]", 1, ConsoleColor.Magenta);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //1
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //2
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //3
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //4
                DesignText.MiddleDT("", 40, ConsoleColor.Gray); //5
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("   7. 이전                  8.다음", 9, ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┣━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┫");
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("  6. 플레이어 상태", 17, ConsoleColor.Gray);
                DesignText.LeftDT("  0. 나가기", 18, ConsoleColor.Blue);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┗━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┛");
                Console.ResetColor();

                if (page > pageSize) //현제 페이지가 범위 밖으로 나가지 않도록 조정
                {
                    page -= pageSize + 1;
                }
                else if (page < 0)
                {
                    page += pageSize + 1;
                }

                int numobitem;
                if (page == pageSize)//마지막 페이지일 시
                {
                    numobitem = lastpageItem; //보일 아이템의 갯수
                }
                else
                {
                    numobitem = 5;
                }

                for (int i = 0; i < numobitem; i++) //아이템의 갯수만큼 실행
                {
                    DesignText.LeftDT($" {i + 1}." + itemList.ItemCatalog(listHoldItem[i + page * 5], 0, false), 3 + i, ConsoleColor.White);
                }

                Console.SetCursorPosition(0,22);
                int input = Input.input(0, 8);

                if (input == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine("가방을 둘러본 후 가방을 닫습니다.");
                    Console.ResetColor();
                    DesignText.IsMove(5);
                    break;
                }
                else if (input <= numobitem)
                {
                    DesignText.LeftDT($" {input}." + itemList.ItemCatalog(listHoldItem[input + page * 5 - 1], 0, false), 2 + input, ConsoleColor.Yellow);
                    EquipManage(_player, input + page * 5 - 1);
                    //BuyShopItem(_player, _inven, input + page * 5 - 1); //마지막껀 아이템의 번호입니다.
                }
                else if (input <= 5) //페이지에서 없는 번호를 입력할 시
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("비어 있는 공간입니다.");
                    DesignText.IsMove(5);
                }
                else if (input == 6)
                {
                    Checkstate(_player);
                }
                else if (input == 7)
                {
                    page--;
                }
                else if (input == 8)
                {
                    page++;
                }
            }
        }

        void Checkstate(Player _player)
        {
            Console.SetCursorPosition(0, 17);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            _player.Status(11);

            Console.SetCursorPosition(0, 22); //입력 초기화를 위한 작업
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.SetCursorPosition(0, 22);
            int input = Input.input(0, 0);
        }

        /// <summary>
        /// 아이템 장착 관리
        /// </summary>
        void EquipManage(Player _player, int num)
        {
            DesignText.LeftDT("  " + listHoldItem[num].Info, 12, ConsoleColor.Gray); //설명서 작성
            DesignText.LeftDT("", 13, ConsoleColor.Gray);

            Console.SetCursorPosition(0, 17); //입력 초기화를 위한 작업
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            if (listHoldItem[num].PlayerUse)
            {
                DesignText.LeftDT("  6. 아이템 해제", 17, ConsoleColor.Gray);
            }
            else
            {
                DesignText.LeftDT("  6. 아이템 장착", 17, ConsoleColor.White);
            }
            DesignText.LeftDT("  0. 다른 아이템 확인", 18, ConsoleColor.Blue);

            Console.SetCursorPosition(0, 22); //입력 초기화를 위한 작업
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.SetCursorPosition(0, 22);
            int input = Input.input(0, 6);

            if(input == 6)
            {
                Console.WriteLine();
                listHoldItem[num].ItemEquip(_player); //아이템 장착
                DesignText.IsMove(5);
            }
            else if (input != 0)
            {
                EquipManage(_player,num);
            }
        }

        public void GetItem(Item _item)
        {
            listHoldItem.Add(_item);
            listHoldItem = listHoldItem.OrderBy(item => item.Itemtype).ToList();
        }
    }
}
