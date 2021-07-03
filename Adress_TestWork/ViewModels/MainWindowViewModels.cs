using System.Collections.ObjectModel;

using Adress_TestWork.Models;

namespace Adress_TestWork.ViewModels
{
    public sealed class MainWindowViewModels : ViewModelsBase
    {
        private readonly ObservableCollection<AddressUser> _addressUsers = new();

        public ObservableCollection<AddressUser> AddressUsers
        {
            get => _addressUsers;
            set
            {
                _addressUsers.Add(new());
                OnPropertyChanged(nameof(AddressUsers));
            }
        }
    }
}