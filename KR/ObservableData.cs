using System;
using System.Collections.Generic;

namespace KR
{
    public class ObservableData : IObservable
    {
        private List<Action> _observers;
        private List<Airplane> _data;

        public List<Airplane> Data
        {
            get => _data;
            set
            {
                _data = value;
                NotifyObservers();
            }
        }

        public Airplane? SelectedAirplane = null;
        public int SelectedAirplaneIndex = -1;

        private void OnSelected(Airplane airplane)
        {
            SelectedAirplane = airplane;
            SelectedAirplaneIndex = _data.IndexOf(airplane);
        }

        public ObservableData(List<Airplane> data)
        {
            _observers = new List<Action>();
            _data = data;
        }
        public Airplane this[int index]
        {
            get => _data[index];
            set
            {
                value.OnSelected = OnSelected;
                _data[index] = value;
                NotifyObservers();
            }
        }

        public void Add(Airplane air)
        {
            air.OnSelected = OnSelected;
            _data.Add(air);
            NotifyObservers();
        }
        public void RemoveAt(int index)
        {
            _data.RemoveAt(index);
            NotifyObservers();
        }
        public void AddObserve(Action observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer();
        }
    }
}
