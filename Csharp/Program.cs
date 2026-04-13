using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace CSharp_Study
{
    class Furniture
    {
        public int Id { get; private set; }
        private string _name;
        private string _description;

        public Furniture(int id, string name, string description)
        {
            Id = id;
            _name = name;
            _description = description;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Id} : {_name}");
            Console.WriteLine($"{_description}");
        }
    }

    class FurnitureStore
    {
        private Dictionary<string, Furniture> _furnitureList;

        public FurnitureStore()
        {
            _furnitureList = new Dictionary<string, Furniture>();
        }

        public void LoadTodayFurniture()
        {
            _furnitureList["desk"] = new Furniture(1000, "책상", "책상입니다. 위에서 작업을 할 수 있습니다.");
            _furnitureList["chair"] = new Furniture(1001, "의자", "의자입니다. 앉아서 쉴 수 있습니다.");
            _furnitureList["bed"] = new Furniture(1002, "침대", "침대입니다. 누워서 잘 수 있습니다.");
            _furnitureList["wardrobe"] = new Furniture(1003, "옷장", "옷장입니다. 옷을 보관할 수 있습니다.");
            _furnitureList["table"] = new Furniture(1004, "식탁", "식탁입니다. 위에서 식사를 할 수 있습니다.");
            _furnitureList["bookshelf"] = new Furniture(1005, "책장", "책장입니다. 책을 보관할 수 있습니다.");
            _furnitureList["sofa"] = new Furniture(1006, "소파", "소파입니다. 푹신하게 앉아 쉴 수 있습니다.");
            _furnitureList["dressing_table"] = new Furniture(1007, "화장대", "화장대입니다. 화장품을 보관하고 화장을 할 수 있습니다.");
            _furnitureList["shoe_rack"] = new Furniture(1008, "신발장", "신발장입니다. 신발을 보관할 수 있습니다.");
            _furnitureList["dresser"] = new Furniture(1009, "서립장", "서립장입니다. 여러 물건을 보관할 수 있습니다.");
        }

        public void OpenStore()
        {
            Console.WriteLine("물품 리스트");
            Console.WriteLine("-------------------------------------");
            foreach(var kv in _furnitureList)
            {
                Furniture _furniture = kv.Value;
                _furniture.PrintInfo();
            }
            Console.WriteLine("-------------------------------------");
        }
    }

    class Algorithm
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                FurnitureStore furnitureStore = new FurnitureStore();

                furnitureStore.LoadTodayFurniture();
                furnitureStore.OpenStore();
            }
        }
    }
}
