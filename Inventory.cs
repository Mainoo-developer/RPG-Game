using System;
using System.Collections.Generic;
using ConsoleApp2;  // ItemManager의 네임스페이스 참조

namespace ConsoleApp2
{
    internal class Inventory
    {
        private List<ItemManager.Item> items;  // ItemManager.Item을 Item으로 바로 참조

        public Inventory(List<ItemManager.Item> inventoryItems)
        {
            items = inventoryItems;
        }
        public void AddItem(ItemManager.Item item)
        {
            items.Add(item);
            Console.WriteLine($"[{item.Name}]이(가) 인벤토리에 추가되었습니다.");
        }
        // 인벤토리 화면을 보여주는 메소드
        public void ShowInventory()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("ㅡㅡㅡㅡㅡ 인벤토리 ㅡㅡㅡㅡㅡ");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                // 아이템 목록 출력
                Console.WriteLine("[아이템 목록]");
                foreach (var item in items)
                {
                    string equippedStatus = item.IsPurchased ? "[E]" : "   ";
                    Console.WriteLine($"{equippedStatus}{item.Name} | {item.Type} +{item.Power} | {item.Description}");
                }

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("2. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요: ");
                int choice = int.Parse(Console.ReadLine() ?? "");

                switch (choice)
                {
                    case 1:
                        ManageEquipment();
                        break;
                    case 2:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("잘못된 선택입니다. 다시 시도해주세요.");
                        break;
                }
            }
        }

        // 장착 관리
        private void ManageEquipment()
        {
            Console.Clear();
            Console.WriteLine("===== 장착 관리 =====");

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                string equippedStatus = item.IsPurchased ? "[E]" : "   ";
                Console.WriteLine($"{i + 1}. {equippedStatus}{item.Name} | {item.Type} +{item.Power} | {item.Description}");
            }

            Console.Write("\n장착/해제할 아이템 번호를 입력하세요 (0. 취소): ");
            int itemChoice = int.Parse(Console.ReadLine() ?? "") - 1;

            if (itemChoice >= 0 && itemChoice < items.Count)
            {
                var item = items[itemChoice];

                if (item.IsPurchased)
                {
                    Console.WriteLine($"[{item.Name}]을(를) 해제합니다.");
                    items[itemChoice] = new ItemManager.Item(item.Name, item.Description, item.Power, item.Type, item.Price, false);
                }
                else
                {
                    Console.WriteLine($"[{item.Name}]을(를) 장착합니다.");
                    items[itemChoice] = new ItemManager.Item(item.Name, item.Description, item.Power, item.Type, item.Price, true);
                }
            }
            else if (itemChoice == -1)
            {
                Console.WriteLine("장착 관리를 취소합니다.");
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다.");
            }

            Console.WriteLine("\n아무 키나 눌러서 돌아가기...");
            Console.ReadKey();
        }
    }
}
