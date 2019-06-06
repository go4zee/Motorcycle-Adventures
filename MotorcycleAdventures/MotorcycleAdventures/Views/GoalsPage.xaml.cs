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

        private void AddNewGoal_OnClicked(object sender, EventArgs e)
        {
            ViewModel.AddGoalCommand.Execute(e);
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModel.ShowGoalCommand.Execute(e.Item as GoalCategoryViewModel);
        }

        private void RemoveGoal_OnTap(object sender, EventArgs e)
        {
        }
    }
}