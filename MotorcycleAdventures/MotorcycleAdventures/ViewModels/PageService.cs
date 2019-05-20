using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MotorcycleAdventures.ViewModels
{
    public class PageService : IPageService
    {
        public INavigation Navigation { get; set; }

        public async Task SetMainPage(Page page)
        {
            Application.Current.MainPage = page;
        }

        public async Task PushAsync(Page page, INavigation navigation)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushToNavigationAsync(Page page, bool animated = true)
        {
            if (Navigation != null)
                await Navigation?.PushAsync(page, animated);
        }

        public async Task PopToNavigationAsync(bool animated = true)
        {
            if (Navigation != null)
                await Navigation?.PopAsync(animated);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel: cancel);
        }

        public PageService()
        {

        }

        public PageService(INavigation navigation) : this()
        {
            Navigation = navigation;
        }


    }
}
