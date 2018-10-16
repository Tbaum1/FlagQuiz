using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "QuestionActivity")]
    public class QuestionActivity : Android.App.Activity
    {
        Button btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4;
        ImageView imgFlag;
        TextView txtViewCounter;
        Storage storage = new Storage();
        int[] tempFlags = new int[10];
        string[] tempAnswer = new string[10];
        List<CountryItem> list = new List<CountryItem>();
        static Random rnd = new Random();
        int turn = 1;
        int correctAnswer;
        int score = 0;
        string questionNumberText = " of 10";
        protected MediaPlayer mainPlayer;
        protected MediaPlayer player;
        private ISharedPreferences prefs = Android.App.Application.Context.GetSharedPreferences("score", FileCreationMode.Private);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_questions);
            imgFlag = FindViewById<ImageView>(Resource.Id.imgView);
            btnAnswer1 = FindViewById<Button>(Resource.Id.btnAnswer1);
            btnAnswer2 = FindViewById<Button>(Resource.Id.btnAnswer2);
            btnAnswer3 = FindViewById<Button>(Resource.Id.btnAnswer3);
            btnAnswer4 = FindViewById<Button>(Resource.Id.btnAnswer4);
            txtViewCounter = FindViewById<TextView>(Resource.Id.txtViewCounter);
            Intent questionActivity = new Intent(this, typeof(QuestionActivity));
            Intent gameOver = new Intent(this, typeof(GameOverActivity));
            for (int i = 0; i < new Storage().answers.Length; i++)
            {
                list.Add(new CountryItem(new Storage().answers[i],new Storage().flags[i]));
            }
            //imgFlag.SetImageResource(storage.flags[3]);
            Shuffle<CountryItem>(rnd, list);
            mainPlayer = MediaPlayer.Create(this, Resource.Raw.gameAudio);
            mainPlayer.Start();
            NewQuestion(turn);
            
            btnAnswer1.Click += (sender, e) => {

                if (btnAnswer1.Text == list[turn - 1].Name)
                {
                    player = MediaPlayer.Create(this, Resource.Raw.correct);
                    player.Start();
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        score++;
                        saveScore();
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        score++;
                        saveScore();
                        StartActivity(gameOver);
                    }

                }
                else
                {
                    player = MediaPlayer.Create(this, Resource.Raw.wrong);
                    player.Start();
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        NewQuestion(turn);
                    }
                    else
                    {                        
                        mainPlayer.Stop();
                        StartActivity(gameOver);
                    }
                }
            };

            btnAnswer2.Click += (sender, e) => {

                if (btnAnswer2.Text == list[turn - 1].Name)
                {
                    player = MediaPlayer.Create(this, Resource.Raw.correct);
                    player.Start();
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        score++;
                        saveScore();
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        score++;
                        saveScore();
                        StartActivity(gameOver);
                    }

                }
                else
                {
                    player = MediaPlayer.Create(this, Resource.Raw.wrong);
                    player.Start();
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;                        
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        StartActivity(gameOver);
                    }
                }
            };

            btnAnswer3.Click += (sender, e) => {

                if (btnAnswer3.Text == list[turn - 1].Name)
                {
                    player = MediaPlayer.Create(this, Resource.Raw.correct);
                    player.Start();
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        score++;
                        saveScore();
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        score++;
                        saveScore();
                        StartActivity(gameOver);
                    }

                }
                else
                {
                    player = MediaPlayer.Create(this, Resource.Raw.wrong);
                    player.Start();
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        StartActivity(gameOver);
                    }
                }
            };

            btnAnswer4.Click += (sender, e) => {

                if (btnAnswer4.Text == list[turn - 1].Name)
                {
                    player = MediaPlayer.Create(this, Resource.Raw.correct);
                    player.Start();
                    Toast.MakeText(this, "Correct", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        score++;
                        saveScore();
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        score++;
                        saveScore();
                        StartActivity(gameOver);
                    }

                }
                else
                {
                    player = MediaPlayer.Create(this, Resource.Raw.wrong);
                    player.Start();
                    Toast.MakeText(this, "Incorrect", ToastLength.Short).Show();
                    if (turn < 10)
                    {
                        turn++;
                        NewQuestion(turn);
                    }
                    else
                    {
                        mainPlayer.Stop();
                        StartActivity(gameOver);
                    }
                }
            };
        }

        private void saveScore()
        {
            //store the information in shared preferences
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("score", score);

            //write key pairs to SP
            editor.Apply();
        }

        private void NewQuestion(int number) {
            txtViewCounter.Text = turn + questionNumberText;
            imgFlag.SetImageResource(list[number - 1].Image);
            
            correctAnswer = rnd.Next(1,4);
            
            int btnOne = number - 1;
            int btnTwo;
            int btnThree;
            int btnFour;

            switch (correctAnswer)
            {
                case 1:
                    btnAnswer1.Text = list[btnOne].Name;

                    do
                    {
                        btnTwo = rnd.Next(list.Count);
                    } while (btnTwo == btnOne);
                    do
                    {
                        btnThree = rnd.Next(list.Count);
                    } while (btnThree == btnOne || btnThree == btnTwo);
                    do
                    {
                        btnFour = rnd.Next(list.Count);
                    } while (btnFour == btnOne || btnFour == btnTwo || btnFour == btnThree);

                    btnAnswer2.Text = list[btnTwo].Name;
                    btnAnswer3.Text = list[btnThree].Name;
                    btnAnswer4.Text = list[btnFour].Name;

                    break;
                case 2:
                    btnAnswer2.Text = list[btnOne].Name;

                    do
                    {
                        btnTwo = rnd.Next(list.Count);
                    } while (btnTwo == btnOne);
                    do
                    {
                        btnThree = rnd.Next(list.Count);
                    } while (btnThree == btnOne || btnThree == btnTwo);
                    do
                    {
                        btnFour = rnd.Next(list.Count);
                    } while (btnFour == btnOne || btnFour == btnTwo || btnFour == btnThree);

                    btnAnswer1.Text = list[btnTwo].Name;
                    btnAnswer3.Text = list[btnThree].Name;
                    btnAnswer4.Text = list[btnFour].Name;

                    break;
                case 3:
                    btnAnswer3.Text = list[btnOne].Name;

                    do
                    {
                        btnTwo = rnd.Next(list.Count);
                    } while (btnTwo == btnOne);
                    do
                    {
                        btnThree = rnd.Next(list.Count);
                    } while (btnThree == btnOne || btnThree == btnTwo);
                    do
                    {
                        btnFour = rnd.Next(list.Count);
                    } while (btnFour == btnOne || btnFour == btnTwo || btnFour == btnThree);

                    btnAnswer2.Text = list[btnTwo].Name;
                    btnAnswer1.Text = list[btnThree].Name;
                    btnAnswer4.Text = list[btnFour].Name;

                    break;
                case 4:
                    btnAnswer4.Text = list[btnOne].Name;

                    do
                    {
                        btnTwo = rnd.Next(list.Count);
                    } while (btnTwo == btnOne);
                    do
                    {
                        btnThree = rnd.Next(list.Count);
                    } while (btnThree == btnOne || btnThree == btnTwo);
                    do
                    {
                        btnFour = rnd.Next(list.Count);
                    } while (btnFour == btnOne || btnFour == btnTwo || btnFour == btnThree);

                    btnAnswer2.Text = list[btnTwo].Name;
                    btnAnswer3.Text = list[btnThree].Name;
                    btnAnswer1.Text = list[btnFour].Name;

                    break;
            }

        }

        public void Shuffle<T>(Random rng, List<T> array)
        {
            int n = array.Count;
                
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }              
    }    
}
