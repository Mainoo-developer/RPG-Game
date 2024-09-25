using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    internal class ItemManager
    {
        public struct Item
        {
            public string Name;
            public string Description;
            public int Power;
            public string Type;
            public int Price;
            public bool IsPurchased;

            // 생성자
            public Item(string name, string description, int power, string type, int price, bool isPurchased)
            {
                Name = name;
                Description = description;
                Power = power;
                Type = type;
                Price = price;
                IsPurchased = isPurchased;
            }
        }

        public List<Item> GetItemList()
        {
            return new List<Item>()
            {
                new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 5, "방어력", 1000, false),
                new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 9, "방어력", 1500, false),
                new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 15, "방어력", 3500, false),
                new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, "공격력", 600, false),
                new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, "공격력", 1500, false),
                new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, "공격력", 0, false)
            };
        }

        public List<Item> GetInventoryItemList()
        {
            return new List<Item>()
            {
                new Item("광선 검", "이정재가 실수로 가져온 검이다.", 9999999, "공격력", 9999999, false),
                new Item("코카콜라", "누군가가 마셨던 콜라다. 이걸로 맞으면 상당히 불쾌하다", 5, "공격력", 800, false),
                new Item("스파르타의 팬티", "스파르타의 전사들이 사용했다는 전설의 속옷입니다.", 200, "방어력", 30000, false)
            };
        }
    }
}
