using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sem_IMTA_Restaurace.ViewModels
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected bool isBusy = false;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                NotifyPropertyChanged();
            }
        }

        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
