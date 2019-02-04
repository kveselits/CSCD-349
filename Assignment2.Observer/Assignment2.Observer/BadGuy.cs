using System;
using System.Collections.Generic;

namespace Assignment2.Observer
{
    public class BadGuy : IObserver<BadGuy>
    {
        public EyeOfSauron Eye { get; }
        public string Name { get; }
        private IDisposable _unsubscriber;

        public BadGuy(EyeOfSauron eye, string name)
        {
            this.Eye = eye;
            this.Name = name;
            _unsubscriber = Eye.Subscribe(this);
        }

        public void OnCompleted()
        {
            Console.WriteLine(Eye.GoodGuys);
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(BadGuy value)
        {
            Console.WriteLine($"{value.Name} reports that there are: " +
                              $"{value.Eye.GoodGuys[0]} hobbits, " +
                              $"{value.Eye.GoodGuys[1]} elves, " +
                              $"{value.Eye.GoodGuys[2]} dwarves, " +
                              $"{value.Eye.GoodGuys[3]} men");
        }

        public void Defeated()
        {
            Eye.BadGuys.Remove(this);
        }
    }
}