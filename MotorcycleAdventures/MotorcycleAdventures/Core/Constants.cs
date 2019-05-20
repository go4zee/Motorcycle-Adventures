using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MotorcycleAdventures.Core
{
    public class Constants
    {
        public static Color Orange = Color.FromRgb(255, 167, 10);

        public static Color SeperatorColor = Color.LightGray;

        public static Color EntryTextColor = Color.FromHex("737373");

        public static Color BottonIconDefault = Color.FromHex("f0f0f0");

        public const string DbName = "MotorcycleAdventuresDb.db3";

        public static class Unit
        {
            public static string In = "in";
            public static string mm = "mm";
        }

    }
}
