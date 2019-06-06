using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace MotorcycleAdventures.Core.Customized
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        public CustomObservableCollection() { }
        public CustomObservableCollection(IEnumerable items) : this()
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public void ReportItemChange(T item)
        {
            var indexOf = IndexOf(item);
            NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                                                    item,
                                                    item,
                                                    indexOf);
            OnCollectionChanged(args);
        }
    }
}
