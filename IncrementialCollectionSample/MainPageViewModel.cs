using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IncrementialCollectionSample
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IncrementalLoadingCollection<PersonSource, Person> _collection;
        public IncrementalLoadingCollection<PersonSource, Person> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged();
            }
        }
        public MainPageViewModel()
        {
            Collection = new IncrementalLoadingCollection<PersonSource, Person>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
