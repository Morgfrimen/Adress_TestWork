using System.Linq;
using System.Windows;
using System.Windows.Input;

using Adress_TestWork.Models;
using Adress_TestWork.ViewModels;

namespace Adress_TestWork.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Command_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindowViewModels vm = DataContext as MainWindowViewModels ?? throw new();

            if (e.Parameter is null && vm.AddressUsers.Count > 0)
            {
                vm.AddressUsers.RemoveAt(vm.AddressUsers.Count - 1);

                return;
            }

            bool result = e.Parameter is AddressUser deleteItem && vm.AddressUsers.Remove
                              (deleteItem);
            if (!result) MessageBox.Show("Message"); //TODO: REsourse
        }

        private void Command_New(object sender, ExecutedRoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModels vm)
            {
                AddressUser? lastItem = vm.AddressUsers.LastOrDefault();
                if(lastItem is null)
                    vm.AddressUsers.Add(new() {Id = 1});
                else
                    vm.AddressUsers.Add(new() {Id = lastItem.Id + 1});

            }
            else
                MessageBox.Show("Message"); //TODO: REsourse
        }

        public MainWindow() { InitializeComponent(); }
    }
}