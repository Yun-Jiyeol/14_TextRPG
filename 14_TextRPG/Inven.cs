using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class Inven
    {
        public List<Item> HoldItem = new List<Item>();

        public void ShowInven()
        {
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n[아이템 목록]\n");
            // 아이템 리스트의 아이템을 출력하는 함수 제작할 것
            Console.WriteLine("1. 장착 관리\n0. 나가기\n");
            // 게임매니저에서 Input 호출
            // 임시로 값이 0인 int 변수 지정
            // 게임매니저에서 호출 가능해지면 지울 것
            int input = 0;

            if (input >= 0 || input < 2)
            {
                if (input == 0)
                {
                    // 마을 메뉴로 나가는 함수 호출할 것
                }
                else
                {
                    EquipManage();
                }
            }
        }

        void EquipManage()
        {

        }
    }
}
