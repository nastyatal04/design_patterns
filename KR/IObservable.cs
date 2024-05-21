using System;

namespace KR
{
    public interface IObservable
    {
        void AddObserve(Action observer);
        void NotifyObservers();
    }
}
