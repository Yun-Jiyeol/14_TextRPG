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
            int page = 0; //현제 페이지
            int pageSize = arrShopItem.Length / 5; //전체 페이지 0부터 시작
            int lastpageItem = arrShopItem.Length % 5; //마지막 페이지에 있을 아이템의 수
            int itemNum;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.LeftDT("  [ 상 점 ]", 1, ConsoleColor.Red);
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
                DesignText.LeftDT($"  [보유 골드] - {_player.Gold} G", 11, ConsoleColor.DarkYellow);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.LeftDT("  6. 아이템 판매", 17, ConsoleColor.Gray);
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
                    if(arrShopItem[i + page * 5].PlayerHave)
                    {
                        DesignText.LeftDT($" {i + 1}." + itemList.ItemCatalog(arrShopItem[i + page * 5], 1, false), 3 + i, ConsoleColor.Green);
                    }
                    else
                    {
                        DesignText.LeftDT($" {i + 1}." + itemList.ItemCatalog(arrShopItem[i + page * 5], 1, false), 3 + i, ConsoleColor.White);
                    }
                }
                DesignText.LeftDT($"  1 - {numobitem}. 아이템 확인", 16, ConsoleColor.Gray);

                Console.SetCursorPosition(0,22);
                int input = Input.input(0, 8);

                if(input == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine("상점을 둘러본 후 마을로 돌아갑니다.");
                    Console.ResetColor();
                    DesignText.IsMove(5);
                    break;
                }
                else if (input <= numobitem) //1,2,3,4,5
                {
                    Console.SetCursorPosition(0, 16);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    DesignText.LeftDT($" {input}." + itemList.ItemCatalog(arrShopItem[input + page * 5 - 1], 1, false), 2 + input, ConsoleColor.Yellow);
                    BuyShopItem(_player, _inven, input + page * 5 - 1); //마지막껀 아이템의 번호입니다.
                }
                else if (input <= 5) //마지막 페이지에서 없는 번호를 입력할 시
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("비어 있는 공간입니다.");
                    DesignText.IsMove(5);
                }
                else if (input == 6)
                {
                    Console.SetCursorPosition(0, 16);
                    DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                    SellItem(_player, _inven);
                }else if(input == 7)
                {
                    page--;
                }
                else if (input == 8)
                {
                    page++;
                }
            }
        }

        private void BuyShopItem(Player _player, Inven _inven, int num)
        {
            DesignText.LeftDT("  " + arrShopItem[num].Info, 13, ConsoleColor.Gray); //설명서 작성
            DesignText.LeftDT("", 14, ConsoleColor.Gray);

            Console.SetCursorPosition(0, 17); //입력 초기화를 위한 작업
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.MiddleDT("", 40, ConsoleColor.Gray);
            DesignText.LeftDT("  6. 아이템 구매", 17, ConsoleColor.Gray);
            DesignText.LeftDT("  0. 다른 아이템 확인", 18, ConsoleColor.Blue);

            while (true)
            {
                Console.SetCursorPosition(0, 22); //입력 초기화를 위한 작업
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.SetCursorPosition(0, 22);
                int input = Input.input(0, 6);

                if (input == 6) //구매 후 초기 화면으로
                {
                    arrShopItem[num].BuyItem(_player, _inven);
                    DesignText.IsMove(5);
                    break;
                }
                else if (input == 0) //초기 화면으로 복귀
                {
                    break;
                }
            }
        }

        private void SellItem(Player _player, Inven _inven)
        {
            int page = 0; //현제 페이지

            while (true)
            {
                int pageSize = _inven.listHoldItem.ToArray().Length / 5; //전체 페이지 0부터 시작
                int lastpageItem = _inven.listHoldItem.ToArray().Length % 5; //마지막 페이지에 있을 아이템의 수
                int itemNum;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("┏━");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("━┓");
                DesignText.LeftDT("  [ 판 매 ]", 1, ConsoleColor.Red);
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
                DesignText.LeftDT($"  [보유 골드] - {_player.Gold} G", 11, ConsoleColor.DarkYellow);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
                DesignText.MiddleDT("", 40, ConsoleColor.Gray);
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
                    DesignText.LeftDT($" {i + 1}." + itemList.ItemCatalog(_inven.listHoldItem[i + page * 5], 2, false), 3 + i, ConsoleColor.White);
                }

                Console.SetCursorPosition(0, 22);
                int sellinput = Input.input(0, 8);

                if (sellinput == 0)
                {
                    break;
                }
                else if (sellinput <= numobitem) //1,2,3,4,5
                {
                    DesignText.LeftDT($" {sellinput}." + itemList.ItemCatalog(_inven.listHoldItem[sellinput + page * 5 - 1], 2, false), 2 + sellinput, ConsoleColor.Yellow);
                    SellShopItem(_player, _inven, sellinput + page * 5 - 1); //마지막껀 아이템의 번호입니다.
                }
                else if (sellinput <= 6) //마지막 페이지에서 없는 번호를 입력할 시
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("비어 있는 공간입니다.");
                    DesignText.IsMove(5);
                }
                else if (sellinput == 7)
                {
                    page--;
                }
                else if (sellinput == 8)
                {
                    page++;
                }
            }
        }
        private void SellShopItem(Player _player, Inven _inven, int num)
        {
            DesignText.LeftDT("  " + _inven.listHoldItem[num].Info, 13, ConsoleColor.Gray); //설명서 작성

            DesignText.LeftDT("  6. 아이템 판매", 17, ConsoleColor.Gray);

            while (true) //잘못된 입력을 보기 위한 틀
            {
                Console.SetCursorPosition(0, 22); //입력 초기화를 위한 작업
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.WriteLine("                                      ");
                Console.SetCursorPosition(0, 22);
                int input = Input.input(0, 6);

                if (input == 6) //구매 후 초기 화면으로
                {
                    _inven.listHoldItem[num].SellItem(_player, _inven);
                    DesignText.IsMove(5);
                    break;
                }
                else if (input == 0) //초기 화면으로 복귀
                {
                    break;
                }
            }
        }
    }
}
