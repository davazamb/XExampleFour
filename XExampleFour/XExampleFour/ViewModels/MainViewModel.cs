using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XExampleFour.Pages;
using XExampleFour.Services;

namespace XExampleFour.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            navigationService = new NavigationService();
            LoadMenu();
            LoadData();
        }
        #endregion
        #region Commands
        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            navigationService.Navigate(pageName);
        }
        public ICommand StartCommand { get { return new RelayCommand(Start); } }

        private void Start()
        {
            navigationService.SetMainPage(new MasterPage());
        }

        #endregion

        #region Methods


        private void LoadData()
        {
            Orders = new ObservableCollection<OrderViewModel>();

            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel
                {
                    Title = "Hola, Buen dia",
                    DeliveryDate = DateTime.Today,
                    Description = "Haciendo uso de xamarin app, TecnicomputoZ",
                });
            }
        }


        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_orders.png",
                PageName = "MainPage",
                Title = "Pedidos",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_client.png",
                PageName = "ClientsPage",
                Title = "Clientes",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_alarm.png",
                PageName = "AlarmsPage",
                Title = "Alarmas",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_settings.png",
                PageName = "SettingsPage",
                Title = "Ajustes",
            });
        }
        #endregion
    }

}
