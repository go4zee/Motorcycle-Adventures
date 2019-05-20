using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleAdventures.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotorcycleAdventures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomeViewModel HomeViewModel
        {
            get => BindingContext as HomeViewModel;
            set => BindingContext = value;
        }

        public HomePage()
        {
            BindingContext = new HomeViewModel(new PageService(Navigation));

            InitializeComponent();
        }
    }
}