using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MotorcycleAdventures.Core.Models
{
    public class Goal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string GoalCategoryName { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime AcheiveBySeason { get; set; }

        public DateTime AddedOn { get; set; }

        public Goal()
        {
            AddedOn = DateTime.Now;
        }
    }
}
