﻿using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using Adress_TestWork.Models;
using Adress_TestWork.Resource;
using Adress_TestWork.ViewModels;

using LoadData;

using Microsoft.Win32;

namespace Adress_TestWork.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModels _vm;
        public static readonly RoutedCommand Load = new();

        private void Command_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is null && _vm.AddressUsers.Count > 0)
            {
                _vm.AddressUsers.RemoveAt(_vm.AddressUsers.Count - 1);

                return;
            }

            bool result = e.Parameter is AddressUser deleteItem && _vm.AddressUsers.Remove
                              (deleteItem);
            if (!result)
                MessageBox.Show
                (
                    this, Localize.ErrorCommandButton, "", MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
        }

        private void Command_LoadXML(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = Filter;

            if (openFileDialog.ShowDialog() is false) return;

            string path = openFileDialog.FileName;

            try
            {
                _vm.AddressUsers = new(LoadCore.GetLoadXML().LoadFile<AddressUser>(path));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show
                (
                    this, Localize.FileNotFound, string.Empty, MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void Command_New(object sender, ExecutedRoutedEventArgs e)
        {
            if (_vm is not null && _vm.AddressUsers is not null)
            {
                AddressUser? lastItem = _vm.AddressUsers.LastOrDefault();
                if (lastItem is null)
                    _vm.AddressUsers.Add(new() {Id = 1});
                else
                    _vm.AddressUsers.Add(new() {Id = lastItem.Id + 1});
            }
            else
            {
                MessageBox.Show
                (
                    this, Localize.ErrorCommandButton, "", MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private const string Filter = @"XML File(*.xml)|*.xml";

        public MainWindow()
        {
            InitializeComponent();
            _vm = DataContext as MainWindowViewModels ?? throw new();
        }
    }
}