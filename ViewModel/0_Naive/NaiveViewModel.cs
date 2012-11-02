using System.ComponentModel;

namespace Naive
{
    public class NaiveViewModel : INotifyPropertyChanged
    {
        private string _label = string.Empty;
        private int _counter = 0;

        public string Label
        {
            get { return _label; }
            set 
            {
                if (_label == value) return;
                OnPropertyChanged("Label");
                _label = value;
            }
        }

        public int Counter
        {
            get { return _counter; }
            set 
            {
                if (_counter == value) return;
                OnPropertyChanged("Counter");
                _counter = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


