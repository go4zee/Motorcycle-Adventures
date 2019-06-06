using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MotorcycleAdventures.Core;
using MotorcycleAdventures.Core.Models;

namespace MotorcycleAdventures.ViewModels
{
    public class GoalCategoryViewModel 
    {
        public string GoalCategoryName { get; set; }

        public ObservableCollection<Goal> Goals { get; set; }

        public bool AreChildrenVisible { get; set; }
        public string ArrowIconSource => AreChildrenVisible ? "ArrowUp.png" : "ArrowDown.png";

        public GoalCategoryViewModel()
        {
            Goals = new ObservableCollection<Goal>();
        }

        public GoalCategoryViewModel(string goalCategory) : this()
        {
            GoalCategoryName = goalCategory;
        }

        public int ChildrenRowHeightRequest
        {
            get
            {
                if (Goals != null)
                {
                    return Goals.Count * Constants.RowHeight;
                }

                return 0;
            }
        }
    }
}
