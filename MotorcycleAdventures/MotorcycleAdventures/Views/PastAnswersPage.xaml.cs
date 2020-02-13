using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleAdventures.Core.Customized;
using MotorcycleAdventures.Core.Models;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotorcycleAdventures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastAnswersPage : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;

        private readonly PastAnswersViewModel _viewModel;

        public PastAnswersPage()
        {
            _connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();

            var createTableResult = _connection.CreateTableAsync<DailyAnswer>().Result;

            _viewModel = new PastAnswersViewModel();
            _viewModel.AnsweredQuestions = new CustomObservableCollection<DailyAnswer>(GetAnsweredQuestions());

            this.BindingContext = _viewModel;

            InitializeComponent();
        }

        private IList<DailyAnswer> GetAnsweredQuestions()
        {
            var answeredQuestions = _connection.Table<DailyAnswer>()
                .Where(q => q.Answer != "")
                .OrderByDescending(q => q.AnsweredOn)
                .ToListAsync()
                .Result
                .ToList();
            return answeredQuestions;
        }
    }
}