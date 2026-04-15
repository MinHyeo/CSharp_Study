using System;
using System.Collections.Generic;

namespace CSharp_Study
{
    class Car
    {
        public event Action OnCheckLifeBelt;

        public void CheckLifeBeltInCar()
        {
            Console.WriteLine("안전벨트 착용 여부를 검사합니다.");
            OnCheckLifeBelt?.Invoke();
        }
    }

    class Human
    {
        private string _name;
        
        public Human(string name)
        {
            _name = name;
        }

        public void CheckLifeBelt()
        {
            Console.WriteLine($"{_name}은 안전벨트를 착용하였습니다.");
        }
    }

    class Algorithm
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                // 자동차
                Car car = new Car();

                // 탑승 인원
                Human human1 = new Human("탑승자 1");
                Human human2 = new Human("탑승자 2");
                Human human3 = new Human("탑승자 3");

                // 안전벨트 착용
                car.OnCheckLifeBelt += human1.CheckLifeBelt;
                car.OnCheckLifeBelt += human2.CheckLifeBelt;
                car.OnCheckLifeBelt += human3.CheckLifeBelt;

                // 안전벨트 검사
                car.CheckLifeBeltInCar();
            }
        }
    }
}
