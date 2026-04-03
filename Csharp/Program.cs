using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CSharp_Study
{
    public enum Tier
    {
        None,
        Normal,
        Rare,
        Epic,
        Legendary,
    }

    public enum TierKR
    {
        없음,
        노말,
        레어,
        에픽,
        레전더리,
    }

    public class FantasticCreature
    {
        public string Name { get; private set; }
        public Tier Tier;
        protected int _level;

        public FantasticCreature(string name, Tier tier, int level)
        {
            Name = name;
            Tier = tier;
            _level = level;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"이름 : {Name}, 등급 : {Tier.ToString()}, 레벨 : {_level}");
        }
    }

    // 주작
    public class VermilionBird : FantasticCreature
    {
        public VermilionBird(string name, Tier tier, int level) : base(name, tier, level)
        {
        }
    }

    // 청룡
    public class AzureDragon : FantasticCreature
    {
        public AzureDragon(string name, Tier tier, int level) : base(name, tier, level)
        {
        }
    }

    // 현무
    public class BlackTortoise : FantasticCreature
    {
        public BlackTortoise(string name, Tier tier, int level) : base(name, tier, level)
        {
        }
    }

    // 백호
    public class WhiteTiger : FantasticCreature
    {
        public WhiteTiger(string name, Tier tier, int level) : base(name, tier, level)
        {
        }
    }

    public class CreatureDictionary
    {
        List<FantasticCreature> fantasticCreatures;

        public void Init()
        {
            fantasticCreatures = new List<FantasticCreature>();
        }

        public void AddCreatures(FantasticCreature fantasticCreature)
        {
            fantasticCreatures.Add(fantasticCreature);
        }

        public int SelectOption()
        {
            Console.WriteLine("1. 상상의 동물 정보 찾기");
            Console.WriteLine("2. 종료");

            int selectNum = 0;
            string input = "";
            do
            {
                Console.Write("옵션을 선택하세요 : ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out selectNum));

            return selectNum;
        }

        public void FindCreature()
        {
            Console.Write("찾고자 하는 동물의 이름이나 등급을 입력해주세요 : ");
            string input = Console.ReadLine();

            Console.WriteLine("----------------------------------------------------------");
            // 입력 값이 티어인 경우
            foreach (Tier tier in Enum.GetValues(typeof(Tier)))
            {
                // 티어라면 그 티어에 존재하는 상상의 동물 전부 출력

                if(tier.ToString().ToUpper() == input.ToUpper())
                {
                    PrintCreaturesByTier(tier);
                    Console.WriteLine("----------------------------------------------------------");
                    return;
                }
            }

            // 입력 값이 티어인 한글인 경우
            foreach (TierKR tier in Enum.GetValues(typeof(Tier)))
            {
                // 티어라면 그 티어에 존재하는 상상의 동물 전부 출력

                if (tier.ToString() == input)
                {
                    PrintCreaturesByTierKR(tier);
                    Console.WriteLine("----------------------------------------------------------");
                    return;
                }
            }

            // 위가 아니면 입력 값이 이름으로 탐색
            PrintCreaturesByName(input);
            Console.WriteLine("----------------------------------------------------------");
        }

        private void PrintCreaturesByTier(Tier tier)
        {
            Console.WriteLine($"{tier.ToString()} 등급의 상상의 동물들");
            foreach (FantasticCreature fantasticCreature in fantasticCreatures)
            {
                if(fantasticCreature.Tier == tier)
                {
                    fantasticCreature.PrintInfo();
                }
            }
        }

        private void PrintCreaturesByTierKR(TierKR tier)
        {
            Console.WriteLine($"{tier.ToString()} 등급의 상상의 동물들");
            foreach (FantasticCreature fantasticCreature in fantasticCreatures)
            {
                if ((int)fantasticCreature.Tier == (int)tier)
                {
                    fantasticCreature.PrintInfo();
                }
            }
        }

        private void PrintCreaturesByName(string name)
        {
            foreach (FantasticCreature fantasticCreature in fantasticCreatures)
            {
                if (fantasticCreature.Name == name)
                {
                    fantasticCreature.PrintInfo();
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 사전 초기화
            CreatureDictionary creatureDictionary = new CreatureDictionary();
            creatureDictionary.Init();

            // 사전에 상상의 동물 추가
            creatureDictionary.AddCreatures(new VermilionBird("주작", Tier.Normal, 10));
            creatureDictionary.AddCreatures(new AzureDragon("청룡", Tier.Rare, 20));
            creatureDictionary.AddCreatures(new BlackTortoise("현무", Tier.Epic, 30));
            creatureDictionary.AddCreatures(new WhiteTiger("백호", Tier.Legendary, 40));
            creatureDictionary.AddCreatures(new AzureDragon("황룡", Tier.Legendary, 50));

            while (true)
            {
                switch (creatureDictionary.SelectOption())
                {
                    case 1:
                        creatureDictionary.FindCreature();
                        break;
                    case 2:
                        Console.WriteLine("사전을 종료합니다.");
                        return;
                    default:
                        Console.WriteLine("존재하지 않는 옵션입니다.");
                        break;
                }
            }
        }
    }
}
