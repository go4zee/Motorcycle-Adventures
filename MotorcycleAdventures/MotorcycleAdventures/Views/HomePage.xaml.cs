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
        public HomeViewModel ViewModel
        {
            get => BindingContext as HomeViewModel;
            set => BindingContext = value;
        }

        public HomePage()
        {
            ViewModel = new HomeViewModel(new PageService(Navigation));

            InitializeComponent();
        }

        private void SaveAnswer_OnClicked(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute(TxtAnswer.Text);
        }
    }
}