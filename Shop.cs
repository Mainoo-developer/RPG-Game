using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Shop
    {
        private List<ItemManager.Item> itemList;
        private Status.CharacterStats characterStats; // 플레이어의 상태 정보 (Gold 포함)
        private Inventory inventory;

        public Shop(List<ItemManager.Item> itemList, Status.CharacterStats characterStats, Inventory inventory)
        {
            this.itemList = itemList;
            this.characterStats = characterStats;
            this.inventory = inventory;
        }

        public void ShowShop()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("ㅡㅡㅡㅡ 상점 ㅡㅡㅡㅡ");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine($"\n[보유 골드]\n {characterStats.Gold} G\n");

                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < itemList.Count; i++)
                {
                    var item = itemList[i];
                    string purchaseStatus = item.IsPurchased ? "구매완료" : $"{item.Price} G";
                    Console.WriteLine($"{i + 1}. {item.Name} | {item.Type} +{item.Power} | {item.Description} | {purchaseStatus}");
                }

                Console.WriteLine("\n1. 아이템 구매  0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요: ");
                int choice = int.Parse(Console.ReadLine() ?? "");

                switch (choice)
                {
                    case 1:
                        BuyItem();
                        break;
                    case 0:
                        isRunning = false;
                        Console.WriteLine("상점을 나갑니다.");
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                        break;
                }
            }
        }

        public void BuyItem()
        {
            Console.Clear();
            Console.WriteLine($"\n[보유 골드] {characterStats.Gold} G\n");

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < itemList.Count; i++)
            {
                var item = itemList[i];
                string purchaseStatus = item.IsPurchased ? "구매완료" : $"{item.Price} G";
                Console.WriteLine($"{i + 1}. {item.Name} | {item.Type} +{item.Power} | {item.Description} | {purchaseStatus}");
            }
            Console.WriteLine();
            Console.WriteLine("구매할 아이템의 번호를 입력하세요 (0. 취소): ");
            Console.WriteLine();
            int itemChoice = int.Parse(Console.ReadLine() ?? "") - 1;

            if (itemChoice >= 0 && itemChoice < itemList.Count)
            {
                var item = itemList[itemChoice];

                if (item.IsPurchased)
                {
                    Console.WriteLine($"[{item.Name}]은 이미 구매하셨습니다.");
                }
                else if (characterStats.Gold >= item.Price)
                {
                    Console.WriteLine($"\n[보유 골드]\n {characterStats.Gold} G - {item.Price} G");
                    characterStats.Gold -= item.Price;
                    Console.WriteLine($"\n = {characterStats.Gold} G");
                    itemList[itemChoice] = new ItemManager.Item(item.Name, item.Description, item.Power, item.Type, item.Price, true);
                    Console.WriteLine($"[{item.Name}]을(를) 구매하였습니다!");

                    inventory.AddItem(item);
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
            else if (itemChoice == -1)
            {
                Console.WriteLine("구매를 취소합니다.");
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도해주세요.");
            }

            Console.WriteLine("\n아무 키나 눌러서 돌아가기...");
            Console.ReadKey();
        }
    }
}
