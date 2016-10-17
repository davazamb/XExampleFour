using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XExampleFour.Cells;
using XExampleFour.Classes;

namespace XExampleFour.Pages
{
    public partial class MainPage : ContentPage
    {
        private List<Product> products;

        public MainPage()
        {
            InitializeComponent();
            LoadProducts();

            servicesListView.ItemTemplate = new DataTemplate(typeof(ServiceCell));
            servicesListView.RowHeight = 70;
        }
        private void LoadProducts()
        {
            using (var da = new DataAccess())
            {
                products = da.GetList<Product>(false).OrderBy(p => p.Description).ToList();
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var da = new DataAccess())
            {
                var services = da.GetList<Service>(true)
                                    .Where(s => s.DateRegistered.Year == DateTime.Today.Year &&
                                                s.DateRegistered.Month == DateTime.Today.Month &&
                                                s.DateRegistered.Day == DateTime.Today.Day)
                                    .OrderByDescending(s => s.DateService)
                                    .ToList();
                servicesListView.ItemsSource = services;
            }
        }
    }
}
