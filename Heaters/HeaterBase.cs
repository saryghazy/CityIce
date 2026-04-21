using IceCity.Models;
using IceCity.Patterns.Observer;
using IceCity.Patterns.State;
using IceCity.Interfaces;
using System;
using System.Collections.Generic;

namespace IceCity.Heaters
{
    public abstract class HeaterBase : IHeater, IObservableHeater
    {
        public event EventHandler<EventArgs> HeaterChanged;
        public event EventHandler<EventArgs> OpenHeater;
        public event EventHandler<HeaterDurationEventArgs> CloseHeater;

        private static int _idCounter = 1;
        private static readonly Random _random = new();

        private readonly List<IObserver> _observers = new();

        private DateTime? _lastOpenTime;
        private IHeaterState _state;

        public int Id { get; private set; }
        public double PowerValue { get; private set; }

        public IHeaterState CurrentStateObject => _state;
        public string CurrentStateName => _state.GetType().Name;

        protected abstract double FailureChance { get; }

        protected HeaterBase(double powerValue)
        {
            Id = _idCounter++;
            PowerValue = powerValue;
            _state = new OffState(this);
        }

        public abstract double CalculateEffectivePower();

        public void TurnOn() => _state.TurnOn();
        public void TurnOff() => _state.TurnOff();

        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
                observer.Update(message);
        }

        protected void OnOpen()
        {
            if (_random.NextDouble() < FailureChance)
                throw new HeaterFailedException($"{GetType().Name} failed!");

            _lastOpenTime = DateTime.UtcNow;

            OpenHeater?.Invoke(this, EventArgs.Empty);
            HeaterChanged?.Invoke(this, EventArgs.Empty);

            Notify($"{GetType().Name} turned ON");
        }

        protected void OnClose()
        {
            if (!_lastOpenTime.HasValue)
                return;

            var closeTime = DateTime.UtcNow;
            var hours = (closeTime - _lastOpenTime.Value).TotalHours;

            CloseHeater?.Invoke(this,
                new HeaterDurationEventArgs(closeTime, hours, PowerValue));

            HeaterChanged?.Invoke(this, EventArgs.Empty);

            Notify($"{GetType().Name} turned OFF");

            _lastOpenTime = null;
        }

        public void SetState(IHeaterState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            HeaterChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Open() => OnOpen();
        public void Close() => OnClose();

        public void Repair()
        {
            if (_state is FaultState)
                SetState(new OffState(this));
        }
    }
}