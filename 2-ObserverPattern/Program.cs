using ObserverPattern.Bussiness;
using System;

namespace _2_ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageData messageData = new MessageData();

            Displayer player1 = new Displayer(messageData, "player1");
            Displayer player2 = new Displayer(messageData, "player2");
            Displayer player3 = new Displayer(messageData, "player3");
            Displayer player4 = new Displayer(messageData, "player4");

            messageData.SetMessage("xiao", 1);
            messageData.SetMessage("zhong", 2);
            messageData.SetMessage("da", 3);

            Console.ReadKey();
        }
    }
}
