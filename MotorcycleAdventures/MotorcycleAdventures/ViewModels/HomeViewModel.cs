using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MotorcycleAdventures.Models;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        public DateTime Date { get; set; }

        public DailyAnswer DailyAnswer { get; set; }

        public ICommand SaveCommand { get; set; }

        public HomeViewModel(IPageService pageService)
        {
            _pageService = pageService;

            SaveCommand = new Command<string>(async s => await Save(s));
        }

        private async Task Save(string answer)
        {
            if (string.IsNullOrEmpty(answer))
            {
                await _pageService.DisplayAlert("Error", "Please enter an answer", null, "Ok");
                return;
            }
        }
    }
}
