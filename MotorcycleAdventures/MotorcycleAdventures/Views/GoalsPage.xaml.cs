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
    public partial class GoalsPage : ContentPage
    {
        public GoalViewModel ViewModel
        {
            get => BindingContext as GoalViewModel;
            set => BindingContext = value;
        }

        public GoalsPage()
        {
            ViewModel = new GoalViewModel(new PageService(Navigation));

            InitializeComponent();
        }
    }
}