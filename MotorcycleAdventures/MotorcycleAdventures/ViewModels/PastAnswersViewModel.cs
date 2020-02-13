using System.Linq;
using MotorcycleAdventures.Core.Customized;
using MotorcycleAdventures.Core.Models;

namespace MotorcycleAdventures.ViewModels
{
    public class PastAnswersViewModel : BaseViewModel
    {

        private CustomObservableCollection<DailyAnswer> _answeredQuestions;

        public CustomObservableCollection<DailyAnswer> AnsweredQuestions
        {
            get => _answeredQuestions;
            set => SetProperty(ref _answeredQuestions, value);
        }
     
        public PastAnswersViewModel()
        {
            
        }
    }
}
