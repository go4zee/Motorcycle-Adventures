using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MotorcycleAdventures.Core.Models
{
    [Serializable]
    public class Goal : INameAndId
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string GoalCategoryName { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime AchieveByDate { get; set; }

        public DateTime AddedOn { get; set; }

        public Goal()
        {
            AddedOn = DateTime.Now;
            AchieveByDate = DateTime.Today;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
