using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TextRPG
{
    public class GameManager
    {
<<<<<<< HEAD
<<<<<<< HEAD

        public void Start() { }

        public int Input(int i) //0-i까지의 숫자를 입력 이외에는 "잘못된 입력입니다."
=======
        ChangeLoc CL = new ChangeLoc(); //위치 설정할 클래스

        public int Input(int min , int max) //0-i까지의 숫자를 입력 이외에는 "잘못된 입력입니다."
>>>>>>> main
=======
        public void Start()
>>>>>>> main
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 상태보기");
                Console.WriteLine();
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine();
                Console.WriteLine("3. 상점");
                Console.WriteLine();
                Console.WriteLine("4. 전투시작");
                Console.WriteLine();
                Console.WriteLine("5. 퀘스트");
                Console.WriteLine();
                Console.WriteLine("0. 게임 종료");
                Console.WriteLine();

                int input = Input.input(0, 5);
                switch (input)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        //Player.State();
                        break;
                    case 2:
                        //Item
                        break;
                    case 3:
                        //Store
                        break;
                    case 4:
                        //Battle
                        break;
                    case 5:
                        //Quest
                        break;
                }
            }
        }
    }
}
