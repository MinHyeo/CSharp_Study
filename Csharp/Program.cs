using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Globalization;
using System.Xml.Linq;

namespace CSharp_Study
{
    public class FantasticCreature
    {
        private int _id;
        public string Name { get; private set; }

        public FantasticCreature(int id, string name)
        {
            _id = id;
            Name = name;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{_id} : {Name}");
        }
    }

    public class CreatureDictionary
    {
        private Dictionary<int ,FantasticCreature> _creatureDictionary;
        private int _lastId;

        // 사전 초기화
        public void Init()
        {
            _creatureDictionary = new Dictionary<int, FantasticCreature>();
            _lastId = 1000;
        }

        public void PrintOption()
        {
            Console.WriteLine("|판타지 동물 사전|");
            Console.WriteLine("1. 검색");
            Console.WriteLine("2. 추가");
            Console.WriteLine("3. 삭제");
            Console.WriteLine("4. 전체 조회");
            Console.WriteLine("5. 종료");
        }

        // 사용 기능 입력 받기
        // 프로그램을 종료하면 false를 반환
        public bool InputSelectOption()
        {
            int selectNum;

            do
            {
                Console.Write("사용할 기능을 입력해주세요 : ");
            } while (!int.TryParse(Console.ReadLine(), out selectNum) || selectNum >= 6 || selectNum <= 0);

            switch (selectNum)
            {
                case 1:
                    FindCreature();
                    break;
                case 2:
                    AddCreature();
                    break;
                case 3:
                    DeletedCreature();
                    break;
                case 4:
                    SearchAll();
                    break;
                case 5:
                    Console.WriteLine("프로그램을 종료합니다");
                    return false;
            }
            Console.WriteLine("엔터키를 입력해주세요");
            string a = Console.ReadLine();
            return true;
        }

        // 판타지 동물 검색
        private void FindCreature()
        {
            string input;
            Console.Write("검색할 동물의 이름이나 ID를 입력해주세요 : ");
            input = Console.ReadLine();

            // 입력이 숫자면 id로 검색
            if(int.TryParse(input, out int id))
            {
                if (_creatureDictionary.ContainsKey(id))
                {
                    FantasticCreature creature = _creatureDictionary[id];
                    Console.WriteLine("--------------------------------------");
                    creature.PrintInfo();
                    Console.WriteLine("--------------------------------------");

                    return;
                }
            }
            else
            {
                string name = input;
                foreach(var createrePair in _creatureDictionary)
                {
                    FantasticCreature creature = createrePair.Value;

                    if(creature.Name == name)
                    {
                        Console.WriteLine("--------------------------------------");
                        creature.PrintInfo();
                        Console.WriteLine("--------------------------------------");
                        return;
                    }
                }
            }

            Console.WriteLine("찾으시는 동물은 없습니다.");
        }

        // 판타지 동물 추가
        private void AddCreature()
        {
            Console.Write("추가할 동물의 이름을 입력해주세요 : ");
            string name = Console.ReadLine();
            int id = _lastId;

            // TODO : 중복 검사 기능 추가해야 함
            if (!CheckOverlapCreature(name))
            {
                FantasticCreature fantasticCreature = new FantasticCreature(id, name);
                _creatureDictionary[id] = fantasticCreature;

                _lastId = id + 1;
            }        
        }

        private bool CheckOverlapCreature(string name)
        {
            foreach(var creaturePair in _creatureDictionary)
            {
                FantasticCreature creature = creaturePair.Value;

                if (creature.Name == name)
                    return true;
            }

            return false;
        }

        // 판타지 동물 삭제
        private void DeletedCreature()
        {
            string input;
            Console.Write("삭제할 동물의 이름이나 ID를 입력해주세요 : ");
            input = Console.ReadLine();

            // 입력이 숫자면 id로 검색
            if (int.TryParse(input, out int id))
            {
                if (_creatureDictionary.ContainsKey(id))
                {
                    _creatureDictionary.Remove(id);
                    Console.WriteLine("정상적으로 삭제되었습니다.");
                    return;
                }
            }
            else
            {
                string name = input;
                foreach (var createrePair in _creatureDictionary)
                {
                    id = createrePair.Key;
                    FantasticCreature creature = createrePair.Value;

                    if (creature.Name == name)
                    {
                        _creatureDictionary.Remove(id);
                        Console.WriteLine("정상적으로 삭제되었습니다.");
                        return;
                    }
                }
            }

            Console.WriteLine("찾으시는 동물은 없습니다.");
        }

        // 전체 조회
        private void SearchAll()
        {
            int lastId = 1000;

            Console.WriteLine("전체 목록");
            Console.WriteLine("--------------------------------------");
            foreach(var creaturePair in _creatureDictionary)
            {
                int id = creaturePair.Key;
                FantasticCreature creature = creaturePair.Value;

                // 앞에 비어있는 만큼 빈 공간 출력
                int idx = id - lastId;
                for (int i = 1; i <= idx - 1; i++)
                {
                    Console.WriteLine($"{lastId + i} : -");
                }
                creature.PrintInfo();

                lastId = id;
            }
            Console.WriteLine("--------------------------------------");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 사전 초기화
            CreatureDictionary creatureDictionary = new CreatureDictionary();
            creatureDictionary.Init();

            while (true)
            {
                creatureDictionary.PrintOption();
                if (!creatureDictionary.InputSelectOption())
                    break;

                Console.Clear();
            }
        }
    }
}
