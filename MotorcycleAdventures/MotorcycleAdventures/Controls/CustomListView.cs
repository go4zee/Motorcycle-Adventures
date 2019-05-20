using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MotorcycleAdventures.Controls
{
    public class CustomListView : ListView
    {
        protected override void SetupContent(Cell pContent, int pIndex)
        {
            base.SetupContent(pContent, pIndex);

            if (pContent is ViewCell currentViewCell)
                currentViewCell.View.BackgroundColor = pIndex % 2 == 0
                    ? Color.White
                    : Color.FromHex("#d9d9d9");
        }

        public CustomListView(ListViewCachingStrategy strategy) : base(strategy)
        {

        }

        public CustomListView()
        {

        }
    }
}
