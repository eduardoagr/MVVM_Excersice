﻿using MVVM_Example.ViewModel;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVVM_Example {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage: Page {
        public MainPage() {
            this.InitializeComponent();

        }

        //I will leave this here for testing purposes

        //private async void call() {
        //    var location = await MapLocator.GetCityData();
        //}
    }
}
