﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotorcycleAdventures.Persistence;
using MotorcycleAdventures.Services;
using MotorcycleAdventures.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotorcycleAdventures.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomeViewModel ViewModel
        {
            get => BindingContext as HomeViewModel;
            set => BindingContext = value;
        }

        public HomePage()
        {

            ViewModel = new HomeViewModel(new PageService(Navigation));

            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private void SaveAnswer_OnClicked(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute(TxtAnswer.Text);
        }
    }
}