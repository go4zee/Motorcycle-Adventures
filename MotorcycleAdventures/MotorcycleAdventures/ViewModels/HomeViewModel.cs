using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MotorcycleAdventures.Models;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.Services;
using SQLite;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public NotifyTaskCompletion<DailyAnswer> DailyAnswerNotificationTask { get; set; }

        private readonly IPageService _pageService;

        private readonly IRepository<DailyAnswer> _repository;

        public DateTime Date { get; set; }

        public DailyAnswer DailyAnswer { get; set; }

        public ICommand SaveCommand { get; set; }

        public HomeViewModel()
        {
            var connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();
            _repository = new Repository<DailyAnswer>(connection);
        }

        public HomeViewModel(IPageService pageService) : this()
        {
            _pageService = pageService;

            Date = DateTime.Today;

            SaveCommand = new Command<string>(async s => await Save(s));

            DailyAnswerNotificationTask = new NotifyTaskCompletion<DailyAnswer>(task: GetDailyAnswer());

            DailyAnswerNotificationTask.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals(nameof(DailyAnswerNotificationTask.IsCompleted))
                    && DailyAnswerNotificationTask.IsCompleted)
                {
                    DailyAnswer = DailyAnswerNotificationTask.Result;

                    OnPropertyChanged(nameof(DailyAnswer));
                }
            };
        }

        public async Task<DailyAnswer> GetDailyAnswer()
        {
            var dailyAnswer = await _repository.FirstOrDefaultAsync(d => d.AnsweredOn == Date);

            return dailyAnswer;
        }

        private async Task Save(string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                await _pageService.DisplayAlert("Error", "Please enter an answer", null, "Ok");
                return;
            }

            if (DailyAnswer == null)
            {
                DailyAnswer = new DailyAnswer();
            }

            DailyAnswer.Answer = answer;

            bool result = false;
            if (DailyAnswer.Id == 0)
            {
                result = await _repository.AddItemAsync(DailyAnswer);
            }
            else
            {
                result = await _repository.UpdateItemAsync(DailyAnswer);
            }

            if (result)
            {
                await _pageService.DisplayAlert("Success", "Saved!", null, "Ok");
            }
            else
            {
                await _pageService.DisplayAlert("Error", "Could Not Save, Try Again!", null, "Ok");
            }

        }
    }
}
