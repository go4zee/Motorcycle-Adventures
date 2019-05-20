using System;
using System.Collections.Generic;
using System.Text;
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

        public GoalViewModel()
        {
            var connection = DependencyService.Get<ISQLiteDbContext>().GetConnection();
            _repository = new Repository<Goal>(connection);
        }

        public GoalViewModel(IPageService pageService) : this()
        {
            _pageService = pageService;
        }
    }
}
