using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeberAgua.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefinicaoPage : ContentPage
    {
        Entry nomeEntry, idadeEntry, pesoEntry;
        Label nomeLabel, idadeLabel, pesoLabel, notificacaoLabel;
        Switch notificacaoSwitch;


        public DefinicaoPage()
        {
            InitializeComponent();

            NomeLabel = new Label();
            IdadeLabel = new Label();
            PesoLabel = new Label();
            notificacaoSwitch = new Switch();
            notificacaoLabel = new Label { Text = "Notificações" };

            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            stackLayout.Children.Add(notificacaoLabel);
            stackLayout.Children.Add(notificacaoSwitch);

            stackLayout.Children.Add(new Label { Text = "Nome", FontSize = 18 });
            stackLayout.Children.Add(NomeLabel);

            stackLayout.Children.Add(new Label { Text = "Idade", FontSize = 18 });
            stackLayout.Children.Add(IdadeLabel);

            stackLayout.Children.Add(new Label { Text = "Peso", FontSize = 18 });
            stackLayout.Children.Add(PesoLabel);

            var salvarButton = new Button { Text = "Editar Informações" };
            salvarButton.Clicked += OnEditarClicked;
            stackLayout.Children.Add(salvarButton);

            Content = stackLayout;

            notificacaoSwitch.Toggled += OnNotificationToggled;

        }

        private async void OnEditarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPessoaPage(this));
        }

        public void AtualizarInformacoes(string nome, string idade, string peso)
        {
            NomeLabel.Text = $"{nome}";
            IdadeLabel.Text = $"{idade}";
            PesoLabel.Text = $"{peso}";
            notificacaoLabel.Text = $"Notificações: {(notificacaoSwitch.IsToggled ? "Ligadas" : "Desligadas")}";
        }
        public void OnSaveClicked(string nome, string idade, string peso)
        {
            nomeLabel.Text = $"Nome: {nome}";
            idadeLabel.Text = $"Idade: {idade}";
            pesoLabel.Text = $"Peso: {peso}";
            notificacaoLabel.Text = $"Notificações: {(notificacaoSwitch.IsToggled ? "Ligadas" : "Desligadas")}";
        }

        private void OnNotificationToggled(object sender, ToggledEventArgs e)
        {
            notificacaoLabel.Text = $"Notificações: {(e.Value ? "Ligadas" : "Desligadas")}";
        }


      


        
    }
  
}


