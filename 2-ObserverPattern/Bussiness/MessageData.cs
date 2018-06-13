using ObserverPattern.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.Bussiness
{
    public class MessageData : IObject
    {
        private List<IObserver> observers = new List<IObserver>();
        private string name;
        private int age;

        public void MessageChanged(string name, int age)
        {
            foreach (var ob in observers)
            {
                ob.update(name, age);
            }
        }

        public bool ObserverCancel(IObserver observer)
        {
            bool res = true;
            try
            {
                if (observers.Contains(observer))
                {
                    observers.Remove(observer);
                    return res;
                }
                else
                {
                    return false;
                }                
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ObserverRegister(IObserver observer)
        {
            bool res = true;
            try
            {
                if (!observers.Contains(observer))
                {
                    observers.Add(observer);
                }
                return res;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void SetMessage(string name, int age)
        {
            MessageChanged(name, age);
        }
    }
}
