using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp2.GameStart;

namespace ConsoleApp2
{
    internal class GamePlay
    {
        // 메뉴를 보여주는 메소드
        public static void ShowMenu(GameStart.Character characterStatus, Status.CharacterStats characterStats)
        {
            bool isRunning = true;

            ItemManager itemManager = new ItemManager();
            List<ItemManager.Item> itemList = itemManager.GetItemList();
            List<ItemManager.Item> inventoryItemList = itemManager.GetInventoryItemList();
            Inventory inventory = new Inventory(inventoryItemList);
            Shop shop = new Shop(itemList, characterStats , inventory);

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("ㅡㅡㅡㅡㅡㅡ [ 메인화면 ] ㅡㅡㅡㅡㅡㅡ");
                Console.WriteLine();
                Console.WriteLine($"이름 : {characterStatus.Name}");
                Console.WriteLine($"직업 : {characterStatus.Job}");
                Console.WriteLine($"레벨 : {characterStats.Level}");
                Console.WriteLine($"골드 : {characterStats.Gold} G");  // 골드가 제대로 표시되는지 확인
                Console.WriteLine();
                Console.WriteLine("1.상태창  2.인벤토리  3.상점 가기  4.던전 가기  5.종료");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요");

                int choice;
                bool validInput = int.TryParse(Console.ReadLine(), out choice);

                if (!validInput)
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해 주세요.");
                    Console.ReadKey();
                    continue;  // 잘못된 입력이므로 다시 메뉴를 출력
                }

                switch (choice)
                {
                    case 1:// 상태창
                        characterStatus.DisplayCharacterInfo2();
                        break;
                    case 2:// 인벤토리
                        inventory.ShowInventory();
                        break;
                    case 3:// 상점
                        shop.ShowShop();
                        break;
                    case 4:// 던전
                        GoToDungeon();
                        break;
                    case 5:
                        isRunning = false;
                        Console.WriteLine("게임을 종료합니다.");
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
        }

        // 던전 이동 - 임시
        public static void GoToDungeon()
        {
            Console.Clear();
            Console.WriteLine("===== 던전 =====");
            Console.WriteLine("업데이트 중입니다...감사합니다");
            Console.WriteLine("================");
            Console.WriteLine("\n뒤로 가려면 아무 키나 누르세요.");
            Console.ReadKey();
        }
    }
}
