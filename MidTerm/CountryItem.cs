using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MidTerm
{
    public class CountryItem
    {
        string name;
        int image;

        public CountryItem(string name, int image)
        {
            this.name = name;
            this.image = image;
        }

        public int Image { get => image; set => image = value; }
        public string Name { get => name; set => name = value; }
    }
}