using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MotorcycleAdventures.Controls
{
    public class ContentPageWithNavigationBar : ContentPage
    {
        public ContentPageWithNavigationBar()
        {
            NavigationPage.SetTitleView(this, new HeaderView());
        }
    }
}
