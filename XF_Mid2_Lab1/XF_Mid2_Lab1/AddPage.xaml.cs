using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_Mid2_Lab1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            Add_Page.Text = languges.AppResource.AddPage;
            Name.Placeholder = languges.AppResource.Name;
            HomeNumber.Placeholder = languges.AppResource.HomeNumber;
            City.Placeholder = languges.AppResource.City;
            Add.Text = languges.AppResource.Add;
            Cancel.Text = languges.AppResource.Cancel;

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Name.Text)) && (!string.IsNullOrEmpty(HomeNumber.Text)) && (!string.IsNullOrEmpty(City.Text)))
            {
                var address = new Address()
                {
                    Name = Name.Text,
                    HomeNumber = HomeNumber.Text,
                    City = City.Text,
                };
                await App.AddressSQLite.SaveAddressAsync(address);
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Error", "Feilds are empty", "Ok");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}