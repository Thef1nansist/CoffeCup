using DesktopApp.Helper;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.Commands
{
    class NextPagePopularHousesCommand :ICommand
    {
        private PopularCoffeeHousesViewModel _viewModel;

        public PopularCoffeeHousesViewModel ViewModel { get => _viewModel; set => _viewModel = value; }

        public NextPagePopularHousesCommand(PopularCoffeeHousesViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //1

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return true;
            }
            var pagingVar = parameter as Paging;
            bool result = true;

            if (pagingVar.CurrentPage == pagingVar.TotalPages)
            {
                result = false;
            }
            return result;
        }

        public void Execute(object parameter)
        {
            _viewModel.GoToNextPage();
        }
    }
}
