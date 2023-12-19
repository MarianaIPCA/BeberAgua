using BeberAgua.ViewModels;
using BeberAgua.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BeberAgua
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(HistoricoPage), typeof(HistoricoPage)); //Linha adicionada
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
