using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CSharp_Study
{
    public class Monster 
    {
        public virtual void Attack()
        {
            // virtual funcion
        }
    }

    public class TurtleMonster : Monster
    {
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("거북이 공격!!");
        }
    }

    public class MushroomMonster : Monster
    {
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("버섯 공격!!");
        }
    }

    public class BombMonster : Monster
    {
        public override void Attack()
        {
            base.Attack();
            Console.WriteLine("자폭!!");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // 몬스터 리스트
            List<Monster> monsterList = new List<Monster>();
            monsterList.Add(new TurtleMonster());
            monsterList.Add(new MushroomMonster());
            monsterList.Add(new BombMonster());
            monsterList.Add(new BombMonster());

            // 몬스터 공격
            int idx = 0;
            Dictionary<int, Monster> removeMonsterDictionary = new Dictionary<int, Monster>();
            foreach(var monster in monsterList)
            {
                monster.Attack();

                if(monster is BombMonster bombMonster)
                {
                    removeMonsterDictionary[idx] = bombMonster;
                }

                idx++;
            }

            // 폭탄 몬스터 삭제
            foreach(var monster in removeMonsterDictionary)
            {
                Console.WriteLine($"{monster.Key + 1}번째 몬스터가 죽었습니다.");
                monsterList.Remove(monster.Value);
            }
        }
    }
}
