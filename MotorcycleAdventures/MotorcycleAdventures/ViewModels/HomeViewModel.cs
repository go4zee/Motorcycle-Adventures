using System;
using System.Collections.Generic;
using System.Text;
using MotorcycleAdventures.Models;

namespace MotorcycleAdventures.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        public DateTime Date { get; set; }

        public DailyAnswer DailyAnswer { get; set; }

        public HomeViewModel(IPageService pageService)
        {
            _pageService = pageService;
        }
    }
}
