using System;
using SQLite;

namespace MotorcycleAdventures.Core.Models
{
    public class DailyAnswer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Answer { get; set; }

        public DateTime AnsweredOn { get; set; }

        public DailyAnswer()
        {
            AnsweredOn = DateTime.Today;
        }
    }
}
