using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace MidTerm
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ImageView imgViewMain;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var btnStart = FindViewById<Button>(Resource.Id.btnStart);
            imgViewMain = FindViewById<ImageView>(Resource.Id.imgViewMain);
            imgViewMain.SetImageResource(Resource.Drawable.flags);
            Intent questionActivity = new Intent(this, typeof(QuestionActivity));
            btnStart.Click += delegate
            {
                StartActivity(questionActivity);
            };
        }
    }
}