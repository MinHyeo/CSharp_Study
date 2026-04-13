using System;
using System.Collections.Generic;

namespace CSharp_Study
{
    interface IItem
    {
        void Use();
        void Drop();
        void PrintDescription();
    }

    public class Item : IItem
    {
        protected string _name;
        protected string _description;

        public Item(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public virtual void Use()
        {
            Console.WriteLine($"{_name}을 사용하였습니다.");
        }

        public virtual void Drop()
        {
            Console.WriteLine($"{_name}을 버렸습니다.");
        }

        public virtual void PrintDescription()
        {
            Console.WriteLine($"- {_name}");
            Console.WriteLine($"{_description}");
        }
    }

    public class Potion : Item
    {
        public Potion(string name, string description) : base(name, description)
        {
        }
    }

    public class Weapon : Item
    {
        public Weapon(string name, string description) : base(name, description)
        {
        }

        public void Repair()
        {
            Console.WriteLine($"{_name}를 수리하였습니다.");
        }
    }

    public class QuestItem : Item
    {
        public QuestItem(string name, string description) : base(name, description)
        {
        }
    }

    public class Inventory
    {
        private List<IItem> _items;

        public Inventory()
        {
            _items = new List<IItem>();

            _items.Add(new Potion("포션", "체력과 마나를 회복하는 아이템입니다."));
            _items.Add(new Weapon("무기", "플레이어가 착용할 수 있는 장비입니다."));
            _items.Add(new QuestItem("퀘스트용 아이템", "퀘스트에서만 사용하는 아이템입니다."));
        }

        public void UseAllItem()
        {
            foreach(var item in _items)
            {
                item.PrintDescription();
                item.Use();

                if(item is Weapon)
                {
                    var weapon = item as Weapon;
                    weapon.Repair();
                }
            }
        }

        public void DropAllItem()
        {
            List<IItem> dropItems = new List<IItem>();

            foreach (var item in _items)
            {
                item.Drop();
                dropItems.Add(item);
            }

            foreach(var item in dropItems)
            {
                _items.Remove(item);
            }
        }
    }

    class Algorithm
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Inventory inventory = new Inventory();
                inventory.UseAllItem();
                inventory.DropAllItem();
            }
        }
    }
}
