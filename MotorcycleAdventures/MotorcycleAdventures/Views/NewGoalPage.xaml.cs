using System;
using MotorcycleAdventures.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotorcycleAdventures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGoalPage : ContentPage
    {
        public NewGoalViewModel ViewModel
        {
            get => BindingContext as NewGoalViewModel;
            set => BindingContext = value;
        }

        public NewGoalPage(NewGoalViewModel context = null)
        {
            ViewModel = context ?? new NewGoalViewModel(new PageService(Navigation));

            InitializeComponent();
        }

        private void PickerItem_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //            ViewModel.Goal.GoalCategoryId = ((GoalCategoryViewModel) (DdlCategory.SelectedItem))?.GoalCategory?.Name;
        }

        private void AddGoal_Clicked(object sender, EventArgs e)
        {
            //var goal = new Goal()
            //{
            //    Name = TxtGoal.Text.Trim(),
            //    GoalCategoryName = ((GoalCategoryViewModel)(DdlCategory.SelectedItem))?.GoalCategory?.Name,
            //    AddedOn = DateTime.Now,
            //    AchieveByDate = DateTime.Now
            //};

            ViewModel.SaveGoalCommand.Execute(e);
        }

        private void Cancel_OnClicked(object sender, EventArgs e)
        {

        }
    }
}