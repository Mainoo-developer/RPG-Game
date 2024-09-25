using System;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Status
    {
        public class CharacterStats
        {
            public int Level;
            public int AttackPower;
            public int DefensePower;
            public int Health;
            public int Gold;

            public CharacterStats(int level, int attackPower, int defensePower, int health, int gold)
            {
                Level = level;
                AttackPower = attackPower;
                DefensePower = defensePower;
                Health = health;
                Gold = gold;
            }

            public void DisplayStats()
            {
                Console.WriteLine("ㅡㅡㅡㅡ 상태 창 ㅡㅡㅡㅡ");
                Console.WriteLine($"레벨  : {Level}");
                Console.WriteLine($"공격력: {AttackPower}");
                Console.WriteLine($"방어력: {DefensePower}");
                Console.WriteLine($"체력  : {Health}");
                Console.WriteLine($"Gold  : {Gold}");
                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            }

            // 더하기 연산자를 사용해서 능력치 더할 수 있도록
            public static CharacterStats operator +(CharacterStats a, CharacterStats b)
            {
                return new CharacterStats
                (
                    a.Level + b.Level,
                    a.AttackPower + b.AttackPower,
                    a.DefensePower + b.DefensePower,
                    a.Health + b.Health,
                    a.Gold + b.Gold
                );
            }
        }
    }
}
