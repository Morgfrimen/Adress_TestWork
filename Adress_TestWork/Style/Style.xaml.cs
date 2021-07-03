using System.Windows;
using System.Windows.Controls;

namespace Adress_TestWork.Style
{
    public partial class Style
    {
        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Focus();
            textBox.SelectAll();
        }

        private void Validation_OnError(object? sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show("Ошибка");
        }
    }
}