using System;
using System.Collections.Generic;

namespace CSharp_Study
{
    public class Email
    {
        private string _receive;
        private string _content;

        public void SendEmail(Person person)
        {
            _receive = person.Name;
            Console.WriteLine($"받는 이 : {_receive}");

            Console.Write("내용을 입력해주세요 : ");
            _content = Console.ReadLine();

            person.ReceiveEmail(_content, SucessSend);
        }

        public void SucessSend()
        {
            Console.WriteLine("정상적으로 이메일이 보내졌습니다.");
        }
    }

    public class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public void ReceiveEmail(string content, Action callback)
        {
            callback?.Invoke();
        }
    }

    class Algorithm
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Email email = new Email();
                Person person = new Person("민형");

                email.SendEmail(person);
            }
        }
    }
}
