using System;
using static ConsoleApp2.Status;

namespace ConsoleApp2
{
    internal class GameStart
    {
        public class Character
        {
            // 기본 정보
            public string Name { get; private set; }
            public string Job { get; private set; }
            public CharacterStats Stats { get; private set; }

            // 캐릭터 생성자
            public Character(string name, string job, CharacterStats stats)
            {
                Name = name;
                Job = job;
                Stats = stats;
            }

            // 처음 캐릭터 정보를 출력하는 메소드
            public void DisplayCharacterInfo()
            {
                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("\nㅡㅡㅡㅡ 캐릭터 정보 ㅡㅡㅡㅡ");
                Console.WriteLine();
                Console.WriteLine($"이름:{Name}  직업: ({Job})");
                Console.WriteLine();
                Stats.DisplayStats(); // 캐릭터 능력치 출력
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("<나가기>");
                Console.WriteLine("아무 키나 눌러서 게임을 시작하세요");
            }
            // Status에 보여질 화면
            public void DisplayCharacterInfo2()
            {
                Console.Clear();

                Console.WriteLine("상태창");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("\nㅡㅡㅡㅡ 캐릭터 정보 ㅡㅡㅡㅡ");
                Console.WriteLine();
                Console.WriteLine($"이름:{Name}  직업: ({Job})");
                Console.WriteLine();
                Stats.DisplayStats(); // 캐릭터 능력치 출력
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("<나가기>");
                Console.WriteLine("\n아무 키나 눌러서 돌아가기");

                Console.ReadKey();
            }
        }

        enum CharacterClass
        {
            Warrior,
            Thief,
        }

        static void Main()
        {
            bool isNameConfirmed = false;
            bool isJobConfirmed = false;
            string characterName = "";
            string characterJob = "";
            CharacterStats stats = new CharacterStats(1, 10, 5, 100, 1500);

            while (!isNameConfirmed)
            {
                // 1. 캐릭터 이름 선택
                Console.WriteLine("스파르타 던전에 오신 여러분을 환영합니다.\n원하시는 이름을 설정해주세요.");
                Console.WriteLine();

                characterName = Console.ReadLine() ?? "";

                Console.WriteLine($"\n입력하신 이름은 [{characterName}] 입니다.");
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요");
                Console.WriteLine();

                // 이름 정하기 취소 or 계속 진행하기
                int i = int.Parse(Console.ReadLine() ?? "");
                if (i == 1)
                {
                    isNameConfirmed = true;
                }
                else if (i == 2)
                {
                    Console.Clear();
                }
            }

            Console.Clear();


            while (!isJobConfirmed) {
                // 2. 직업 선택
                Console.WriteLine("직업을 선택하세요:\n");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");
                Console.WriteLine("\n원하시는 행동을 입력해 주세요");
                Console.WriteLine();

                int classChoice = int.Parse(Console.ReadLine() ?? "");
                CharacterClass characterClass = CharacterClass.Warrior; // 기본값 설정
                switch (classChoice)
                {
                    case 1:
                        characterClass = CharacterClass.Warrior;
                        characterJob = "전사";
                        stats = new CharacterStats(1, 10, 5, 100, 1500); // 전사 능력치 설정
                        isJobConfirmed = true;
                        break;
                    case 2:
                        characterClass = CharacterClass.Thief;
                        characterJob = "도적";
                        stats = new CharacterStats(1, 15, 3, 80, 1500); // 도적 능력치 설정
                        isJobConfirmed = true;
                        break;
                    default://잘못 입력하면 다시 입력하게 하기
                        isJobConfirmed = false;
                        Console.Clear();
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Console.WriteLine();
                        break;
                }
            }

            Character character = new Character(characterName, characterJob, stats);
            Console.Clear();
            character.DisplayCharacterInfo();

            Console.ReadKey();
            Console.Clear();
            GamePlay.ShowMenu(character, stats);  // 이미 초기화된 stats 객체를 전달
        }
        public static Character CreateCharacter(string name, string job, CharacterStats stats)
        {
            return new Character(name, job, stats);
        }
    }
}