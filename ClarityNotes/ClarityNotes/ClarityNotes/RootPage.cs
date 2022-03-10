﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace ClarityNotes
{
    public class RootPage : ContentPage
    {
        string PATH = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/data";
        StackLayout listNotes;
        public RootPage()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
<<<<<<< HEAD
                Directory.CreateDirectory(PATH + "/Test");
                StreamWriter sw = new StreamWriter(PATH + "/Test/note.txt");
                sw.WriteLine("Voila ma note");
                sw.Close();
                
=======

>>>>>>> 15f2468185a283160a3ce5ae080dbc2f037b6bee
            }

            StackLayout mainContent = new StackLayout();
            mainContent.Orientation = StackOrientation.Horizontal;
            mainContent.VerticalOptions = LayoutOptions.CenterAndExpand;
            mainContent.HorizontalOptions = LayoutOptions.Start;

            StackLayout verticalLayout = new StackLayout();

            Frame frameColumn = new Frame();
            frameColumn.VerticalOptions = LayoutOptions.StartAndExpand;
            frameColumn.HorizontalOptions = LayoutOptions.StartAndExpand;


            StackLayout verticalColumn = new StackLayout();
            verticalColumn.HorizontalOptions = LayoutOptions.Center;
            verticalColumn.VerticalOptions = LayoutOptions.CenterAndExpand;

            Button buttonChapter;
            foreach (string dir in Directory.EnumerateDirectories(PATH))
            {
                Console.WriteLine(dir);
                buttonChapter = new Button();
                buttonChapter.Clicked += OnButtonClicked;
                buttonChapter.Text = Path.GetFileName(dir);
                verticalColumn.Children.Add(buttonChapter);
            }

            frameColumn.Content = verticalColumn;

            Frame AddFrame = new Frame();
            StackLayout AddLayout = new StackLayout();

            Button add = new Button() { Text = "+" };
            add.Clicked += OnAddClicked;
            AddLayout.Children.Add(add);

            Button remove = new Button() { Text = "-" };
            remove.Clicked += OnRemoveClicked;
            AddLayout.Children.Add(remove);

            Button settings = new Button() { Text = "SET" };
            AddLayout.Children.Add(settings);

            listNotes = new StackLayout();
            listNotes.Margin = 15;

            var direc = Directory.EnumerateDirectories(PATH);
            if (direc.Count() != 0) // si il existe un chapter
            {
                foreach (var dir in Directory.EnumerateFiles(direc.First()))
                {
                    Console.WriteLine(dir);
                    Label temp = new Label();
                    temp.Text = Path.GetFileName(dir);
                    listNotes.Children.Add(temp);
                }
            }
            else 
            {
                Label pleaseAddChapter = new Label();
                pleaseAddChapter.Text = "Vous n'avez pas encore de chapitre. Vous pouvez en creer un en utilisant le bouton +";
                listNotes.Children.Add(pleaseAddChapter);
            }

            verticalLayout.Children.Add(verticalColumn);
            verticalLayout.Children.Add(AddLayout);
            mainContent.Children.Add(verticalLayout);
            mainContent.Children.Add(listNotes);

            this.Content = mainContent;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            listNotes.Children.Clear();
            foreach (var dir in Directory.EnumerateFiles(PATH + "/" + ((Button)sender).Text))
            {
                Console.WriteLine(dir);
                Label temp = new Label();
                temp.Text = Path.GetFileName(dir);
                listNotes.Children.Add(temp);
            }
        }
        private void OnAddClicked(object sender, EventArgs e)
        {
            var page = new AddChapterPage();
            NavigationPage.SetHasNavigationBar(page, false);
            Navigation.PushAsync(page);
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var page = new RemoveChapterPage();
            NavigationPage.SetHasNavigationBar(page, false);
            Navigation.PushAsync(page);
        }
    }
}