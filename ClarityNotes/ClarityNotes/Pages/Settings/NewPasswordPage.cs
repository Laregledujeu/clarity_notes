﻿using System;
using System.Text.RegularExpressions;

using Xamarin.Forms;

namespace ClarityNotes
{
    public class NewPasswordPage : ContentPage
    {
        User user;
        Entry passwordEntry;
        Entry passwordEntryCompare;
        Button submit;
        public NewPasswordPage(User user)
        {
            this.user = user;

            StackLayout mainContent = new StackLayout();
            mainContent.Padding = 50;
            mainContent.HorizontalOptions = LayoutOptions.Center;
            mainContent.VerticalOptions = LayoutOptions.CenterAndExpand;

            Frame frame = new Frame();
            frame.HasShadow = true;
            frame.BackgroundColor = Color.White;
            frame.HorizontalOptions = LayoutOptions.Center;
            StackLayout framStack = new StackLayout();

            Label label = new Label();
            label.FontSize = 16;
            label.Text = "Veuillez entrer votre nouveau mot de passe";
            framStack.Children.Add(label);

            passwordEntry = new Entry();
            passwordEntry.IsPassword = true;
            framStack.Children.Add(passwordEntry);


            Label labelCompare = new Label();
            labelCompare.FontSize = 16;
            labelCompare.Text = "\nVeuillez de nouveau entrer votre mot de passe";
            framStack.Children.Add(labelCompare);

            passwordEntryCompare = new Entry();
            passwordEntryCompare.IsPassword = true;
            passwordEntryCompare.TextChanged += OnCompare;
            passwordEntryCompare.Completed += OnSubmitClicked;
            framStack.Children.Add(passwordEntryCompare);

            submit = new Button();
            submit.HorizontalOptions = LayoutOptions.Center;
            submit.VerticalOptions = LayoutOptions.Center;
            submit.Margin = 20;
            submit.IsEnabled = false;
            submit.Clicked += OnSubmitClicked;
            submit.Text = "Valider";

            frame.Content = framStack;
            mainContent.Children.Add(frame);
            mainContent.Children.Add(submit);

            this.Content = mainContent;
            this.BackgroundColor = user.ColorTheme;
        }


        public void OnCompare(object sender, EventArgs e)
        {
            Regex passwordType = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            Match match = passwordType.Match(passwordEntryCompare.Text);
            if (!(match.Success && passwordEntryCompare.Text == passwordEntry.Text))
            {
                submit.IsEnabled = false;
                passwordEntry.TextColor = Color.Red;
                passwordEntryCompare.TextColor = Color.Red;
            }
            else
            {
                submit.IsEnabled = true;
                passwordEntry.TextColor = Color.Blue;
                passwordEntryCompare.TextColor = Color.Blue;
            }
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == null) return;
            User.Change(user.Id, "hashPassword", User.GetHashedPassword(passwordEntry.Text));
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}