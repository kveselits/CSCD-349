using System;
using System.Collections.Generic;

namespace Assignment2.Observer
{
    public class EyeOfSauron : IObservable<BadGuy>
    {
        public readonly List<IObserver<BadGuy>> BadGuys;
        public List<int> GoodGuys { get; } = new List<int>(new int[4]);

        public EyeOfSauron()
        {
            BadGuys = new List<IObserver<BadGuy>>();
        }
        public void SetEnemies(int hobbits, int elves, int dwarves, int men)
        {
            //Each list index corresponds to of spotted races
            GoodGuys[0] = hobbits;
            GoodGuys[1] = elves;
            GoodGuys[2] = dwarves;
            GoodGuys[3] = men;
            foreach (BadGuy badGuy in BadGuys)
            {
                badGuy.OnNext(badGuy);
            }

        }

        private class Unsubscriber : IDisposable
        //https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-implement-an-observer
        {
            private List<IObserver<BadGuy>> _observers;
            private IObserver<BadGuy> _observer;

            public Unsubscriber(List<IObserver<BadGuy>> observers, IObserver<BadGuy> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<BadGuy> observer)
        {
            BadGuys.Add(observer);
            return new Unsubscriber(BadGuys, observer);
        }
    }
}