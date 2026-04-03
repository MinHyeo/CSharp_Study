using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp_Study
{
    public class Character
    {
        protected string _name;

        public Character(string name)
        {
            _name = name;
        }

        // 공격
        public virtual void Attack()
        {
            // virtual function
        }
    }

    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {

        }

        public override void Attack()
        {
            Console.WriteLine($"{_name}가 검으로 공격합니다.");
        }

        public void Defense()
        {
            Console.WriteLine("다음 공격을 방어합니다.");
        }
    }

    public class Archar : Character
    {
        public Archar(string name) : base(name)
        {

        }

        public override void Attack()
        {
            Console.WriteLine($"{_name}가 화살로 공격합니다.");
        }

        public void ReloadArrows()
        {
            Console.WriteLine("화살을 재장전합니다.");
        }
    }

    public class Magician : Character
    {
        public Magician(string name) : base(name)
        {

        }

        public override void Attack()
        {
            Console.WriteLine($"{_name}가 마법으로 공격합니다.");
        }

        public void RecoveryMP()
        {
            Console.WriteLine("마나를 회복합니다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Character> characters = new List<Character>();
            characters.Add(new Warrior("전사"));
            characters.Add(new Archar("궁수"));
            characters.Add(new Magician("마법사"));

            foreach(Character character in characters)
            {
                character.Attack();

                if(character is Warrior)
                {
                    Warrior warrior = character as Warrior;
                    warrior.Defense();
                }
                else if (character is Archar)
                {
                    Archar aractar = character as Archar;
                    aractar.ReloadArrows();
                }
                else if (character is Magician)
                {
                    Magician magician = character as Magician;
                    magician.RecoveryMP();
                }
            }
        }
    }
}
