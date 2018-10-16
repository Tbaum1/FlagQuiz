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
    [Activity(Label = "GameOverActivity")]
    public class GameOverActivity : Android.App.Activity
    {
        private ISharedPreferences prefs = 
            Android.App.Application.Context.GetSharedPreferences("score", FileCreationMode.Private);
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_gameOver);

            TextView score = FindViewById<TextView>(Resource.Id.txtViewScore);

            string temp = prefs.GetInt("score", 0).ToString();
            score.Text = temp  + " Out of 10";
            var btnPlayAgain = FindViewById<Button>(Resource.Id.btnPlayAgain);
            var btnExit = FindViewById<Button>(Resource.Id.btnExit);
            Intent questionActivity = new Intent(this, typeof(QuestionActivity));
            btnPlayAgain.Click += delegate
            {
                StartActivity(questionActivity);
            };
            btnExit.Click += delegate
            {
                System.Environment.Exit(0);
            };
        }
    }
}
