using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XExampleFour.Classes;
using XExampleFour.Pages;
using XExampleFour.Services;

namespace XExampleFour.ViewModels
{
    public class MainViewModel
    {
        #region Attributes
        private NavigationService navigationService;
        //private List<Product> products;
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            navigationService = new NavigationService();
            LoadMenu();
            //LoadData();
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


        //private void LoadData()
        //{
        //    Orders = new ObservableCollection<OrderViewModel>();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        Orders.Add(new OrderViewModel
        //        {
        //            Title = "Hola, Buen dia",
        //            DeliveryDate = DateTime.Today,
        //            Description = "Haciendo uso de xamarin app, TecnicomputoZ",
        //        });
        //    }
        //}
        //private void LoadData()
        //{
        //    using (var da = new DataAccess())
        //    {
        //        products = da.GetList<Product>(false).OrderBy(p => p.Description).ToList();
        //    }

        //    foreach (var Service in Services)
        //    {
        //        Services.Add(new Service
        //        {
        //            DateRegistered = Service.DateRegistered,
        //            Product = Service.Product,
        //            Quantity = Service.Quantity,
        //            Price = Service.Value,
        //        });
        //    }
        //    navigationService.SetMainPage(new MasterPage());
        //}


        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "logo.png",
                Title = "Servicios",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_orders.png",
                PageName = "ProductPage",
                Title = "Productos",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_client.png",
                PageName = "ConsultPage",
                Title = "Consultas",
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
