using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Expressions
{
    public class ViewModel : INotifyPropertyChanged
    {
        public void Set<T>(ref T field, T value, Expression<Func<T>> propertyName)
        {
            string property = ResolveMemberNameFrom(propertyName);
            Set(ref field, value, property);
        }

        private static string ResolveMemberNameFrom<T>(Expression<Func<T>> propertyName)
        {
            return ((MemberExpression)propertyName.Body).Member.Name;
        }

        private void Set<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExpressionViewModel : ViewModel
    {
        private string _label = string.Empty;
        
        public string Label
        {
            get { return _label; }
            set 
            {
                Set(ref  _label, value, () => Label);           
            }
        }

        private int _counter;

        public int Counter
        {
            get { return _counter; }
            set
            {
                Set(ref _counter, value, () => Counter);
            }
        }
    }
}


