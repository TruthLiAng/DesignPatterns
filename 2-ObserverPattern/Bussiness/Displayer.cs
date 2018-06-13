using ObserverPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.Bussiness
{
    public class Displayer : IObserver, IDisplay 
    {
        private string playerName;
        private string name;
        private int age;

        public Displayer(MessageData message, string playerName)
        {
            this.playerName = playerName;
            message.ObserverRegister(this);
        }
        public void Display()
        {
            Console.WriteLine(playerName + "----------------" + name + ":" + age + "岁");
        }

        public void update(string name, int age)
        {
            this.name = name;
            this.age = age;

            Display();
        }
    }
}
