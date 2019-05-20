using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace MotorcycleAdventures.Core.Models
{
    public class GoalCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<Goal> Goals { get; set; }

        public GoalCategory(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public GoalCategory()
        {
            Goals = new ObservableCollection<Goal>();
        }
    }
}
