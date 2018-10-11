using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MidTerm
{
    public class Storage
    {
        public int[] flags =
        {
            Resource.Drawable.brazil,
            Resource.Drawable.us,
            Resource.Drawable.italy,
            Resource.Drawable.japan,
            Resource.Drawable.uk,
            Resource.Drawable.france,
            Resource.Drawable.china,
            Resource.Drawable.canada,
            Resource.Drawable.australia,
            Resource.Drawable.germany
        };

        public string[] answers =
        {
            "brazil",
            "us",
            "italy",
            "japan",
            "uk",
            "france",
            "china",
            "canada",
            "australia",
            "germany"
        };
    }
}