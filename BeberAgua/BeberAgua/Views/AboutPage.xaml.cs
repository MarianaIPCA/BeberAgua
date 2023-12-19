using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeberAgua.Views
{
    public partial class AboutPage : ContentPage
    {
        private HistoricoPage historicoPage;

        public AboutPage()
        {
            InitializeComponent();

        }
        private async void OnImageButtonTapped(object sender, EventArgs e)
        {
            var options = new List<ActionSheetOption>
            {
                new ActionSheetOption { ImageSource = "chavena.png", OptionName = "1 Chávena = 50mL" },
                new ActionSheetOption { ImageSource = "copopequeno.png", OptionName = "1 Copo pequeno = 100mL" },
                new ActionSheetOption { ImageSource = "copogrande.png", OptionName = "1 Copo grande = 250mL" },
                new ActionSheetOption { ImageSource = "caneca.png", OptionName = "1 Caneca = 500mL" },
                new ActionSheetOption { ImageSource = "garrafa.png", OptionName = "1 Garrafa = 750mL" },
                new ActionSheetOption { ImageSource = "jarra.png", OptionName = "1 Jarra = 1000mL" },
            };
            var stackLayout = new StackLayout { Spacing = 10, VerticalOptions = LayoutOptions.CenterAndExpand };

            foreach (var option in options)
            {
                var image = new Image { Source = option.ImageSource, WidthRequest = 30, HeightRequest = 30, VerticalOptions = LayoutOptions.Center };
                var label = new Label { Text = option.OptionName, VerticalOptions = LayoutOptions.Center };

                var optionLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { image, label },
                    GestureRecognizers = { new TapGestureRecognizer { Command = new Command(() => OnOptionSelected(option.OptionName)) } }
                };

                stackLayout.Children.Add(optionLayout);
            }

            var cancelButton = new Button { Text = "Cancelar", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)) };
            cancelButton.Clicked += (s, args) => OnOptionSelected("Cancelar");
            stackLayout.Children.Add(cancelButton);

            var actionSheet = new ContentPage
            {
                Content = new Frame { Content = stackLayout, VerticalOptions = LayoutOptions.CenterAndExpand },
                Padding = new Thickness(0, Device.RuntimePlatform == Device.iOS ? 20 : 0, 0, 0)
            };

            await Navigation.PushModalAsync(actionSheet);
        }
        
        private async void OnOptionSelected(string option)
        {
            if (option != "Cancelar")
            {
                await Shell.Current.GoToAsync($"//{nameof(HistoricoPage)}");

                var historicoPage = Shell.Current.CurrentPage as HistoricoPage;

                if (historicoPage != null)
                {
                    // Obtain the quantity corresponding to the selected option
                    int quantidade = ObterQuantidade(option);

                    // Add the selected option to the list in HistoricoPage
                    historicoPage.AdicionarItemHistorico(option, quantidade);
                }
            }
            else
            {
                // Voltar para a página anterior (AboutPage)
                await Shell.Current.GoToAsync("//AboutPage");
            }
        }
        private int ObterQuantidade(string option)
        {
            switch (option)
            {
                case "1 Chávena = 50mL": return 50;
                case "1 Copo pequeno = 100mL": return 100;
                case "1 Copo grande = 250mL": return 250;
                case "1 Caneca = 500mL": return 500;
                case "1 Garrafa = 750mL": return 750;
                case "1 Jarra = 1000mL": return 1000;
                default: return 0; 
            }
        }
}
    public class ActionSheetOption
    {
        public string ImageSource { get; set; }
        public string OptionName { get; set; }
    }

}
  


