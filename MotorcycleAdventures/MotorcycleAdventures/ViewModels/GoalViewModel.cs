using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MotorcycleAdventures.Core.Customized;
using MotorcycleAdventures.Core.Models;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.Services;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class GoalViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        private readonly IRepository<Goal> _repository;

        private CustomObservableCollection<GoalCategoryViewModel> _goalCategories;

        public CustomObservableCollection<GoalCategoryViewModel> GoalCategories
        {
            get => _goalCategories;
            set => SetProperty(ref _goalCategories, value);
        }


        public NotifyTaskCompletion<GoalCategoryViewModel> ShowGoalNotificationTask { get; set; }

        public NotifyTaskCompletion<Goal> RemoveGoalNotificationTask { get; set; }


        public ICommand AddGoalCommand { get; set; }

        public ICommand ShowGoalCommand { get; set; }

        public ICommand RemoveGoalCommand { get; set; }

        public GoalViewModel()
        {
            var connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();
            _repository = new Repository<Goal>(connection);

            AddGoalCommand = new Command(AddGoal);

            ShowGoalCommand = new Command<GoalCategoryViewModel>(async s => await ShowGoals(s));

            RemoveGoalCommand = new Command<Goal>(RemoveGoal);

        }

        private void AddGoal()
        {
            throw new NotImplementedException();
        }

        public GoalViewModel(IPageService pageService) : this()
        {
            _pageService = pageService;
        }

        public async Task<GoalCategoryViewModel> GetGoalCategoryViewModel(string name)
        {
            return _goalCategories.First(g => g.GoalCategory.Name.Equals(name));
        }

        public async Task ShowGoals(GoalCategoryViewModel vmToFind)
        {
            GoalCategoryViewModel foundVm = _goalCategories.First(g => g.GoalCategory.Name.Equals(vmToFind.GoalCategory.Name));

            foundVm.AreChildrenVisible = !foundVm.AreChildrenVisible;

            _goalCategories.ReportItemChange(vmToFind);
        }

        public void RemoveGoal(Goal goal)
        {
            GoalCategoryViewModel goalCategoryViewModel = _goalCategories.First(g => g.GoalCategory.Name.Equals(goal.GoalCategoryName));
            var isRemoved = goalCategoryViewModel?.GoalCategory.Goals.Remove(goal) ?? false;

            if (isRemoved)
            {
                _goalCategories.ReportItemChange(goalCategoryViewModel);
            }

            //            return isRemoved;
        }
    }
}
