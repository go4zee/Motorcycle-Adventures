using System;
using System.Collections.Generic;
using System.Text;
using MotorcycleAdventures.Core.Models;

namespace MotorcycleAdventures.ViewModels
{
    public class GoalCategoryViewModel : ViewModelWithHiddenChildren
    {
        public GoalCategory GoalCategory { get; set; }

        public GoalCategoryViewModel()
        {

        }

        public GoalCategoryViewModel(GoalCategory goalCategory) : this()
        {
            GoalCategory = goalCategory;
        }

        public int ChildrenRowHeightRequest
        {
            get
            {
                if (GoalCategory.Goals != null)
                    return GoalCategory.Goals.Count * 50;

                return 0;
            }
        }
    }
}
