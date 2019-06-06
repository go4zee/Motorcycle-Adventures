using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MotorcycleAdventures.Core;
using MotorcycleAdventures.Core.Customized;
using MotorcycleAdventures.Core.Models;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.Services;
using MotorcycleAdventures.Views;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class GoalViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        private readonly IRepository<Goal> _repository;

        public string test = "My Test";

        private CustomObservableCollection<GoalCategoryViewModel> _goalCategories;

        public CustomObservableCollection<GoalCategoryViewModel> GoalCategories
        {
            get => _goalCategories;
            set => SetProperty(ref _goalCategories, value);
        }

        public NotifyTaskCompletion<CustomObservableCollection<GoalCategoryViewModel>> GetGoalsNotificationTask { get; set; }

        public ICommand AddGoalCommand { get; set; }

        public ICommand ShowGoalCommand { get; set; }

        public ICommand RemoveGoalCommand { get; set; }

        public GoalViewModel()
        {
            var connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();
            _repository = new Repository<Goal>(connection);

            GetGoalsNotificationTask = new NotifyTaskCompletion<CustomObservableCollection<GoalCategoryViewModel>>(task: GetAllGoals());

            GetGoalsNotificationTask.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals(nameof(GetGoalsNotificationTask.IsSuccessfullyCompleted))
                    && GetGoalsNotificationTask.IsSuccessfullyCompleted)
                {
                    GoalCategories = GetGoalsNotificationTask.Result;

                    OnPropertyChanged(nameof(GoalCategories));
                }

                if (args.PropertyName.Equals(nameof(GetGoalsNotificationTask.IsTimedOut)))
                {
                    var _ = _pageService.DisplayAlert("Error", "Timed Out", null, "Ok").Result;
                }
            };

            AddGoalCommand = new Command(async a => await AddGoal());

            ShowGoalCommand = new Command<GoalCategoryViewModel>(g =>
            {
                var vmToSearch = GetGoalCategoryViewModel(g.GoalCategoryName)
                                .ContinueWith(r => ShowGoals(r.Result));
            });

            RemoveGoalCommand = new Command<Goal>(async g => await RemoveGoal(g));

            MessagingCenter.Subscribe<NewGoalViewModel, Goal>(this, MyEnum.MessagingCenterEnum.NewGoal.ToString(), NewGoalOnAdded);

        }

        private void NewGoalOnAdded(NewGoalViewModel sender, Goal arg)
        {
            var goalCategoryToAddTo = _goalCategories.FirstOrDefault(g => g.GoalCategoryName == arg.GoalCategoryName);
            if (goalCategoryToAddTo == null)
            {
                return;
            }

            goalCategoryToAddTo.Goals.Add(arg);
            _goalCategories.ReportItemChange(goalCategoryToAddTo);
        }

        private async Task<CustomObservableCollection<GoalCategoryViewModel>> GetAllGoals()
        {
            var goalCategoryDictionary = (await _repository.GetItemsAsync(g => g.Id > 0))
                                                            .GroupBy(g => g.GoalCategoryName)
                                                            .ToDictionary(g => g.Key, 
                                                                          g => g.ToList());

            var goalCategories = Constants.Dal.ListGoalCategoriesStrings()
                                        .Select(g => new GoalCategoryViewModel(g))
                                        .ToList();

            foreach (var gc in goalCategories)
            {
                if (goalCategoryDictionary.TryGetValue(gc.GoalCategoryName, out var goals))
                {
                    gc.Goals = new ObservableCollection<Goal>(goals);
                }
            }

            return new CustomObservableCollection<GoalCategoryViewModel>(goalCategories);
        }

        public GoalViewModel(IPageService pageService) : this()
        {
            _pageService = pageService;
        }

        public async Task<GoalCategoryViewModel> GetGoalCategoryViewModel(string name)
        {
            return _goalCategories.First(g => g.GoalCategoryName.Equals(name));
        }

        private async Task AddGoal()
        {
            var context = new NewGoalViewModel(_pageService);

            var newGoalPage = new NewGoalPage(context);

            await _pageService.PushToNavigationAsync(newGoalPage);
        }

        public async Task ShowGoals(GoalCategoryViewModel vmToFind)
        {

            GoalCategoryViewModel foundVm = _goalCategories.First(g => g.GoalCategoryName.Equals(vmToFind.GoalCategoryName));
            foundVm.AreChildrenVisible = !foundVm.AreChildrenVisible;

            _goalCategories.ReportItemChange(foundVm);
        }

        public async Task RemoveGoal(Goal goal)
        {
            GoalCategoryViewModel goalCategoryViewModel = _goalCategories.First(g => g.GoalCategoryName.Equals(goal.GoalCategoryName));
            var isRemoved = goalCategoryViewModel?.Goals.Remove(goal) ?? false;

            if (isRemoved)
            {
                _goalCategories.ReportItemChange(goalCategoryViewModel);

                var removeResult = await _repository.DeleteItemAsync(goal.Id);
                var goalCategory = GoalCategories.FirstOrDefault(g => g.GoalCategoryName == goal.GoalCategoryName);
                GoalCategories.ReportItemChange(goalCategory);
            }
        }
    }
}
