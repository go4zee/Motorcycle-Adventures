using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MotorcycleAdventures.Core;
using MotorcycleAdventures.Core.Models;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.Services;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class NewGoalViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        private readonly IRepository<Goal> _repository;

        public Goal Goal { get; set; }

        public ICollection<string> GoalCategories { get; set; }

        public ICommand SaveGoalCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public NewGoalViewModel(IPageService pageService)
        {
            _pageService = pageService;

            Goal  = new Goal();

            var connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();
            _repository = new Repository<Goal>(connection);

            GoalCategories = Constants.Dal.ListGoalCategoriesStrings();

            SaveGoalCommand = new Command<Goal>(async g => await SaveGoal());

            CancelCommand = new Command(async c => await Cancel());
        }

        private async Task Cancel()
        {
            await _pageService.PopToNavigationAsync();
        }

        private async Task SaveGoal()
        {
            if (!IsGoalValid(out string message))
            {
                await _pageService.DisplayAlert("Error", message, null, "Ok");
                return;
            }

            Goal.AddedOn = DateTime.Now;

            var addResult = await _repository.AddItemAsync(Goal);
            if (addResult)
            {
                await _pageService.PopToNavigationAsync(true);
                MessagingCenter.Send(this, MyEnum.MessagingCenterEnum.NewGoal.ToString(), Goal);
            }
            else
            {
                await _pageService.DisplayAlert("Error", "Could not save the goal, Please try again", null, "Ok");
            }
        }

        public bool IsGoalValid(out string message)
        {
            message = "";

            if (string.IsNullOrEmpty(Goal.Name))
            {
                message = "Enter a Goal";
                return false;
            }

            if (Goal.AchieveByDate.Equals(default(DateTime)))
            {
                message = "Enter a Valid Date For Achieving this Goal";
                return false;
            }

            if (string.IsNullOrEmpty(Goal.GoalCategoryName))
            {
                message = "Choose a Goal Category";
                return false;
            }

            return true;
        }
    }
}
