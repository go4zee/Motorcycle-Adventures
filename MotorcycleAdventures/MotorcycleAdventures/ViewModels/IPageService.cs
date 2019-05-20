using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public interface IPageService
    {
        INavigation Navigation { get; set; }

        Task SetMainPage(Page page);

        Task PushAsync(Page page);

        Task PushToNavigationAsync(Page page, bool animated = true);

        Task PopToNavigationAsync(bool animated = true);

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        Task DisplayAlert(string title, string message, string cancel);
    }
}
