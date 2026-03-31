using System;
using System.Diagnostics;

namespace OZ_Coding_CS
{
    class CafeStaff
    {
        private int _money;
        private int _coffeeBeanCount;

        public CafeStaff(int money, int coffeeBeanCount)
        {
            _money = money;
            _coffeeBeanCount = coffeeBeanCount;

            Console.WriteLine("카페 직원 출근!");
        }

        public void MakeCoffee(int money)
        {
            Console.WriteLine($"커피 가격은 {money}원 입니다.");
            _money += money;
            _coffeeBeanCount -= 1;
        }

        public void CallCustomer(Customer customer)
        {
            Console.WriteLine($"{customer._id}번 손님. 주문하신 커피 나왔습니다.");
            GiveCoffee(customer);
        }

        private void GiveCoffee(Customer customer)
        {
            customer.DrinkCoffee(10);
        }
    }

    class Customer
    {
        public int _id;
        private int _money;
        private int _fatigability;

        public Customer(int id, int money, int fatigability)
        {
            _id = id;
            _money = money;
            _fatigability = fatigability;

            Console.WriteLine("손님 입장");
        }

        public void OrderCoffee(CafeStaff staff, int coffePrice)
        {
            Console.WriteLine("커피 한잔 주세요!");

            _money = _money - coffePrice;
            staff.MakeCoffee(coffePrice);
        }

        public void DrinkCoffee(int fatigability)
        {
            _fatigability -= fatigability;
            Console.WriteLine($"커피를 마셔 피로도가 10 줄었습니다. 남은 피로도 : {_fatigability}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CafeStaff cafeStaff = new CafeStaff(0, 10);
            Customer customer = new Customer(1, 5000, 100);

            customer.OrderCoffee(cafeStaff, 1000);

            cafeStaff.CallCustomer(customer);
        }
    }
}
