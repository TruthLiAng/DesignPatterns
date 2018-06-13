using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.Interface
{
    public interface IObject
    {
        bool ObserverRegister(IObserver observer);

        bool ObserverCancel(IObserver observer);

        void MessageChanged(string name, int age);

        void SetMessage(string name, int age);
    }
}
