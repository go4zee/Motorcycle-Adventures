using System.Collections.Generic;
using System.Linq;
using MotorcycleAdventures.Core.Models;
using Xamarin.Forms;

namespace MotorcycleAdventures.Core
{
    public class Constants
    {
        public static Color Orange = Color.FromRgb(255, 167, 10);

        public static Color SeperatorColor = Color.LightGray;

        public static Color EntryTextColor = Color.FromHex("737373");

        public static Color BottonIconDefault = Color.FromHex("f0f0f0");

        public const int RowHeight = 50;

        public const string DbName = "MotorcycleAdventuresDb.db3";

        public static class Unit
        {
            public static string In = "in";
            public static string mm = "mm";
        }

        public static class Dal
        {
            public static List<GoalCategory> ListGoalCategories()
            {
                return new List<GoalCategory>
                            {
                                new GoalCategory(1, "Motorcycle Safety"),
                                new GoalCategory(2, "Twisty Roads"),
                                new GoalCategory(3, "Group Rides"),
                                new GoalCategory(4, "Solo Rides"),
                                new GoalCategory(5, "Emergency Practice"),
                                new GoalCategory(6, "Technical"),
                                new GoalCategory(7, "Highway"),
                            }.OrderBy(g => g.Name).ToList();
            }

            public static List<string> ListGoalCategoriesStrings()
            {
                return new List<string>
                            {
                                 "Motorcycle Safety",
                                 "Twisty Roads",
                                 "Group Rides",
                                 "Solo Rides",
                                 "Stopping Practice",
                                 "Technical",
                                 "Highway",
                            }
                    .OrderBy(g => g)
                    .ToList();
            }
        }
    }

}
