using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XExampleFour.Pages;

namespace XExampleFour.Services
{
    public class NavigationService
    {
        public async void Navigate(string PageName)
        {
            App.Master.IsPresented = false;

            switch (PageName)
            {
                case "AlarmsPage":
                    await App.Navigator.PushAsync(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await App.Navigator.PushAsync(new ClientsPage());
                    break;
                case "SettingsPage":
                    await App.Navigator.PushAsync(new SettingsPage());
                    break;
                case "NewOrderPage":
                    await App.Navigator.PushAsync(new NewOrderPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    break;
            }
        }

        internal void SetMainPage(Page page)
        {
            App.Current.MainPage = page;
        }
    }

}
