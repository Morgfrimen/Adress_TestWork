using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Adress_TestWork.ViewModels
{
    public abstract class ViewModelsBase : INotifyPropertyChanged
    {
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}