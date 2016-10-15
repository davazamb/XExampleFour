using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XExampleFour.Pages;
using XExampleFour.Services;

namespace XExampleFour.ViewModels
{
    public class MenuItemViewModel
    {
        private NavigationService navigationService;

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(() => navigationService.Navigate(PageName));
            }
        }
        
    }

}
